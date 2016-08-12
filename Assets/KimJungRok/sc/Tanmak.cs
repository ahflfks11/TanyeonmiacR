using UnityEngine;
using System.Collections;

public class Tanmak : MonoBehaviour {


	public enum 어떤탄 { 직선탄, 추격탄, 원형탄, 지연탄, 무더기탄, 확산탄}
	public Tanmak.어떤탄 어떻게쏠까;

	public GameObject bullet;
	public float oneShoting;
	public float speed;
	public float nextbul;

	GameObject Player;

	public float startAttackTime;
	public float MaxAttackTime;
	public float AttackableTime_max5;
	public float FireRadicalAngle;

	MonsterMove AttackRange;
	public float _attackRange;

	// Use this for initialization
	void Start () {
		//StartCoroutine (Tanmakbalsa());

		Player = GameObject.Find ("Player");
		//StartCoroutine(ChaseTanmak());
		StartCoroutine(탄쏘기());
		AttackRange = GetComponent<MonsterMove> ();

		if (AttackRange != null)
		{
			_attackRange = AttackRange.lookrange;
		}
		else
		{
			_attackRange = 99;
		}

	}
	//if (Vector2.Distance (Player.transform.position, transform.position) <= _attackRange){

	public IEnumerator 탄쏘기(){
		if (어떻게쏠까 == 어떤탄.확산탄)
		{
			float angle = 360 / oneShoting;

			do
			{
				for (int i = 0; i < oneShoting; i++)
				{
					if (Player != null){

						if (Vector2.Distance (Player.transform.position, transform.position) <= _attackRange){
							if (startAttackTime < AttackableTime_max5) {
								GameObject obj;
								obj = (GameObject)Instantiate (bullet, transform.position, transform.rotation);

								obj.GetComponent<Rigidbody2D>().AddForce (new Vector2 (speed * Mathf.Cos (Mathf.PI * 2 * i / oneShoting),
									speed * Mathf.Sin (Mathf.PI * i * 2 / oneShoting)));

								obj.transform.Rotate (new Vector3 (0f, 0f, 360 * i / oneShoting - 90));
							}
						}
					}
				}
				yield return new WaitForSeconds (nextbul);
			}while(true);
			/*
			float angle = 360 / oneShoting;

			do
			{
				for (int i = 0; i < oneShoting; i++)
				{
					GameObject obj;
					obj = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);


					obj.GetComponent<Rigidbody2D>().AddForce (new Vector2 (speed * Mathf.Cos (Mathf.PI * 2 * i / oneShoting),
						speed * Mathf.Sin (Mathf.PI * i * 2 / oneShoting)));

					obj.transform.Rotate (new Vector3 (0f, 0f, 360 * i / oneShoting - 90));
				}
			yield return new WaitForSeconds (nextbul);
					
			} while(true);*/

		}
		if (어떻게쏠까 == 어떤탄.직선탄){
			do
			{
				for (int i = 0; i < oneShoting; i++)
				{			if (Player != null){


						if (Vector2.Distance (Player.transform.position, transform.position) <= _attackRange){
							if (startAttackTime < AttackableTime_max5) {
								GameObject obj;
								Rigidbody2D temp;
								obj = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
								temp = obj.GetComponent<Rigidbody2D> ();
								temp.AddForce(transform.up * speed);
								//yield return new WaitForSeconds (0.3f);
								//temp.AddForce (transform.up * speed * -42f);
								//temp.AddForce (* speed);
							}
						}
					}
				}
				yield return new WaitForSeconds (nextbul);
			} while(true);
		}

		if (어떻게쏠까 == 어떤탄.추격탄)
		{
			do
			{			
				if (Player != null){


					Vector2 vec2PlayerPosition = new Vector2 (Player.transform.position.x, Player.transform.position.y);
					GameObject obj;

					Rigidbody2D temp;
					float digree;

					if (startAttackTime < AttackableTime_max5)
					{
						obj = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);

						temp = obj.GetComponent<Rigidbody2D> ();

						Vector2 ToPlayerDir = vec2PlayerPosition - new Vector2 (obj.transform.position.x, obj.transform.position.y);

						temp.AddForce (ToPlayerDir.normalized * speed);



						digree = Mathf.Atan2 (obj.transform.position.y - Player.transform.position.y,
							obj.transform.position.x - Player.transform.position.x) * 180f / Mathf.PI;
					}
					yield return new WaitForSeconds (nextbul);
					StartCoroutine(탄쏘기());
				}
			} while(true);

		}
		if (어떻게쏠까 == 어떤탄.무더기탄)
		{


			do
			{
				for (int i = 0; i < oneShoting; i++)
				{			if (Player != null){


						if (Vector2.Distance (Player.transform.position, transform.position) <= _attackRange){
							if (startAttackTime < AttackableTime_max5) {
								Vector2 RandomAngle = new Vector2(Random.Range(-FireRadicalAngle/2, FireRadicalAngle/2), Random.Range(-FireRadicalAngle/2, FireRadicalAngle/2));
								GameObject obj;
								Rigidbody2D temp;
								//obj = (GameObject)Instantiate (bullet, transform.position, new Quaternion(0f,0f,-1 * ( transform.rotation.z + Random.Range(-FireRadicalAngle/2,FireRadicalAngle/2)), 0));
								obj = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
								//(0f,0f, Random.Range(-FireRadicalAngle/2,FireRadicalAngle/2)
								temp = obj.GetComponent<Rigidbody2D> ();
								//temp.AddForce(1 + Random.Range(-FireRadicalAngle/2, FireRadicalAngle/2));
								temp.AddForce(RandomAngle * speed);
								//temp.AddForce (* speed);
							}
						}
					}
				}
				yield return new WaitForSeconds (nextbul);
			} while(true);

		}
		if (어떻게쏠까 == 어떤탄.원형탄)
		{
			do
			{
				for (int i = 0; i < oneShoting; i++)
				{
					if (Player != null){


						if (Vector2.Distance (Player.transform.position, transform.position) <= _attackRange){
							if (startAttackTime < AttackableTime_max5) {
								Vector2 RandomAngle = new Vector2(Random.Range(-FireRadicalAngle/2, FireRadicalAngle/2), Random.Range(-FireRadicalAngle/2, FireRadicalAngle/2));
								GameObject obj;
								Rigidbody2D temp;
								//obj = (GameObject)Instantiate (bullet, transform.position, new Quaternion(0f,0f,-1 * ( transform.rotation.z + Random.Range(-FireRadicalAngle/2,FireRadicalAngle/2)), 0));
								obj = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
								//(0f,0f, Random.Range(-FireRadicalAngle/2,FireRadicalAngle/2)
								temp = obj.GetComponent<Rigidbody2D> ();
								//temp.AddForce(1 + Random.Range(-FireRadicalAngle/2, FireRadicalAngle/2));
								temp.AddForce(RandomAngle.normalized * speed);

								//temp.AddForce (* speed);
							}
						}

					}
				}
				yield return new WaitForSeconds (nextbul);
			} while(true);


		}
	}


	/*
	IEnumerator Tanmakbalsa()
	{
		


	}*/






	// Update is called once per frame
	void Update () {
		startAttackTime += Time.deltaTime;
		if (startAttackTime >= MaxAttackTime)
		{
			startAttackTime = 0;
		}

	}
}
