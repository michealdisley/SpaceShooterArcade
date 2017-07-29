using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class weaponSwap : MonoBehaviour
{
    public bool activeMissile;
    public bool activeLaser;

    public GameObject shot;
    public GameObject laserbolt;
    public GameObject missile;

    public AudioClip laserShot;
    public AudioClip missileLunched;
    public AudioClip nukeExplode;



	// Use this for initialization
	void Awake()
    {
        activeLaser = false;
        activeMissile = false;

        shot = null;
        //Debug.Log("Laserbolt set as active weapon!!");
	}
	
	// Update is called once per frame
	void Update ()
    {
        activateWeapon();
	}

    void activateWeapon()
    {
        if (activeLaser)
        {
            shot = laserbolt;
        }
        if (activeMissile)
        {
            shot = missile;
        }
    }

}
