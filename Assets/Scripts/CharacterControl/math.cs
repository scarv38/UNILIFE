using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class math : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if (transform.position.x < -4f || transform.position.x > 4f || transform.position.y > 6.85f || transform.position.y < -6.85f)
			Destroy (gameObject);

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") 
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-100f*Time.deltaTime, 0);

		if (coll.gameObject.tag == "Enemy")
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), coll.gameObject.GetComponent<Collider2D> ());

	}
}
