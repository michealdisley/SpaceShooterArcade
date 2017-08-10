using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Floats
    public float fireRate;
    public float delay;

    // Other
    public GameObject shot;
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

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        if (centerLeftSpawn)
        {
            Instantiate(shot, centerLeftSpawn.position, centerLeftSpawn.rotation);
        }
        if (centerRightSpawn)
        {
            Instantiate(shot, centerRightSpawn.position, centerRightSpawn.rotation);
        }
        if (leftInnerSpawn)
        {
            Instantiate(shot, leftInnerSpawn.position, leftInnerSpawn.rotation);
        }
        if (leftOuterSpawn)
        {
            Instantiate(shot, leftOuterSpawn.position, leftOuterSpawn.rotation);
        }
        if (rightInnerSpawn)
        {
            Instantiate(shot, rightInnerSpawn.position, rightInnerSpawn.rotation);
        }
        if (rightOuterSpawn)
        {
            Instantiate(shot, rightOuterSpawn.position, rightOuterSpawn.rotation);
        }
        else { return; }
        source.Play();
    }
}
