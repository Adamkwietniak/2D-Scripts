using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderBoardScript : MonoBehaviour
{

	public int[] highScores = new int[10];
	string highScoreKey = "HighScore";
	public Text[] highScoreText = new Text[10];
	public InputField inputField;
	public Text[] nameDisplay = new Text[10];
	public GameObject nameDisplayCanvas;


	// Use this for initialization
	public void Start ()
	{
		nameDisplayCanvas.SetActive (false);
	}

	public void TextDisplay (string value)
	{
		for (int i = 0; i < highScores.Length; i++) {
			highScoreKey = "HighScore" + (i + 1).ToString ();
			highScores [i] = PlayerPrefs.GetInt (highScoreKey, 0);
			highScoreText [i].text = "" + highScores [i];
		
	
			value = inputField.text;
			nameDisplay [i].text = value;

			nameDisplayCanvas.SetActive (false);
		}


	}


}
