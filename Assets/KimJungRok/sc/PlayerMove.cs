using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public Vector2 speed = new Vector2 (10, 10);

	//public Vector2 direction = new Vector2 (-1, 0);

	private Vector2 movement;

	//Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () {
		//Game.rigidbody2d = GetComponent<Rigidbody2D>;
		//rigidbody2d = this.gameObject.rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (speed.x * inputX, speed.y * inputY);

	
	}

	void FixedUpdate(){
		//rigidbody2d.velocity = movement;
	}
}
