using UnityEngine;
using System.Collections;

public class DammagedEvent : MonoBehaviour {

	public SkinnedMeshRenderer Color1;
	//public SkinnedMeshRenderer Color2;

	Color colorOrigin1;
	//Color colorOrigin2;


	//Animator animator;

	int Damaged1or2;

	// Use this for initialization
	void Start () {
		//animator = GetComponent<Animator> ();

		colorOrigin1 = Color1.material.color;
	//	colorOrigin2 = Color2.material.color;

	}
	void OnTriggerEnter (Collider col){

		if (col.gameObject.tag == ("Weapon")) {

			//Debug.Log ("hit");

			StartCoroutine (GIGIGIG ());

			//animation ["1"].speed = 0.1f;

		}
	}

	IEnumerator GIGIGIG(){ // 타격감을위한경직
		//Time.timeScale = 0.05f;
		//animator.speed = 0f;
		Damaged1or2 = Random.Range (-10, 10);

		//Color colorOrigin1 = Color1.material.color;
		//Color colorOrigin2 = Color2.material.color;
		if (Damaged1or2 >= -5) {

			Color1.material.color = Color.red;
		//	Color2.material.color = Color.red;
			transform.position = transform.position + new Vector3 (0.05f, 0, 0.05f);
			//yield return new WaitForSeconds (0.1f);
			yield return new WaitForSeconds (0.05f);


			//Colar1.material.color = Color.Lerp (Color.red, new Color (0, 212f / 255f, 225f / 255f, 255f / 255f), Mathf.PingPong (Time.time, 1));
			//			Color1.material.color = new Color (0, 212f / 255f, 225f / 255f, 255f / 255f);
			//			Color2.material.color = new Color (0, 212f / 255f, 225f / 255f, 255f / 255f);
			transform.position = transform.position + new Vector3 (-0.05f, 0, -0.05f);
		}
		else if (Damaged1or2 < -5) {
			Color1.material.color = Color.black;
		//	Color2.material.color = Color.black;
			transform.position = transform.position + new Vector3 (-0.05f, 0, -0.05f);
			//yield return new WaitForSeconds (0.1f);
			yield return new WaitForSeconds (0.05f);


			//			Color1.material.color = new Color (0, 212f / 255f, 225f / 255f, 255f / 255f);
			//			Color2.material.color = new Color (0, 212f / 255f, 225f / 255f, 255f / 255f);
			transform.position = transform.position + new Vector3 (0.05f, 0, 0.05f);
		}
		//Time.timeScale = 1;
		Color1.material.color = colorOrigin1;
	//	Color2.material.color = colorOrigin2;
		//animator.speed = 1f;

	}
	//00D4FFFF
	// Update is called once per frame
	void Update () {

	}
}
