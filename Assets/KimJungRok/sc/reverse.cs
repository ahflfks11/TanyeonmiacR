using UnityEngine;
using System.Collections;

public class reverse : MonoBehaviour {


	// Use this for initialization
	public float speed;
	public Rigidbody2D rigid;
	//public int BulletDamage; //피격시플레이어가입는공격력
	//public GameObject bullet;
	public float DesTime;
	public GameObject Player;

	public float revtim;
	public float revpow;
	public bool two;
	public float revtim2;
	public float revpow2;

	//public GameObject effect;
	public IEnumerator Re(){
		if (two == false)
		{
			rigid.AddForce (transform.up * 100f * speed);
			yield return new WaitForSeconds (revtim);
			rigid.AddForce (transform.up * -100f * speed * revpow);
		}
		else
		{
			rigid.AddForce (transform.up * 100f * speed);
			yield return new WaitForSeconds (revtim);
			rigid.AddForce (transform.up * -100f * speed * revpow);
			yield return new WaitForSeconds (revtim2);
			rigid.AddForce (transform.up * -100f * speed * revpow2);
		}
	}

	// Use this for initialization
	void Start () {
		//bullet = GameObject.FindGameObjectWithTag("bullet");
		rigid = GetComponent<Rigidbody2D> ();

		StartCoroutine (Re ());

		Player = GameObject.FindGameObjectWithTag ("Player");
	}




	// Update is called once per frame
	void Update () {
		Destroy (gameObject, DesTime);
	}
}