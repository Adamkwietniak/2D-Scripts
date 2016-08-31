using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{

	private Rigidbody rbBolt;
	public float speed;
	SpawnWavesScript sws;

	// Use this for initialization
	void Start ()
	{
		rbBolt = GetComponent<Rigidbody> ();
		rbBolt.velocity = transform.forward * speed;
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();
	}

	void Update ()
	{
		if (sws.numberForSpawn == 60) {
			speed -= -4;
		}
	}


	

}
