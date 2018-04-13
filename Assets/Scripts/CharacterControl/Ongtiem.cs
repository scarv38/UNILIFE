using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ongtiem : MonoBehaviour {

	Rigidbody2D rigi;
	Transform target;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		float d = Vector2.Distance (transform.position, target.transform.position);
		float k =  4.5f/ d;
		Vector2 pos;
		pos.x = (target.transform.position.x - transform.position.x) * k;
		pos.y = (target.transform.position.y - transform.position.y) * k;
		rigi.velocity = pos;
	}

	void FixedUpdate() {
		
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		if (transform.position.y < min.x)
			Destroy (gameObject);

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Line") 
			Destroy (this.gameObject);

		if (coll.gameObject.tag == "Enemy")
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), coll.gameObject.GetComponent<Collider2D> ());

	}
		
}
