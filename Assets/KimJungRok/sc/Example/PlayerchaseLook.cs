using UnityEngine;
using System.Collections;

public class PlayerchaseLook : MonoBehaviour {
	
	public Vector3 Dir;
	public GameObject Player;
	//public GameObject ThisMonster;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Dir = Player.transform.position - this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		//this.gameObject.transform.rotation = Quaternion.LookRotation(Dir);
		//this.gameObject.transform.LookAt (Dir);
		this.gameObject.transform.LookAt (Player.transform.position);
	}
}
