using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues; // there is a boundary in the game, so that it can not use "spawnPosition" directly.
	public int hazardCount;     // so we create a Vector3 object to restrict the value !

	public float spawnWait; // to hold on wait time value
	public float startWait;
	public float waveWait;	
	public float endingSceneWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	//public GUIText gameWinText;

	public bool isGameWin;
	private bool isGameOver; //flag to check if game is over
	private bool isRestart;  //flag to check if game needs restart
	private int score;
	public int currentHealth; //to indicate health condition
	public int bossCurrentHealth; // life date about boss

	public GameObject healthBar;
	private GameObject[] healthElement;
	public Transform healthBarDisplay;
	
	void Start()
	{
		isGameOver = false;
		isRestart = false;
		isGameWin = false;

		restartText.text = "";
		gameOverText.text = "";
		//gameWinText.text = "";


		score = 0;

		UpdateScore ();

		StartCoroutine(SpawnWaves ());

		for (int i = 0; i < currentHealth; i++)
		{
			GameObject healthBarUI = Instantiate  //in this loop, notice the part of vector3, it is used the transform of healthBarDisplay!!!!
				(
				  healthBar, 
				  new Vector3(i * 0.8f + healthBarDisplay.position.x, 0.0f, healthBarDisplay.position.z), //cause this position take advantage of healthBarDisplay directly, so you need to notice that, it must be from position ()
				  Quaternion.identity
				) as GameObject;
			healthBarUI.transform.parent = healthBarDisplay;
		}
	}

	void Update ()
	{
		if (isRestart) 
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel("Title");
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);  //give user time to get ready

		while (true) 
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];//array
				Vector3 spawnPosition = new Vector3
					(
						Random.Range (-spawnValues.x, spawnValues.x), 
						spawnValues.y, 
						spawnValues.z
					);
				//create objects randomly based on "range"
				Quaternion spawnRotation = Quaternion.identity;  // no rotation at all
				Instantiate (hazard, spawnPosition, spawnRotation);

				if(isGameOver)  //if break it will out of for 
				{
				   break;
				}

				if(isGameWin)
				{
					break;
				}

				yield return new WaitForSeconds (spawnWait); //wait until the other asteroid comes out
			}
			//yield return new WaitForSeconds(waveWait);

			if(isGameOver)
			{
				restartText.text = "Press ' R ' to Restart";
				isRestart = true;
				break;
			}

			if(isGameWin)
			{
				break;
			}

			yield return new WaitForSeconds(waveWait);

		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "GAME  OVER";
		isGameOver = true;
	}
	 
	public void HealthControl()
	{
		currentHealth--;
	}

	public void BossHealthControl()
	{
		bossCurrentHealth--;
	}

	public void Damaged() //the controller of icon disappearance
	{	
		healthElement = GameObject.FindGameObjectsWithTag("Health"); 
		Destroy(healthElement[healthElement.Length-1]);
	}

	public void GameWin()
	{
//		gameOverText.text = " C o n g r a t u l a t i o ns ! ";
//		gameOverText.color = new Color(1.0f, 0.25f, 0.25f, 1.0f);  //Constructor of Color class takes float parameters from 0 to 1
//		isGameOver = true;
		isGameWin = true;
		StartCoroutine (Win());

	}

	IEnumerator Win()
	{
		yield return new WaitForSeconds (endingSceneWait);
		Application.LoadLevel ("Winning");
	}
}
