using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcPowerUp : MonoBehaviour
{

    private PlayerController PC;

	// Use this for initialization
	void Start ()
    {
        GameObject PlayerControllerObject = GameObject.FindGameObjectWithTag("Player");
        if (PlayerControllerObject != null)
        {
            PC = PlayerControllerObject.GetComponent<PlayerController>();
        }
        if (PC == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") // Object Fell to the bottom of the screen.
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player") // Applys Power Up Effect.
        {
            PC.arcBurst = true;
            Destroy(gameObject);
        }
        else return;
    }
}
