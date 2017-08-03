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
    GameController GC;

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
    public bool ArcBurst;

    public GameObject Bolts;
    public AudioClip boltSound;
    public GameObject Missiles;
    public AudioClip missileSound;

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

        currentWeapon = Bolts;
        Audi.clip = boltSound;

        ArcBurst = false;
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (centerLeftSpawn)
            {
                if (ArcBurst)
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
                if (ArcBurst)
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
                if (ArcBurst)
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
                if (ArcBurst)
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
                if (ArcBurst)
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
                if (ArcBurst)
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
                if (ArcBurst)
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
                if (ArcBurst)
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

        if(Input.GetKeyDown(KeyCode.E))
        {
            BoltWeapon();
            Debug.Log("E pushed!");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            MissileWeapon();
            Debug.Log("R pushed!");
        }
    }

    void FixedUpdate()
    {
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
}

