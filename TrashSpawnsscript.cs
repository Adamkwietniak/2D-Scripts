using UnityEngine;
using System.Collections;

public class TrashSpawnsscript : MonoBehaviour
{

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCounts;
	public float spawnWait;
	// czas oczekiwania na kolejna fale
	public float spawnStart;
	// zaczyna się fala
	public float waveWait;
	// odstęp miedzy falami


	// Use this for initialization
	void Start ()
	{
		StartCoroutine (SpawnRocks ());
	}

	IEnumerator SpawnRocks ()
	{
		yield return new WaitForSeconds (spawnStart);
		while (true) {
			for (int i = 0; i < hazardCounts; i++) {

				GameObject hazard = hazards [Random.Range (0, hazards.Length)];

				Vector3 spawnPosition = new Vector3 (Random.Range (8, 19), spawnValues.y, spawnValues.z);
				Vector3 spawnPositionTWO = new Vector3 (Random.Range (-17, -7), spawnValues.y, spawnValues.z);

				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);
				Instantiate (hazard, spawnPositionTWO, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}
	}
}
