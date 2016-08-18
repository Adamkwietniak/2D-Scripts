using UnityEngine;
using System.Collections;

public class BoundaryScripts : MonoBehaviour
{

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag != "Boundary") {
			
			Destroy (other.gameObject);
		}
	}
}
