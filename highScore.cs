using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highScore : MonoBehaviour {

	public Text h_scoreText;
	
	// Update is called once per frame
	void Update () {
		h_scoreText.text = "HIGH SCORE\n" + PlayerPrefs.GetInt ("Highscore").ToString();
	}

	public void showHScore()
	{

	}
	public void btn_Back()
	{
		Application.LoadLevel (0);
	}

}
