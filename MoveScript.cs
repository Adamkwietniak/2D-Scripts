using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	private Rigidbody rbBolt;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		rbBolt = GetComponent<Rigidbody> ();
		rbBolt.velocity = transform.forward * speed;
	}
	

}
