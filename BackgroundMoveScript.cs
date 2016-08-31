using UnityEngine;
using System.Collections;

public class BackgroundMoveScript : MonoBehaviour
{

	private float moveSpeed;
	private float tileSizeZ;
	private Vector3 startPosition;
	SpawnWavesScript sws;

	// Use this for initialization
	void Start ()
	{
		startPosition = transform.position;
		moveSpeed = -0.7f;
		tileSizeZ = 30f;
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float newPosition = Mathf.Repeat (Time.time * moveSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
		if (sws.numberForSpawn == 60) {
			moveSpeed = -1.0f;
		}
	}

}
