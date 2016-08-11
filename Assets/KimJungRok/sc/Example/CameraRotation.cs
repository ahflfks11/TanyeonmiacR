using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (TimeRotation (this.gameObject, 0.01f, 1f));
	}

	IEnumerator TimeRotation(GameObject target, float time, float yAngle)
	{
		while (true) {
			yield return new WaitForSeconds (time);
			target.transform.Rotate (0, yAngle, 0);
			target.transform.position = Vector3.Lerp(transform.position, this.transform.position + new Vector3(0,0.01f,0), 10f);


		}
		//yield return new WaitForSeconds (5f);
		//target.transform.position = new Vector3 (0, 0, 0);

	}
	// Update is called once per frame
	void Update () {

	}
}