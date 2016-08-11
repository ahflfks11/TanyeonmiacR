using UnityEngine;
using System.Collections;

public class RotationPattern : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (TimeRotation (this.gameObject, 0.01f, 1f));
	}

	IEnumerator TimeRotation(GameObject target, float time, float yAngle)
	{
		while (true) {
			yield return new WaitForSeconds (time);
			target.transform.Rotate (0, yAngle, 0);
		}
	}
	// Update is called once per frame
	void Update () {

	}
}