using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public Transform shotSpawn4;
    public Transform shotSpawn5;
    public Transform shotSpawn6;
    public Transform shotSpawn7;
    public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            if(shotSpawn1)
            {
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            }
            if (shotSpawn1)
            {
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            }
            if (shotSpawn2)
            {
                Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
            }
            if (shotSpawn3)
            {
                Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
            }
            if (shotSpawn4)
            {
                Instantiate(shot, shotSpawn4.position, shotSpawn4.rotation);
            }
            if (shotSpawn5)
            {
                Instantiate(shot, shotSpawn5.position, shotSpawn5.rotation);
            }
            if (shotSpawn6)
            {
                Instantiate(shot, shotSpawn6.position, shotSpawn6.rotation);
            }
            if (shotSpawn7)
            {
                Instantiate(shot, shotSpawn7.position, shotSpawn7.rotation);
            }
            else { return; }
            GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
