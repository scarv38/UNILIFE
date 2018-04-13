using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convoi : MonoBehaviour {
	Transform target;
	public float speed = 2f;
	Rigidbody2D rigi;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		Vector2 Spos = transform.position;
		float Starting_x = transform.position.x;
		if (Starting_x <= 0)
			Flip ();
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		if (transform.position == target.position) {
			Destroy (this);
			return;
		}

		float d = Vector2.Distance (transform.position, target.transform.position);
		float k = speed / d;
		Vector2 pos;
		pos.x = (target.transform.position.x - transform.position.x) * k;
		pos.y = (target.transform.position.y - transform.position.y) * k;
		rigi.velocity = pos;
	}

	void Flip(){
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Line")
			Destroy (this.gameObject);

		if (coll.gameObject.tag == "Enemy")
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), coll.gameObject.GetComponent<Collider2D> ());
	}
}
