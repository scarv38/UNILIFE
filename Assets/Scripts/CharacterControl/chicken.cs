using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour {

	float Starting_x;
	float speed = 2f;

	public GameObject bullet;
	public float spawnTime = 1f;
	int frame = 0;
	// Use this for initialization
	void Start () {
		Vector2 pos = transform.position;
		Starting_x = transform.position.x;
		if (Starting_x <= 0)
			Flip ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale > 0) {
			if (Starting_x < 0)
				transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
			else
				transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));

			if (frame == (int) (spawnTime * 60)) {
				GameObject obj = (GameObject)Instantiate (bullet);
				obj.transform.position = transform.position;
				frame = 0;
			}
			frame++;
		}
	}

	void FixedUpdate() {
		
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

//		if (transform.position.y > max.y || transform.position.x > max.x ||
//		    transform.position.x < min.x || transform.position.y < min.y) {
//			Destroy (gameObject);
//		}

		if (Starting_x < 0) {
			
			if (transform.position.x > max.y)
				Destroy (gameObject);
		} else {
			if (transform.position.x < min.y)
				Destroy (gameObject);
		}

	}

	void Flip(){
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D coll){

	}
}
