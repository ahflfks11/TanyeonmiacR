using UnityEngine;
using System.Collections;

public class gravitycontrol : MonoBehaviour {

	Rigidbody2D rig;
	float rest;
	public float gravityfall;
	public float speed;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
		//rig.AddForce (transform.up * 100f * speed);

	}
	
	// Update is called once per frame
	void Update () {
		rest += Time.deltaTime;
		if (rest > gravityfall)
		{
			//rest = -gravityfall;
			rest = 0;
		}

		if (rest < gravityfall / 2)
			rig.gravityScale = 1;
		else
		{
			rig.gravityScale = -1;
		}

	
	}
}
