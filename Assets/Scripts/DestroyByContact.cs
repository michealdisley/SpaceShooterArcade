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

    public LevelController LC;

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
        if (other.tag == "Boundary") // || other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (tag == "Projectile" && other.tag == "Enemy")
        {

            LC.AddScore(other.gameObject.GetComponent<DestroyByContact>().scoreValue);
            Destroy(other.gameObject);
        }
        else if (tag == "Enemy" && other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            LC.GameOver();
        }
        else if (tag == "Enemy" && other.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        // LC.AddScore(scoreValue);
        // Destroy(other.transform.parent.gameObject);
    }
}
