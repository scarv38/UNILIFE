using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    Vector2 pos;
    Vector2 start;
    // Use this for initialization
    void Start()
    {
        start = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        pos = transform.position;
        if (pos.x > 13f)
        {
            transform.position = start;
        }
        else
        {
            pos.x += 0.2f;
            transform.position = pos;
        }
	}
}
