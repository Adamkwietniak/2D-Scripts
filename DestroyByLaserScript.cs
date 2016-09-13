using UnityEngine;
using System.Collections;

public class DestroyByLaserScript : MonoBehaviour
{

	public GameObject playerExplosion;
	SpawnWavesScript sws;
	PlayerControllerTWODScript pctwods;

	void Start ()
	{
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();
		pctwods = FindObjectOfType <PlayerControllerTWODScript> ();
	}
	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" && pctwods.shotSpawnsIndex == 0) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			GameObject.Find ("Player2D").SetActive (false);
			GameObject.Find ("shotspawns").SetActive (false);
			sws.GameOver ();
		} else if (other.tag == "Player" && pctwods.shotSpawnsIndex >= 0) {
			pctwods.shotSpawnsIndex--;
		}

	}
}
