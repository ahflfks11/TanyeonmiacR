using UnityEngine;
using System.Collections;

public class Curveshot : MonoBehaviour {

	float time;
	public float maxtime;
	public float roa;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}

	public void move(){
		transform.position += Time.deltaTime * Vector3.right * roa * speed;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		time += Time.deltaTime;
		if (time >= maxtime)
		{
			time = 0;
			roa =  roa * (-1f);
		}

		speed += Time.deltaTime;
		if (speed >= maxtime)
		{
			speed = 0;
		}
	}
}
