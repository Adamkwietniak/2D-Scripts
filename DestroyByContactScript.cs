using UnityEngine;
using System.Collections;

public class DestroyByContactScript : MonoBehaviour
{

	public GameObject explosion;
	public GameObject playerExplosion;
	SpawnWavesScript sws;
	public int scoreValue;



	void Start ()
	{
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();


	}


	void OnTriggerEnter (Collider other)
	{
		
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;

		}

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);

		}
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			GameObject.Find ("Player2D").SetActive (false);
			sws.GameOver ();

		}


		Destroy (other.gameObject);
		Destroy (gameObject);
		sws.AddScore (scoreValue);

	}
}
