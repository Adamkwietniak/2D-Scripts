using UnityEngine;
using System.Collections;

public class BlinkingInterfaceScript : MonoBehaviour
{

	private GUIText restartText;

	// Use this for initialization
	void Start ()
	{

		restartText = GetComponent <GUIText> ();
		StartBlinking ();
	
	}

	IEnumerator Blink ()
	{
		while (true) {
			switch (restartText.color.a.ToString ()) {
			case "0": 
				restartText.color = new Color (restartText.color.r, restartText.color.g, restartText.color.b, 1);
				yield return new WaitForSeconds (0.5f);
				break;
			case "1":
				restartText.color = new Color (restartText.color.r, restartText.color.g, restartText.color.b, 0);
				yield return new WaitForSeconds (0.5f);
				break;
			}
		}
	}

	public void StartBlinking ()
	{
		StopAllCoroutines ();
		StartCoroutine ("Blink");
	}

	void StopBlining ()
	{
		StopAllCoroutines ();
	}
}
