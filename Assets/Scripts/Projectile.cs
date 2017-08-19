using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * movementSpeed;

    }
}
