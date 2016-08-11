using UnityEngine;
using System.Collections;

public class BulletDelete : MonoBehaviour {


	// Use this for initialization
	public float speed;
	public Rigidbody2D rigid;
	//public int BulletDamage; //피격시플레이어가입는공격력
	//public GameObject bullet;
	public float DesTime;
	public GameObject Player;



	//public GameObject effect;

	// Use this for initialization
	void Start () {
		//bullet = GameObject.FindGameObjectWithTag("bullet");
		rigid = GetComponent<Rigidbody2D> ();
		//rigid.AddForce (transform.forward * speed);
		//rigid.velocity = transform.forward * speed;
		//rigid.AddForce (new Vector2(+300.0f, 500.0f));
		rigid.AddForce (transform.up * 100f * speed);

		Player = GameObject.FindGameObjectWithTag ("Player");

	}




	// Update is called once per frame
	void Update () {
		Destroy (gameObject, DesTime);
	}
}