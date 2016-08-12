using UnityEngine;
using System.Collections;

public class Laserbullet : MonoBehaviour {

	public BoxCollider2D box;
	public SpriteRenderer Collor;
	//BoxCollider2D box;
	public bool laserbudlebudle;
	// Use this for initialization
	void Start () {
		//box.GetComponents<BoxCollider2D> ();
		//box.enabled = false;
		StartCoroutine (Laserbalsa ());
	}

	IEnumerator Laserbalsa(){
		//box.size = new Vector2 (0, 0);
		//box.size = new Vector2(0,0);
		Color Origincolor = Collor.material.color;
		Collor.material.color = Color.red;


		box.enabled = false;
		yield return new WaitForSeconds (1f);
		box.enabled = true;
		//box.size = new Vector3 (0.13f, 0.54f);
		transform.localScale = new Vector3 (0.5f, transform.localScale.y, transform.localScale.z);
		yield return new WaitForSeconds (0.5f);
		for (float i = 0.5f; i < 10; i += 0.42f)
		{
			transform.localScale = new Vector3 (i, transform.localScale.y, transform.localScale.z);
			yield return 0;
		}
		laserbudlebudle = true;
		yield return new WaitForSeconds (1f);
		laserbudlebudle = false;

		Collor.material.color = Origincolor;

		for (float i = 10; i >= 0 ; i -= 0.5f)
		{
			transform.localScale = new Vector3 (i, transform.localScale.y, transform.localScale.z);
			yield return 0;
		}
		//Destroy (gameObject);

	}

	// Update is called once per frame
	void Update () {
		if (laserbudlebudle == true)
		{
			transform.localScale =new Vector3(Random.Range(9,11), transform.localScale.y, transform.localScale.z);
		}

	}
}
