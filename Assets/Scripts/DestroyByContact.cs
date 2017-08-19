using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    // Ints
    public int scoreValue;

    private int healthPowerup = 2;
    private int missilePowerup = 4;
    private int arcPowerup = 6;
    private int shieldPowerup = 8;

    // Floats
    // private float perecntDrop = 30f; // Percentage that drop occurs

    // Others
    public GameObject explosion;
    public GameObject playerExplosion;

    public GameObject health;
    public GameObject missile;
    public GameObject arc;
    public GameObject shield;

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
        if (other.tag == "Boundary")
        {
            if (tag == "Shield" || other.tag == "Shield")
            {
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (tag == "Projectile" && other.tag == "Shield" || other.tag == "Projectile")
        {
            return;
        }
        else if (tag == "Projectile" && other.tag == "Enemy")
        {

            LC.AddScore(other.gameObject.GetComponent<DestroyByContact>().scoreValue);
            Destroy(other.gameObject);
            if (Random.Range(0, 10) == healthPowerup)
            {
                Instantiate(health, other.transform.position, other.transform.rotation);
            }
            else if (Random.Range(0, 10) == missilePowerup)
            {
                Instantiate(missile, other.transform.position, other.transform.rotation);
            }
            else if (Random.Range(0, 10) == arcPowerup)
            {
                Instantiate(arc, other.transform.position, other.transform.rotation);
            }
            else if (Random.Range(0, 10) == shieldPowerup)
            {
                Instantiate(shield, other.transform.position, other.transform.rotation);
            }
            else
                return;
        }
        else if (tag == "Enemy" && other.tag == "Shield")
        {
            Destroy(gameObject);
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
