using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private PlayerController PC;

    void Start()
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
        else if (other.tag == "Player") // Applys Shields Effect.
        {
            // PC.shieldActive = true;
            PC.shield += 10;
            if (PC.shield >= PC.maxShield)
                PC.shield = PC.maxShield;
            Destroy(gameObject);
        }
        else return;
    }
}
