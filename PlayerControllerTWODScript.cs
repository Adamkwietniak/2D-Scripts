﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControllerTWODScript : MonoBehaviour
{

	private Rigidbody rb;
	public float tilt;
	// nachylenie
	public float speed;
	//public float dodge;
	public Boundary boundary;
	public GameObject shot;
	// prefab pocisku
	public Transform[] shotSpawn = new Transform[5];
	// miejsca, z których wylatuje pocisk
	public float fireRate;
	// ile strzałów
	private AudioSource audSrc;
	private float nextFire;
	[HideInInspector]public int shotSpawnsIndex;


	UnityStandardAssets.ImageEffects.MotionBlur mb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();	
		audSrc = GetComponent<AudioSource> ();
		shotSpawnsIndex = 0;
		mb = FindObjectOfType<UnityStandardAssets.ImageEffects.MotionBlur> ();
		mb.blurAmount = 0f;
	}



	// Update is called once per frame
	void Update ()
	{

		//Debug.Log (shotSpawnsIndex);
		
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (shotSpawnsIndex == 0) {
				Instantiate (shot, shotSpawn [0].position, shotSpawn [0].rotation);

			}
				

			if (shotSpawnsIndex == 1) {
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
			}

			if (shotSpawnsIndex == 2) {
				Instantiate (shot, shotSpawn [0].position, shotSpawn [0].rotation);
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
			}

			if (shotSpawnsIndex == 3) {
				Instantiate (shot, shotSpawn [0].position, shotSpawn [0].rotation);
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
				Instantiate (shot, shotSpawn [3].transform.position, shotSpawn [3].transform.rotation);
			}

			if (shotSpawnsIndex >= 4) {
				Instantiate (shot, shotSpawn [0].position, shotSpawn [0].rotation);
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
				Instantiate (shot, shotSpawn [3].transform.position, shotSpawn [3].transform.rotation);
				Instantiate (shot, shotSpawn [4].transform.position, shotSpawn [4].transform.rotation);
			}


			audSrc.Play ();
		}

		if (Input.GetAxisRaw ("Vertical") > 0 || Input.GetAxisRaw ("Vertical") < 0) {
			mb.blurAmount = 0.7f;	
		} else {
			mb.blurAmount = 0f;
		}
			

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

	}
}
