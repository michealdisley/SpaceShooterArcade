using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    LevelController LC;

    // Ints

    // Floats
    public float speed;
    public float fireRate;
    public float tilt;

    private float nextFire;

    // Bools

    // Others
    public Boundary boundary;

    [Header("Weapon's")]
    public bool bolt;
    public bool missile;
    public bool arcBurst;
    public bool shield;

    public GameObject Bolts;
    public AudioClip boltSound;
    public GameObject Missiles;
    public AudioClip missileSound;

    public GameObject shieldOn;
    private GameObject currentWeapon;

    [Header("Weapon Spawn")]
    public bool EnableWeaponSpawn = false;

    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform centerLeftSpawn;
    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform centerRightSpawn;
    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform leftInnerSpawn;
    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform leftOuterSpawn;
    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform rightInnerSpawn;
    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform rightOuterSpawn;
    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform leftTopSpawn;
    [ConditionalHide("EnableWeaponSpawn", true)]
    public Transform rightTopSpawn;

    private AudioSource Audi;

    void Start()
    {
        Audi = GetComponent<AudioSource>();

        // shieldOn = GameObject.FindGameObjectWithTag("Shield");
        // Debug.Log(shieldOn);

        currentWeapon = Bolts;
        Audi.clip = boltSound;


        missile = false;
        arcBurst = false;
        shield = false;
    }

    void Update()
    {

        if (bolt == true)
        {
            BoltWeapon();
            Debug.Log("Bolts Activated");
        }
        else if (missile == true)
        {
            MissileWeapon();
            Debug.Log("Missiles Activated");
        }

        if(shield == true)
        {
            StartCoroutine(Shield());
        }

    }

    void FixedUpdate()
    {
        Shoot();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void BoltWeapon()
    {
        currentWeapon = Bolts;
        Audi.clip = boltSound;
    }

    void MissileWeapon()
    {
        currentWeapon = Missiles;
        Audi.clip = missileSound;
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (centerLeftSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, centerLeftSpawn.position, centerLeftSpawn.rotation);
                    Instantiate(currentWeapon, centerLeftSpawn.position, Quaternion.Euler(new Vector3(0, -4, 0)));
                }
                else
                {
                    Instantiate(currentWeapon, centerLeftSpawn.position, centerLeftSpawn.rotation);
                }
            }
            if (centerRightSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, centerRightSpawn.position, Quaternion.Euler(new Vector3(0, 4, 0)));
                    Instantiate(currentWeapon, centerRightSpawn.position, centerRightSpawn.rotation);
                }
                else
                {
                    Instantiate(currentWeapon, centerRightSpawn.position, centerRightSpawn.rotation);
                }
            }

            if (leftInnerSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, leftInnerSpawn.position, Quaternion.Euler(new Vector3(0, -8, 0)));
                    Instantiate(currentWeapon, leftInnerSpawn.position, Quaternion.Euler(new Vector3(0, -4, 0)));
                }
                else
                {
                    Instantiate(currentWeapon, leftInnerSpawn.position, leftInnerSpawn.rotation);
                }
            }
            if (leftOuterSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, leftOuterSpawn.position, Quaternion.Euler(new Vector3(0, -10, 0)));
                }
                else
                {
                    Instantiate(currentWeapon, leftOuterSpawn.position, leftOuterSpawn.rotation);
                }
            }

            if (rightInnerSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, rightInnerSpawn.position, Quaternion.Euler(new Vector3(0, 8, 0)));
                    Instantiate(currentWeapon, rightInnerSpawn.position, Quaternion.Euler(new Vector3(0, 4, 0)));
                }
                else
                {
                    Instantiate(currentWeapon, rightInnerSpawn.position, rightInnerSpawn.rotation);
                }
            }
            if (rightOuterSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, rightOuterSpawn.position, Quaternion.Euler(new Vector3(0, 10, 0)));
                }
                else
                {
                    Instantiate(currentWeapon, rightOuterSpawn.position, rightOuterSpawn.rotation);
                }
            }

            if (leftTopSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, leftTopSpawn.position, Quaternion.Euler(new Vector3(0, -12, 0)));
                }
                else
                {
                    Instantiate(currentWeapon, leftTopSpawn.position, leftTopSpawn.rotation);
                }
            }
            if (rightTopSpawn)
            {
                if (arcBurst)
                {
                    Instantiate(currentWeapon, rightTopSpawn.position, Quaternion.Euler(new Vector3(0, 12, 0)));
                }
                else
                {
                    Instantiate(currentWeapon, rightTopSpawn.position, rightTopSpawn.rotation);
                }
            }

            else { return; }
            Audi.Play();
        }
    }

    IEnumerator Shield()
    {
        shieldOn.SetActive(true);
        yield return new WaitForSeconds(5f);
        shieldOn.SetActive(false);
        shield = false;
    }

    void Health()
    {
        // fix health.
    }
}

