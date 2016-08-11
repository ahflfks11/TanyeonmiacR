using UnityEngine;
using System.Collections;

public class PlayerCreate : MonoBehaviour {

	SocketCreate socket;

	// Use this for initialization
	void Start () {
		socket = GameObject.Find ("ClientSocket").GetComponent<SocketCreate> ();
		Instantiate (Resources.Load ("Idle_1") as GameObject, transform.position, transform.rotation);
		GameObject.Find ("Idle_1(Clone)").gameObject.name = socket._myCharacter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
