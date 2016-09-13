using UnityEngine;
using System.Collections;

public class DestroyByContactScript : MonoBehaviour
{

	public GameObject explosion;
	public GameObject playerExplosion;
	SpawnWavesScript sws;
	public int scoreValue;
	PlayerControllerTWODScript pctwods;



	void Start ()
	{
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();
		pctwods = FindObjectOfType <PlayerControllerTWODScript> ();

	}


	void OnTriggerEnter (Collider other)
	{
		
		
		if (other.tag == "Boundary" /*|| other.tag == "Enemy"*/) {
			return;

		}

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);

		}
		if (other.tag == "Player" && pctwods.shotSpawnsIndex == 0) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			GameObject.Find ("Player2D").SetActive (false);
			GameObject.Find ("shotspawns").SetActive (false);
			sws.GameOver ();
			Destroy (other.gameObject);
		} else if (other.tag == "Player" && pctwods.shotSpawnsIndex > 0) {
			pctwods.shotSpawnsIndex--;
		}



		Destroy (gameObject);
		sws.AddScore (scoreValue);

	}
}
