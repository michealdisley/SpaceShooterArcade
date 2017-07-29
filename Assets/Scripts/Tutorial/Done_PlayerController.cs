using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    weaponSwap WS;

    // Ints
    public int numWeapons;

	public float speed;
	public float tilt;
	public Done_Boundary boundary;

    public GameObject shot;

    public GameObject[] firepoints;
    public GameObject weapons;
    public float fireRate;
	 
	private float nextFire;

    void Start()
    {
        WS = GetComponent<weaponSwap>();
        weapons = shot;

        firepoints = new GameObject[numWeapons];
        for (int i = 0; i < numWeapons; i++)
        {
            if (weapons == null)
                return;
            else
            {
                GameObject go = Instantiate(weapons, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
                go.transform.localScale = Vector3.one;
                firepoints[i] = go;
            }
        }
   

 //   void Update ()
	//{
		//if (Input.GetButton("Fire1") && Time.time > nextFire) 
		//{
		//	nextFire = Time.time + fireRate;
		//	Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
  //          if(firepoints[weapons] == 1)
  //          {
  //              Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
  //          }
  //          if (shotSpawn1)
  //          {
  //              Instantiate(WS.shot, shotSpawn1.position, shotSpawn1.rotation);
  //          }
  //          if (secoundWeapon)
  //          {
  //              Instantiate(WS.shot, secoundWeapon.position, secoundWeapon.rotation);
  //          }
  //          if (secoundWeapon)
  //          {
  //              Instantiate(WS.shot, secoundWeapon.position, secoundWeapon.rotation);
  //          }
  //          if (secoundWeapon)
  //          {
  //              Instantiate(WS.shot, secoundWeapon.position, secoundWeapon.rotation);
  //          }
  //          if (secoundWeapon)
  //          {
  //              Instantiate(WS.shot, secoundWeapon.position, secoundWeapon.rotation);
  //          }
  //          if (secoundWeapon)
  //          {
  //              Instantiate(WS.shot, secoundWeapon.position, secoundWeapon.rotation);
  //          }
  //          if (secoundWeapon)
  //          {
  //              Instantiate(WS.shot, secoundWeapon.position, secoundWeapon.rotation);
  //          }
  //          else { return; }
  //          GetComponent<AudioSource>().Play ();
		//}
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
