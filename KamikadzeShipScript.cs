using UnityEngine;
using System.Collections;

public class KamikadzeShipScript : MonoBehaviour
{

	private Rigidbody rb;
	private float speed;
	public GameObject turbo;
	private AudioSource turboSound;
	SpawnWavesScript sws;

	// Use this for initialization
	void Start ()
	{
		turbo.SetActive (false);
		speed = -4.0f;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
		Invoke ("Kamikadze", 1);
		turboSound = GetComponent<AudioSource> ();
		GameObject spawnControllerObject = GameObject.Find ("Spawns");
		sws = spawnControllerObject.GetComponent<SpawnWavesScript> ();


	}

	void Update ()
	{
		if (sws.numberForSpawn == 60) {

			speed -= -3;
		}
	}

	void Kamikadze ()
	{
		rb.velocity = transform.forward * -9.0f;
		turboSound.Play ();
		turbo.SetActive (true);
	}


}
