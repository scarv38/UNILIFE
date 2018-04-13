using UnityEngine;
using System.Collections;

public class CameraAdjust : MonoBehaviour {

	void Update () 
	{
		float wid = Screen.width;
		float hei = Screen.height;

		float ratio = Mathf.RoundToInt ((wid / hei) * 100f) / 100f;

		if (ratio == 0.75f)
			ratio = 0.65f;

		gameObject.GetComponent<Camera> ().aspect = ratio;
	}

}
