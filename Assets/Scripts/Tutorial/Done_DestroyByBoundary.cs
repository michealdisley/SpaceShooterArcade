using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);

        if (other.transform.parent != null)
        {
            Destroy(other.transform.parent.gameObject);
        }
        else return;
    }
}