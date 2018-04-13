using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class howtoplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
			SceneManager.LoadScene("menu");
	}
}
