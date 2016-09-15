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
	public Canvas pauseText;
	public Text playerLifes;
	PlayerControllerTWODScript pctwods;
	public GameObject infoPanel;


	// Use this for initialization
	public void Start ()
	{
		pauseText.enabled = false;
		infoPanel.SetActive (false);
		nameDisplayCanvas.SetActive (false);
		pctwods = FindObjectOfType <PlayerControllerTWODScript> ();

	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape)) {
			pauseText.enabled = !pauseText.enabled;
		}

		if (pauseText.enabled == true) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
			infoPanel.SetActive (false);
		}
		playerLifes.text = "X" + pctwods.shotSpawnsIndex;

	}

	public void TextDisplay (string value)
	{

		
	
		value = inputField.text;
		for (int i = 0; i < highScores.Length; i++) {
			highScoreKey = "HighScore" + (i + 1).ToString ();
			highScores [i] = PlayerPrefs.GetInt (highScoreKey, 0);
			highScoreText [i].text = "" + highScores [i];
			nameDisplay [i].text = value;

		}


		nameDisplayCanvas.SetActive (false);
		


	}

	public void QuitGame ()
	{
		Application.Quit ();
	}

	public void InformationButton ()
	{
		infoPanel.SetActive (true);
	}

	public void BackFromInfoCanvas ()
	{
		infoPanel.SetActive (false);
	}


}
