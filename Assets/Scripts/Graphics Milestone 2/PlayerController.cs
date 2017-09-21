using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    LevelController LC;

    // Ints
    public int health = 100;
    public int shield = 50;

    [HideInInspector] public int maxHealth = 100;
    [HideInInspector] public int maxShield = 50;

    // Floats
    public float speed;
    public float fireRate;
    public float tilt;

    private float nextFire;

    // Bools
    [HideInInspector] public bool healthPowerUp = false;

    // Others
    public Boundary boundary;

    private Slider healthBar;
    private Slider shieldBar;
    private Text shieldText;

    [Header("Weapon's")]
    public bool bolt;
    public bool missile;
    public bool arcBurst;
    public bool shieldActive;

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

    private void Awake()
    {
        health = DataManager.GetPlayer<int>("Health");
        maxHealth = DataManager.GetPlayer<int>("maxHealth");
        shield = DataManager.GetPlayer<int>("Shield");
        maxShield = DataManager.GetPlayer<int>("maxShield");

        speed = DataManager.GetPlayer<float>("Speed");
        fireRate = DataManager.GetPlayer<float>("fireRate");
        tilt = DataManager.GetPlayer<float>("Tilt");


        bolt = DataManager.GetWeapons<bool>("Bolt");
        missile = DataManager.GetWeapons<bool>("Missile");
        arcBurst = DataManager.GetWeapons<bool>("ArcBurst");
        shieldActive = DataManager.GetWeapons<bool>("ShieldActive");
    }

    void Start()
    {
        Audi = GetComponent<AudioSource>();

        currentWeapon = Bolts;
        Audi.clip = boltSound;

        // shield = 50;
        // health = 100;

        if(shieldBar == null)
        {
            shieldBar = GameObject.FindGameObjectWithTag("Shield").GetComponent<Slider>();
            shieldBar.value = shield;
        }
        if(shieldBar == null)
        {
            Debug.Log("Shield bar not found.");
        }

        if (healthBar == null)
        {
            healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
            healthBar.value = health;
        }
        if (healthBar == null)
        {
            Debug.Log("Health bar not found.");
        }

        if (shieldText == null)
        {
            shieldText = GameObject.Find("Shield Text").GetComponent<Text>();
            shieldText.text = ("Shields: " + shield.ToString() + "/50");
        }
        if (shieldText == null)
        {
            Debug.Log("Shield text not found.");
        }

        missile = false;
        arcBurst = false;
        shieldActive = false;
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

        ShieldOn();

    }

    void FixedUpdate()
    {
        Shoot();
        Health();
        Shield();

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
        Shield();
        yield return new WaitForSeconds(shield);
        Debug.Log("Shield activated.");
    }

    void Health()
    {
        healthBar.value = health;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        Debug.Log("Health Updated.");
    }

    void ShieldOn()
    {
        if (shieldActive)
        {
            Debug.Log("Shield activated.");
            shieldOn.SetActive(true);
            if (shield > 0)
            {
                shield -= 1;
                if(shield <= 0)
                {
                    shield = 0;
                }
                shieldBar.value = shield;
                shieldText.text = ("Shields: " + shield.ToString() + "/50");
            }
            else
            {
                Debug.Log("Shield De-activated.");
                shieldOn.SetActive(false);
            }
        }
        else if (healthPowerUp)
        {
            Debug.Log("Health Pack Collected.");
            shield += 10;
            shieldBar.value = shield;
            if (shield >= maxShield)
            {
                shield = maxShield;
                shieldBar.value = shield;
                shieldText.text = ("Shields: " + shield.ToString() + "/50");
            }
            healthPowerUp = false;
        }
        else
            return;
    }
}

