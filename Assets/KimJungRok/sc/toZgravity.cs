using UnityEngine;
using System.Collections;

public class toZgravity : MonoBehaviour {

	public float Zgravit;
	Rigidbody rig;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 0, Zgravit) * Time.deltaTime);
		rig.AddForce (0, 0, 1);

	}
}
