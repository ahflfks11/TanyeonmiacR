using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public Rigidbody rigid;
	//public int BulletDamage; //피격시플레이어가입는공격력
	//public GameObject bullet;
	public float DesTime;
	public GameObject Player;

	//public GameObject effect;

	// Use this for initialization
	void Start () {
		//bullet = GameObject.FindGameObjectWithTag("bullet");
		rigid = GetComponent<Rigidbody> ();
		rigid.velocity = transform.forward * speed;
        Player = GameObject.FindGameObjectWithTag("Player");


    }


	// Update is called once per frame

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == ("Player")) {
			//playerhp를 깍음
			//PlayerhP -= BulletDamage;
			//Instantiate(effect, transform.position, transform.rotation);
		}
			


	}

	void Update () {		
		Destroy (gameObject, DesTime);
	}

}

