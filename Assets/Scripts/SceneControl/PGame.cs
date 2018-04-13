using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		isPause = PlayerPrefs.GetInt ("PauseGame", 0);

	}

	int isPause = 0;
	// Update is called once per frame
	void Update () {
	}

	public void Pause()
	{
		if (isPause == 0) {
			Time.timeScale = 0;
			isPause = 1;
		} else {
			isPause = 0;
			Time.timeScale = 1;
		}
	}
}
