using UnityEngine;
using System.Collections;

public class EvansiveManeveurScript : MonoBehaviour {

	public Vector2 startWait;
	public Vector2 maneveurTime;
	public Vector2 maneveurWait;
	private float targetManeveur;
	public float dodge;
	public float tilt;
	private Rigidbody rb;
	public float smoothing;
	private float currentSpeed;
	public Boundary boundary;
	//private Transform playerTransform;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade ());
		//playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range  (startWait.x, startWait.y));

		while (true) 
		{
			targetManeveur = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			// targetManeveur = playerTransform.x;
			yield return new WaitForSeconds (Random.Range (maneveurTime.x, maneveurTime.y));
			targetManeveur = 0;
			yield return new WaitForSeconds (Random.Range (maneveurWait.x, maneveurWait.y));
		}

	}

	void FixedUpdate () 
	{
		float newManeveur = Mathf.MoveTowards (rb.velocity.x, targetManeveur, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManeveur, 0.0f, currentSpeed);
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x -tilt);
	}
}
