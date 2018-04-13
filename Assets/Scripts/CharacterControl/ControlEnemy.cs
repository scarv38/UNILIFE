using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour {

    public GameObject[] enemy;
	public GameObject boss;
    public int numberEnemy;
    int type;
	int time;
    public int maxtime; 
	int count = 0;
    int count2 = 0;
	int min = 4;
	int max = 5;
	float spTime = 3f;
    public static bool isBoss = false;

    List<Vector2> tdM1 = new List<Vector2>();
    //List<bool> boolM1 = new List<bool>();

	// Use this for initialization
	void Start () {
        GameObject E = enemy[0];
        SpriteRenderer sp = E.GetComponent<SpriteRenderer>();
        float hei = sp.bounds.size.y;
        tdM1.Add(new Vector2(-3.62f, 1.55f));
        //boolM1.Add(false);
        float y = 1.55f;
        while(y + hei + 0.2f < 4.5f)
        {
            y += hei + 0.2f;
            tdM1.Add(new Vector2(-3.62f, y));
            //boolM1.Add(false);
        }
			
		time = Random.Range (60, 90);
        type = Random.Range(0, numberEnemy);
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (Time.timeScale > 0) {
			if (count2 == maxtime) {
				Boss (spTime);
				count = 0;
				maxtime += Random.Range (2, 5);
				if(spTime > 0.5f)
					spTime -= 0.02f;
				
				if (min > 1) {
					min--;
					max--;
				}
			} else if (!isBoss) {
				if (count == time) {
					Go ();
					time = Random.Range (min*60, max*90);
					type = Random.Range (0, numberEnemy);
					count2++;

					count = 0;
				} else {
					count++;
				}
			}
		}
	}

    void Go()
    {
        switch(type)
        {
		case 0: //gà
                {
                    int td = Random.Range(0, tdM1.Count);
                    int right = Random.Range(0, 2);
                    Vector2 vt = tdM1[td];
                    if (right == 1)
                        vt.x *= -1;
                        
                    GameObject E = (GameObject)Instantiate(enemy[type]);
                    E.transform.position = vt;
                    break; 
                }
		case 1: //toán
			{
				GameObject E = (GameObject)Instantiate (enemy [type]);
				Vector2 pos = new Vector2 (0f, 5.8f);
				E.transform.position = pos;
				break;
			}
		case 2: //kim
			{
				int right = Random.Range (0, 2);
				if (right == 0) {
					/*Ongtiem ak = enemy [type].GetComponent<Ongtiem> ();
					ak.ri = false;*/
					Vector2 pos = new Vector2 (-4f, 3.7f);
					GameObject E = (GameObject)Instantiate (enemy [type]);
					Vector2 scale = E.transform.localScale;
					scale.x *= -1;
					E.transform.localScale = scale;
					E.transform.position = pos;
				} else {
					Vector2 pos = new Vector2 (4f, 3.7f);
					GameObject E = (GameObject)Instantiate (enemy [type]);
					E.transform.position = pos;
				}
				break;
			}
        }
    }

	void Boss(float spTime)
    {
        isBoss = true;
		count2 = 0;
        GameObject E = (GameObject)Instantiate(boss);
		boss_Behavior b = E.GetComponent<boss_Behavior> ();
		b.fireRate = spTime;
        Vector2 pos = E.transform.position;
        pos.x = 0f;
       // pos.y = 3.2f;
        E.transform.position = pos;
    }
}
