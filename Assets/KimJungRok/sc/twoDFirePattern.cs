using UnityEngine;
using System.Collections;

public class twoDFirePattern : MonoBehaviour {

	public enum Pattern { Radical, Ray, SunFlowwer, Rotation }

	public GameObject Bullet1;
	public GameObject FirePoint;
	Transform FirePointTransform;




	public float rotationspeed;


	public float FireRadicalAngle;
	//public float HowLongShootTime;
	public float StartTime;

	//public GameObject Boss;

	public float fps1 = 10;
	//public float fps2 = 10;

	bool isfire = false;

	//public bool RadicalPattern = false;
	//public bool RayPattern = false;
	public twoDFirePattern.Pattern pattern;


	// Use this for initialization
	void Start () {
		StartCoroutine (Shot ());
		FirePointTransform = FirePoint.transform;
		//Bullet = GameObject.FindGameObjectWithTag ("bullet");
		//ShotAngleRange = 9;

		//Boss = GameObject.FindGameObjectWithTag ("Boss");

		isfire = true;

		StartCoroutine (TimeRotation (this.gameObject, 0.01f, rotationspeed));

		//StartTime = 0;
	}

	IEnumerator TimeRotation(GameObject target, float time, float yAngle)
	{
		if (pattern == Pattern.Rotation) {
			while (true) {
				yield return new WaitForSeconds (time);
				target.transform.Rotate (0, 0, yAngle);

				//StartTime -= Time.deltaTime;
				//if (StartTime <= 0f) {
				//	Destroy (gameObject);
				//}
			}
		}
	}

	IEnumerator Shot() {

		//Instantiate (ThisMuzzle, FirePointTransform.position, FirePointTransform.rotation);
		if(pattern == Pattern.Radical){
			//if (RadicalPattern == true) {
			while (true) {
				if (isfire == false) {
					yield return null;
				} else {

					yield return new WaitForSeconds (1 / fps1);
					Instantiate (Bullet1, FirePointTransform.position, FirePointTransform.rotation);
					//Instantiate (Bullet1, Boss.transform.position, Boss.transform.rotation);



					FirePointTransform.rotation = Quaternion.Euler (0, 0, - 180 + (Random.Range (-FireRadicalAngle/2, FireRadicalAngle/2)));

					/*
					StartTime -= Time.deltaTime;
					if (StartTime <= 0f) {
						Destroy (gameObject);
					}
					*/

				}
			}
		}
		if(pattern == Pattern.Ray){
			//if (RayPattern == true) {

			while (true) {
				if (isfire == false) {
					yield return null;

				} else {
					yield return new WaitForSeconds (1 / fps1);
					Instantiate (Bullet1, FirePointTransform.position, FirePointTransform.rotation);

					StartTime -= Time.deltaTime;
					if (StartTime <= 0f) {
						Destroy (gameObject);
					}
				}
			}
		}
		if(pattern == Pattern.SunFlowwer){
			//if (RadicalPattern == true) {
			while (true) {
				if (isfire == false) {
					yield return null;
				} else {
					Instantiate (Bullet1, FirePointTransform.position, FirePointTransform.rotation);
					yield return new WaitForSeconds (1 / fps1);
					FirePointTransform.rotation = Random.rotation; // 전방위 탄막

					StartTime -= Time.deltaTime;
					if (StartTime <= 0f) {
						Destroy (gameObject);
					}
				}
			}
		}


	}
	/*
	void OnTriggerStay(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isfire = true;
		}
	}

	void OnTriggerExit(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isfire = false;
		}
	}*/

}

