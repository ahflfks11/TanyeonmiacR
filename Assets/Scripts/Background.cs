using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public GameObject topSubject;
	public GameObject subject;
	// Use this for initialization
	void Start () {
		int background = Random.Range (0, 8);
		if (background < 4) {
			this.gameObject.SetActive (false);
			topSubject.gameObject.SetActive (false);
			subject.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
