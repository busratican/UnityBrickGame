using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	/*int[] points;
	static int i=0;
	public Text pointsText;
	int a=0;
	int h_Score;
	Button hScoreButton;*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void startGame()
	{
		Application.LoadLevel(3);
	}

	public void quitGame()
	{
		Application.Quit ();
	}

	public void highScore()
	{
		Application.LoadLevel(2);
	}



}