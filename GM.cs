using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	public static int lives = 3;
	public int bricks = 45;
	public int point=0;
	public float resetDelay = 1f;
	public Text livesText;
	public Text pointsText;
	public Text timeText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject enemy;
	public GameObject ball;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;

	public float c_time = 3;

	//public float timeLeft = 10.0f;
	public int highScore=0;


	void Update()
	{
	/*	timeLeft -= Time.deltaTime;
		timeText.text = "Time: " + (int)timeLeft;
		if(timeLeft < 0)
		{
			CheckGameOver();
		}*/
	}

	IEnumerator MyLoadLevel(float delay, int level)
	{
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(level);
	}


	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		    
		Setup();
		
	}
	
	public void Setup()
	{
	
	
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);

	}
	
	void CheckGameOver()
	{
		if(PlayerPrefs.GetInt("Highscore") < point)
			PlayerPrefs.SetInt("Highscore",point);

		if (bricks < 1) {

			youWon.SetActive (true);
			StartCoroutine(MyLoadLevel(1.0f,0));
			Screen.showCursor = true;
           
		}
		
		if (lives < 1) {

			gameOver.SetActive (true);
			StartCoroutine(MyLoadLevel(1.0f,0));
			Screen.showCursor = true;
		}
      
	/*	if (timeLeft < 0) {

			gameOver.SetActive (true);
			if(lives < 1)
			{
				//gameOver.SetActive (true);
				StartCoroutine(MyLoadLevel(1.0f,0));
				Screen.showCursor = true;
			}

			else if(lives > 1) {
				if(PlayerPrefs.GetInt("Highscore") < point)
					PlayerPrefs.SetInt("Highscore",point);

			}

		}*/

	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		StartCoroutine(MyLoadLevel(1.0f,Application.loadedLevel));
	}


	public void LoseLife()
	{
	
	    lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
		point = point + 10;
		pointsText.text = "POINTS: " + point;
		CheckGameOver();
	}

	public void DestroyEnemy()
	{
		Destroy (enemy);
		point = point + 10;
		pointsText.text = "POINTS: " + point;
	}

}