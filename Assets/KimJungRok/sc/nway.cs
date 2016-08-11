using UnityEngine;
using System.Collections;

public class nway : MonoBehaviour {
	public float time;
	public float maxtime;
	//public float roa;


	public float rotationspeed;
	// Use this for initialization


	void Start () {
		//StartCoroutine (TimeRotation (this.gameObject, 0.01f, rotationspeed));
	
	}

	public void rotation(GameObject target, float yAngle){
		target.transform.Rotate (0, 0, yAngle);
	}

	IEnumerator TimeRotation(GameObject target, float time, float yAngle)
	{
			while (true) {
				yield return new WaitForSeconds (time);
				target.transform.Rotate (0, 0, yAngle);

			}
		}
	
	// Update is called once per frame
	void Update () {
		rotation (this.gameObject, rotationspeed);
		time += Time.deltaTime;
		if (time >= maxtime)
		{
			time = 0;
			rotationspeed =  rotationspeed * (-1f);
		}

	
	}
}
