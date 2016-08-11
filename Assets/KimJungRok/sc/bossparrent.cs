using UnityEngine;
using System.Collections;

public class bossparrent : MonoBehaviour {
		
	public GameObject Boss;
	// Use this for initialization

	void Start () {
		Boss = GameObject.FindGameObjectWithTag ("Boss");
		transform.parent = Boss.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
