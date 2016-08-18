using UnityEngine;
using System.Collections;

public class DestroyByTimeScript : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, lifetime);
	}
	

}
