using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{


	SpawnWavesScript sws;
	public GameObject lighting;



	// Use this for initialization
	void Start ()
	{
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();
		StartCoroutine (LightingAttack ());

	}




	IEnumerator LightingAttack ()
	{
		//if (lighting != null)
		while (true) {
			yield return new WaitForSeconds (2f);
			lighting.SetActive (true);
			yield return new WaitForSeconds (2f);
			lighting.SetActive (false);
			if (sws.gameOver == true)
				break;
			//}

		}
	}
}