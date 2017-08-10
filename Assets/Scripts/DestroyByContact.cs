using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    // Ints
    public int scoreValue;

    // Others
    public GameObject explosion;
    public GameObject playerExplosion;

    private LevelController LC;

    void Start()
    {
        GameObject LevelControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (LevelControllerObject != null)
        {
            LC = LevelControllerObject.GetComponent<LevelController>();
        }
        if (LC == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            if (other.transform.parent != null)
            {
                Destroy(gameObject);
            }
            else return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            LC.GameOver();
        }


        LC.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
