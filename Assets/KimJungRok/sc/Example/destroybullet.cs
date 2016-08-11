using UnityEngine;
using System.Collections;

public class destroybullet : MonoBehaviour {
	public float DesTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, DesTime);	


	}
}
