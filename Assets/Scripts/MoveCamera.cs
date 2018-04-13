using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    public GameObject player;
    Vector3 pos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        pos = player.transform.position;
        pos.x += 2.32f;
        pos.y += 4.33f;
        pos.z = -10f;
        transform.position = pos;
	}
}
