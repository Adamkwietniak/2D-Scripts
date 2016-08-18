using UnityEngine;
using System.Collections;


public class PowerUpScript : MonoBehaviour
{

	PlayerControllerTWODScript pcts;
	private int scoreValue;
	SpawnWavesScript sws;
	private AudioSource powerUpSource;
	public AudioClip powerUpSound;


	void Start ()
	{
		pcts = (PlayerControllerTWODScript)FindObjectOfType (typeof(PlayerControllerTWODScript));
		scoreValue = 30;
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();
		powerUpSource = GetComponent<AudioSource> ();
	}


	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {

			pcts.shotSpawnsIndex++;
			Destroy (gameObject, 0.1f);
			sws.AddScore (scoreValue);
			powerUpSource.PlayOneShot (powerUpSound);
		}

	}



}
