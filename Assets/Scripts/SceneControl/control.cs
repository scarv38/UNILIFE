using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour {

	public void ChangeScene()
	{
		SceneManager.LoadScene ("main");
	}

	public void HowToPlay()
	{
		SceneManager.LoadScene ("howtoplay");
	}
}
