using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour {
	//state로 따로 관리
	//public enum MonsterState { Idle, Roamingstate, Chasing, Attack, Runaway, Die } //배회,추격,공격,도망,쥬금
	//public MonsterMove.MonsterState monsterstate; 
	public bool Chase; //플레이어추격여부


	public int MonsterHP;
	public float attackPower;
	public float speed; //이동속도
	public GameObject Player;
	public float lookrange; // 플레이어감지범위
	public float LookAngle; // 시야 각도
	public float attackrange; // 공격가능거리

	public float StartMoveTime;
	public float MaxMoveTime;
	public float MoveableTime;
	//public 
	public Renderer _renderer;
	bool one = false;
	/*
	int _MonsterHP;
	float _attackPower;
	float _speed; //이동속도
	float _lookrange; // 플레이어감지범위
	float _LookAngle; // 시야 각도
	float _attackrange; // 공격가능거리
*/

	Tanmak tan;

	public enum Monster타입 { 근거리추격, 원거리, 도망형, 은신형}



	private Vector3 vecSpawnPos; //해당몬스터의생성위치
	private Vector3 vecMovePos;// 해당 몬스터의 이동지점
	public float random;//몬스터가랜덤으로움직이는정도

	//public GameObject bullet;
	//public float oneShoting;
	//public float bulletspeed;
	//public float nextbul;


	// Use this for initialization
	void Start () {
		//Chase = false;
		Player = GameObject.FindGameObjectWithTag ("Player");
		//Player = GameObject.Find ("Player");
		vecSpawnPos = transform.position;
		StartCoroutine (RoamingTimer (1));
		tan = GetComponent<Tanmak> ();
		if (_renderer != null)
		{
			_renderer = GetComponent<Renderer> ();
		}
		else
		{
			_renderer = null;
		}
		_renderer = GetComponent<Renderer> ();
	}

	IEnumerator Fadein(){
		if (one == false)
		{
			yield return new WaitForSeconds (1f);
			for (float i = 1f; i >= 0; i -= 0.01f)
			{
				Color colr = new Vector4 (1, 1, 1, i);
				_renderer.material.color = colr;
				yield return 0;
			}
		}
		else
		{

		}
	}
	private float Getangle(float x1, float y1, float x2, float y2)
	{

		float dx = x2 - x1;
		float dy = y2 - y1;

		float radia = Mathf.Atan2 (dx, dy);
		float degree = radia * Mathf.Rad2Deg;

		return degree;
	}

	public void Move(){ //플레이어추격
		

		Vector3 Dir = Player.transform.position - transform.position;

		if (Vector2.Distance (Player.transform.position, transform.position) >= attackrange)
		{
			if (StartMoveTime < MoveableTime)
			{
				transform.eulerAngles = new Vector3 (0, 0, -Getangle (transform.position.x, transform.position.y, Player.transform.position.x, Player.transform.position.y));
				//transform.Translate (Vector3.forward * Time.deltaTime * speed, Space.World);
				transform.position += Dir / (300 / speed);
				//tan.StartCoroutine (tan.ChaseTanmak ());
			}
			else
			{
				transform.eulerAngles = new Vector3 (0, 0, -Getangle (transform.position.x, transform.position.y, Player.transform.position.x, Player.transform.position.y));
			}

		}
		else
		{
			transform.eulerAngles = new Vector3(0,0,-Getangle(transform.position.x, transform.position.y, Player.transform.position.x, Player.transform.position.y));
		}


	}

	public void Roaming(){
		
		Vector3 Dir = vecMovePos - transform.position;
		//transform.LookAt (LookPos);
		if (Vector2.Distance (vecMovePos, transform.position) >= 0.21f)
		{
			if (StartMoveTime < MoveableTime)
			{
				//transform.Translate (Vector3.forward * Time.deltaTime * speed, Space.World);
				transform.eulerAngles = new Vector3 (0, 0, -Getangle (transform.position.x, transform.position.y, vecMovePos.x, vecMovePos.y));
				transform.position += Dir / (300 / speed);

			}
			else
			{

			}

		}
		else
		{
			
			//StartCoroutine (RayTan ());
		//monsterstate = MonsterState.Idle;
		}
	}

	IEnumerator RoamingTimer(float time){

		yield return new WaitForSeconds (time);
		vecMovePos = new Vector3 (vecSpawnPos.x + Random.Range (-random, random), vecSpawnPos.y + Random.Range (-random, random), transform.position.z) ;
		StartCoroutine (RoamingTimer (5));
	}

	public void Attack(){

	}







	public void stateCheak(){

		if (Player != null)
		{
			
			if (Vector2.Distance (Player.transform.position, transform.position) <= lookrange)
			{
				//monsterstate = MonsterState.Chasing;
				Move ();
				Chase = true;
			}
			else
			{
				//monsterstate = MonsterState.Roamingstate;
				Roaming ();
				Chase = false;
			}
			/*
		if (Chase == true)
		{
			//Move ();
		}
		else
		{
			//Roaming ();
		}*/
		}
		else
		{
			Roaming ();
			Chase = false;
		}

	}
	
	// Update is called once per frame
	void Update () {

		stateCheak ();
		StartMoveTime += Time.deltaTime;
		if (StartMoveTime >= MaxMoveTime)
		{
			StartMoveTime = 0;
		}

		if (MonsterHP <= 0)
		{
			MonsterHP = 0;
			//tan.StopCoroutine (tan.탄쏘기 ());
			//attackrange = 0;
			tan._attackRange = 0;
			StartCoroutine (Fadein ());
			Destroy (gameObject, 5f);
			enabled = false;
		}

	}
}
