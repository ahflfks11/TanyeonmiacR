using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float moveSpeed=0.1f;
	GameObject socket;
	//public GameObject player;
	SocketCreate socketClient;

	// Use this for initialization
	void Start () {
		//player = GameObject.Find ("Player");
		socket = GameObject.Find ("Socket");
		socketClient = socket.GetComponent<SocketCreate> ();
	}	
	// Update is called once per frame
	void Update () {
		if (socketClient._value != 0) {
			transform.Translate (Vector2.right * socketClient._value * moveSpeed, Space.World);
		}
	}
}
