using UnityEngine;
using System.Collections;

public class RotatorAsteroidScript : MonoBehaviour {

	public float tumble;
	private Rigidbody rbAsteroid;

	// Use this for initialization
	void Start () 
	{
		rbAsteroid = GetComponent<Rigidbody> ();
		rbAsteroid.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
