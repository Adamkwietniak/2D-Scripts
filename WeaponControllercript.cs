using UnityEngine;
using System.Collections;

public class WeaponControllercript : MonoBehaviour
{

	public GameObject shot;
	public Transform shotSpawn;
	private AudioSource audioSource;
	public float fireRate;
	public float delay;
	public AudioClip[] clips;
	SpawnWavesScript sws;


	// Use this for initialization
	void Start ()
	{
		
		sws = FindObjectOfType <SpawnWavesScript> ();
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);

	}
	
	// Update is called once per frame
	public void Fire ()
	{
		
		if (sws.GetGameOver () == false) {
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			AudioClip clip = clips [Random.Range (0, clips.Length)];
			audioSource.clip = clip;
			audioSource.Play ();
		

		

		}
	}
}