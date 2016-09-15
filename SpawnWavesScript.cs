using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnWavesScript : MonoBehaviour
{

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCounts;
	private float spawnWait;
	// czas oczekiwania na kolejna fale
	private float spawnStart;
	// zaczyna się fala
	private float waveWait;
	// odstęp miedzy falami
	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText restartText;
	[HideInInspector]public bool gameOver;
	private bool restart;
	[HideInInspector]public int score;
	[HideInInspector]public int[] highScores = new int [10];
	string highScoreKey = "";
	[HideInInspector]public int numberForSpawn;
	public GameObject highscoreTable;
	public GameObject nameDisplayCanvas;
	public Button backButton;
	public Text scoreDiaplay;
	PlayerControllerTWODScript pctwods;
	private int targetScoreToBonus;
	public Text bonusText;




	public bool GetGameOver ()
	{
		return gameOver;
	}


	// Use this for initialization
	void Start ()
	{
		
		score = 0;
		bonusText.enabled = false;
		StartCoroutine (SpawnWaves ());
		UpdateScore ();
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		numberForSpawn = 0;
		spawnWait = 1;
		spawnStart = 2;
		waveWait = 5;
		highscoreTable.SetActive (false);
		pctwods = FindObjectOfType <PlayerControllerTWODScript> ();



	}

	void OnDisable ()
	{

		for (int i = 0; i < highScores.Length; i++) {
			highScoreKey = "HighScore" + (i + 1).ToString ();
			highScores [i] = PlayerPrefs.GetInt (highScoreKey, 0);

			if (score > highScores [i]) {
				PlayerPrefs.SetInt (highScoreKey, score);
				PlayerPrefs.Save ();
				int temp = highScores [i];
				score = temp;
			}
		}
	}



	void Update ()
	{
		if (numberForSpawn == 10) {
			spawnWait = 0.8f;
			spawnStart = 1.5f;
			waveWait = 4f;
			hazardCounts = 4;
		}

		if (numberForSpawn == 35) {
			spawnWait = 0.5f;
			spawnStart = 1f;
			waveWait = 3f;
			hazardCounts = 6;

		}
		if (numberForSpawn == 50) {
			spawnWait = 0.2f;
			spawnStart = 0.5f;
			waveWait = 2.5f;
			hazardCounts = 10;

		}
		if (numberForSpawn == 100) {
			spawnWait = 0.1f;
			spawnStart = 0.1f;
			waveWait = 1f;
			hazardCounts = 12;
		}
		/*Debug.Log (targetScoreToBonus);
		//targetScoreToBonus = score % 100;
		targetScoreToBonus = score % 101;
		if (targetScoreToBonus == 100) {
			bonusText.enabled = true;
			pctwods.shotSpawnsIndex += 1;

			//pctwods.shotSpawnsIndex++;
		}*/

		if (restart == true) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("Scene2D");

			}

		}

		scoreText.text = "Score:" + score.ToString ();

		if (Input.GetKeyDown (KeyCode.C)) {
			PlayerPrefs.DeleteAll ();	
		}




	}



	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (spawnStart);
		while (true) {
			
			for (int i = 0; i < hazardCounts; i++) {

				GameObject hazard = hazards [Random.Range (0, hazards.Length)];

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);


				yield return new WaitForSeconds (spawnWait);
				if (numberForSpawn < 100) {
					numberForSpawn++;
				}
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver == true) {
				highscoreTable.SetActive (true);
				nameDisplayCanvas.SetActive (true);
				scoreDiaplay.text = "You score: " + score;
				restartText.text = "Press R to restart!";
				restart = true;
				break;
			}
		}

	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void BackButton ()
	{
		highscoreTable.SetActive (false);
	}


}
