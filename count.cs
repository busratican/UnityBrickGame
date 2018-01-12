using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class count : MonoBehaviour {

	public Text count_text;
	// Use this for initialization
	float timeLeft = 3;

	IEnumerator MyLoadLevel(float delay, int level)
	{
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(level);
	}
	
	


	void Update()
	{
		timeLeft -= Time.deltaTime;
		count_text.text = ((int)timeLeft).ToString();
	    
		if (timeLeft < 0) {
			count_text.text = "GO!";
			StartCoroutine(MyLoadLevel(1.0f,1));
		}
	}


}
