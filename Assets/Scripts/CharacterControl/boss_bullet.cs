using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_bullet : MonoBehaviour {

	Transform target;
	public float speed = 4f;
	Rigidbody2D rigi;
	GameObject _boss = null;
	// Use this for initialization
	void Start () {
		
		this.gameObject.tag = "Bullet";
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		rigi = GetComponent<Rigidbody2D> ();

		Physics2D.IgnoreLayerCollision (10, 10,true); //ignore between bullet

		_boss = GameObject.FindGameObjectWithTag ("Boss");
		if(_boss != null)
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), _boss.GetComponent<Collider2D> ());
		
	}

	// Update is called once per frame
	void Update () {
		
		if (Time.timeScale > 0) {
			

			if (gameObject.tag == "Deflect")
			{
				

			}
				
			//-- Di chuyen ve phia target
			if (gameObject.tag == "Bullet") {
				
				float d = Vector2.Distance (transform.position, target.position);
				float k = speed / d;
				Vector2 pos;
				pos.x = (target.position.x - transform.position.x) * k;
				pos.y = (target.position.y - transform.position.y) * k;
				rigi.velocity = pos;		
			}

		}
	}
		
	void OnCollisionEnter2D(Collision2D coll)
	{
		//Touch Line
		if (coll.gameObject.tag == "Line") {
			this.gameObject.tag = "Deflect";
			rigi.velocity = new Vector2(0,120f*Time.deltaTime);
			rigi.gravityScale = 0;
			GetComponent<SpriteRenderer> ().color = Color.cyan;

			GameObject line = GameObject.FindGameObjectWithTag ("Line");
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), line.GetComponent<Collider2D> ());

			_boss = GameObject.FindGameObjectWithTag ("Boss");
			if(_boss != null)
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), _boss.GetComponent<Collider2D> (),false);

		}

		//Touch Boss (After deflected)
		if (this.gameObject.tag == "Deflect" && coll.gameObject.tag == "Boss")
			Destroy (this.gameObject);

		//Touch Player (Before deflected)
		if (this.gameObject.tag == "Bullet" && coll.gameObject.tag == "Player")
			Destroy (this.gameObject);

		if (coll.gameObject.tag == "Enemy")
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), coll.gameObject.GetComponent<Collider2D> ());
	}

	void Move(Transform target)
	{
		float d = Vector2.Distance (transform.position, target.position);
		float k = speed / d;
		Vector2 pos;
		pos.x = (target.position.x - transform.position.x) * k;
		pos.y = (target.position.y - transform.position.y) * k;
		rigi.velocity = pos;
	}

	void FixedUpdate() {

		if (gameObject.tag == "Deflect" && transform.position.y > 6.85f) 
				Destroy (gameObject);


	}

}
