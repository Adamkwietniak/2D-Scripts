using UnityEngine;
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
	//[HideInInspector] public int shotSpawnIndex = 0;
	public float fireRate;
	// ile strzałów
	private AudioSource audSrc;
	private float nextFire;
	//PowerUpScript pus;
	[HideInInspector]public bool stopFirstSpawn;
	[HideInInspector]public int shotSpawnsIndex;




	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();	
		audSrc = GetComponent<AudioSource> ();
		shotSpawnsIndex = 0;


	}
	
	// Update is called once per frame
	void Update ()
	{


		
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (stopFirstSpawn == false /*pus.shotSpawnsIndex == 0 || pus.shotSpawnsIndex == 2*/)
				Instantiate (shot, shotSpawn [0].position, shotSpawn [0].rotation);

			if (shotSpawnsIndex == 1) {
				stopFirstSpawn = true;
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
			}

			if (shotSpawnsIndex == 2) {
				stopFirstSpawn = false;
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
			}

			if (shotSpawnsIndex == 3) {
				stopFirstSpawn = false;
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
				Instantiate (shot, shotSpawn [3].transform.position, shotSpawn [3].transform.rotation);
			}

			if (shotSpawnsIndex >= 4) {
				stopFirstSpawn = false;
				Instantiate (shot, shotSpawn [1].transform.position, shotSpawn [1].transform.rotation);
				Instantiate (shot, shotSpawn [2].transform.position, shotSpawn [2].transform.rotation);
				Instantiate (shot, shotSpawn [3].transform.position, shotSpawn [3].transform.rotation);
				Instantiate (shot, shotSpawn [4].transform.position, shotSpawn [4].transform.rotation);
			}


			audSrc.Play ();
		}

		/*if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
		{
			if ((Time.time - lastTimeTap) < tapSpeed) 
			{
				//rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -dodge);
				//player.GetComponent<Transform>().RotateAround(Vector3.zero, axis, angle * Time.deltaTime / time);
				//player.transform.Rotate(Vector3.up * Time.deltaTime * speed * -30f);
				//player.transform.Rotate(Vector3.forward * 0.5f * Time.deltaTime);

				//dodgeAnim.enabled = true;
				//dodgeAnim.SetBool ("Dodge", true);


			}
			lastTimeTap = Time.time;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) 
		{
			if ((Time.time - lastTimeTap) < tapSpeed) 
			{
				//rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -dodge);
			}
			lastTimeTap = Time.time;
		}*/

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
