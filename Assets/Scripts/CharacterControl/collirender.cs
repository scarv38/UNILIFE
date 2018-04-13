using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collirender : MonoBehaviour {

	// Use this for initialization
	public int LengthMax;
	LineRenderer lineGO;
	public Material mat;
	public float LiveTime;
	LineRenderer linerd;
	public float startwid,endwid;
	int frame;
	bool up = false;
	void Start () {
		frame = 0;
	}

	// Update is called once per frame
	void Update () {

		if (Time.timeScale > 0) 
		{
			if ((Input.GetMouseButtonDown (0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) ) && up == false) 
			{
				lineGO = new GameObject().AddComponent<LineRenderer> ();
				lineGO.gameObject.tag = "Line";
				StartCoroutine (createLine (lineGO));
			}
			else
				frame++;

			if (frame == LiveTime*60 && up == true) 
			{
				Destroy(lineGO.gameObject);
				up = false;
				frame = 0;
			}

		}

	}

	IEnumerator createLine(LineRenderer lineGO)
	{
		lineGO.transform.SetParent (this.transform);
		lineGO.GetComponent<LineRenderer>().material = mat;
		lineGO.GetComponent<LineRenderer> ().startColor = Color.gray;
		lineGO.GetComponent<LineRenderer> ().endColor = Color.gray;


		linerd = lineGO.GetComponent<LineRenderer> ();
		linerd.startWidth = startwid;
		linerd.endWidth = endwid;

		List<Vector3> pos = new List<Vector3> ();
		//Vector3 prev = new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f);

		while ( (Input.GetMouseButton (0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)) && pos.Count < LengthMax) 
		{
			Vector3 mPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,10f);
			//Debug.Log (prev);
		//	if (mPos != prev) {
				frame = 0;
				up = true;
				pos.Add (Camera.main.ScreenToWorldPoint (mPos));
				lineGO.positionCount = pos.Count;

				lineGO.SetPositions (pos.ToArray ());

			//}
			yield return new WaitForSeconds (0.01f);

		}

		if (pos.Count > 0) 
		{
			linerd.useWorldSpace = false;
			lineGO.GetComponent<LineRenderer> ().startColor = Color.yellow;

			lineGO.GetComponent<LineRenderer> ().endColor = Color.yellow;

			List<Vector2> collipos = new List<Vector2>();

			for(int i=0;i<pos.Count;i++)
				collipos.Add(new Vector2(pos[i].x,pos[i].y));

			EdgeCollider2D polycoll = lineGO.gameObject.AddComponent<EdgeCollider2D>();

			polycoll.points = collipos.ToArray();

			polycoll.edgeRadius = 0.04f;
			polycoll.gameObject.AddComponent<Rigidbody2D>();
			polycoll.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
			polycoll.gameObject.GetComponent<Rigidbody2D> ().mass = 5;
		}

/*
		PolygonCollider2D polycoll = lineGO.gameObject.AddComponent<PolygonCollider2D>();

		polycoll.points = collipos.ToArray();

		polycoll.gameObject.AddComponent<Rigidbody2D>();

		for (int j = 0; j < collipos.Count; j++) {
			BoxCollider2D bc = lineGO.gameObject.AddComponent<BoxCollider2D> ();
			Debug.Log (collipos [j]);
			bc.offset = new Vector2 (collipos [j].x, collipos [j].y);
			bc.size = new Vector2 (0.1f, 0.1f);
		}
*/
	}
}
