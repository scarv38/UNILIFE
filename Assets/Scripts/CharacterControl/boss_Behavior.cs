using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_Behavior : MonoBehaviour {

	public int health = 5;
	public GameObject bullet;
	int frame = 0;
	public float fireRate;

	float xs,ys;
	void Start()
	{
		xs = transform.position.x;
		ys = transform.position.y;

		int clr = Random.Range (0, 5);

		switch (clr) 
		{
		case 0:
			GetComponent<SpriteRenderer> ().color = new Color (255, 255, 0);
			break;
		case 1:
			GetComponent<SpriteRenderer> ().color = new Color (0, 255, 246);
			break;
		case 2:
			GetComponent<SpriteRenderer> ().color = new Color (229, 0, 255);
			break;
		case 3:
			GetComponent<SpriteRenderer> ().color = new Color (63, 255, 0);
			break;
		case 4:
			break;
		}

	}

	public float amplitudeX = 4.0f;
	public float amplitudeY = 4.0f;
	public float omegaX = 1.0f;
	public float omegaY = 2.0f;
	float index;

	void Update()
	{
		if (Time.timeScale > 0) {
			if (health <= 0) {
				ControlEnemy.isBoss = false;
				Destroy (this.gameObject);
			}

			Move ();
			//StartCoroutine (Shoot (fireRate));

			if (frame == (int) (fireRate*60) ) {
				frame = 0;
				GameObject obj = (GameObject)Instantiate (bullet);
				obj.transform.position = new Vector2 (transform.position.x, transform.position.y - 1.25f);
			}


			frame++;
		}
	}

	void Move()
	{
		index += Time.deltaTime;
		float x = xs + amplitudeX*Mathf.Cos (omegaX*index);
		float y = ys + Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
		transform.localPosition= new Vector3(x,y,0);
	}
		
	IEnumerator Shoot(float rate)
	{
		GameObject obj = (GameObject)Instantiate (bullet);
		obj.transform.position = new Vector2 (transform.position.x, transform.position.y - 1.25f);

		yield return new WaitForSeconds (rate);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Deflect") {
			health--;
			StartCoroutine (flash ());
			Debug.Log (health);
		}

		if (coll.gameObject.tag == "Enemy")
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), coll.gameObject.GetComponent<Collider2D> ());

	}

	IEnumerator flash()
	{
		for (int i = 0; i < 3; i++) {
			GetComponent<SpriteRenderer> ().material.color = Color.clear;
			yield return new WaitForSeconds (0.01f);
			GetComponent<SpriteRenderer> ().material.color = Color.white;
		}

	}
}
