using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_Behavior : MonoBehaviour {

	// Use this for initialization
	public Text score_text;
	public Text result;
	public static int Score;
	int frame  = 0;
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 9, true);
		Score = PlayerPrefs.GetInt ("PlayerScore",0);
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale > 0) {
			if (frame == 60) {
				frame = 0;
				Score += 1;
			}
			ShowScore ();
			frame++;
		}

	}

	void FixedUpdate()
	{
		ShowScore ();
	}

	void ShowScore()
	{
		score_text.text = Score.ToString ();
		if (Score > PlayerPrefs.GetInt ("PlayerScore"))
			PlayerPrefs.SetInt ("PlayerScore", Score);
		result.text = "/" + PlayerPrefs.GetInt ("PlayerScore").ToString ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "Boss" || coll.gameObject.tag == "Ongtiem") {

			if (Score > PlayerPrefs.GetInt ("PlayerScore"))
				PlayerPrefs.SetInt ("PlayerScore", Score);

			//result.text = "Score: " + Score.ToString () + "\nHScore: " + PlayerPrefs.GetInt ("PlayerScore").ToString ();
			ControlEnemy.isBoss = false;
			SceneManager.LoadScene("menu");
			ControlEnemy.isBoss = false;

		}

	}
}
