using UnityEngine;
using System.Collections;

public class DestroyByLaserScript : MonoBehaviour
{

	public GameObject playerExplosion;
	SpawnWavesScript sws;

	void Start ()
	{
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();
	}
	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			GameObject.Find ("Player2D").SetActive (false);
			sws.GameOver ();
		}

	}
}
