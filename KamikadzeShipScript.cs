using UnityEngine;
using System.Collections;

public class KamikadzeShipScript : MonoBehaviour
{

	private Rigidbody rb;
	private float speed;
	public GameObject turbo;
	private AudioSource turboSound;

	// Use this for initialization
	void Start ()
	{
		turbo.SetActive (false);
		speed = -4.0f;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
		Invoke ("Kamikadze", 1);
		turboSound = GetComponent<AudioSource> ();


	}

	void Kamikadze ()
	{
		rb.velocity = transform.forward * -9.0f;
		turboSound.Play ();
		turbo.SetActive (true);
	}


}
