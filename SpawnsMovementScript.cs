using UnityEngine;
using System.Collections;

public class SpawnsMovementScript : MonoBehaviour
{

	private Transform spawnsObject;
	public Transform shipTransform;

	// Use this for initialization
	void Start ()
	{
		//spawnsObject = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = Vector3.Lerp (transform.position, shipTransform.position, 1.0f);
	}
}
