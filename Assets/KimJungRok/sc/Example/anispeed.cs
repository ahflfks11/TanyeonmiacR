using UnityEngine;
using System.Collections;

public class anispeed : MonoBehaviour {
	Animator animator;

	public float speed = 1;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.speed = speed;
	}
}
