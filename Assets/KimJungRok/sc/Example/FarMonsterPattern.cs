using UnityEngine;
using System.Collections;

public class FarMonsterPattern : MonoBehaviour {

	NavMeshAgent agent;
	GameObject player; // 플레이어오브젝트
	//public GameObject ThisMonster; //이 몬스터
	//public BoxCollider col;

	public Vector3 Dir;

	public float LookDistan; //시야
	public float attackRange = 30f;
	public GameObject bullet;

	//public Ray ray;


	public float random; //움직이는 랜덤방향

	Animator aniCon;

	int AttackTpyeONEorTwo; //1번공격인지 2번공격인지

	private Vector3 vecSpawnPos; // 몬스터의 생성위치
	private Vector3 vecMovePos;// 해당 몬스터의 이동지점

	public float MonsterMaxHP; //몬스터의 HP
	public float MonsterCurrentHP;
	public GameObject DropItem; //몬스터가 드랍하는 아이템
	public int KillExp; //죽였을시 얻는 경험치
	public float AttackPower; //몬스터의 공격력

	public float AttackColltime = 0.3f; //몬스터가 공격후 플레이어가 대미지 판정을 처리하기까지의 시간
	//public int MoveSpeed; // naviMeshAgent에서 관리하므로 필요 없음
	public bool isChase = false;

	public float Respawntime;
	public GameObject RespawnMonster;

	public float fps = 10;


	bool isfire = false; //원거리공격여부


	// Use this for initialization
	void Start () {
		vecSpawnPos = transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		agent = GetComponent<NavMeshAgent> ();
		aniCon = GetComponent<Animator> ();
		vecMovePos = vecSpawnPos;
		StartCoroutine (RunAway(10));
		StartCoroutine (Fire ());

		enabled = true;

		//col.enabled = false;

		//ray = new Ray (ThisMonster.transform.position, ThisMonster.transform.forward);

	}
	IEnumerator Respawn(float Respawntime){
		yield return new WaitForSeconds (Respawntime);
		Instantiate (RespawnMonster, transform.position, transform.rotation);
	}

	IEnumerator RunAway(float time){

		yield return new WaitForSeconds (time);
		vecMovePos = new Vector3 (vecSpawnPos.x + Random.Range (-random, random), transform.position.y, vecSpawnPos.z + Random.Range (-random, random));
		StartCoroutine (RunAway (10));
	}

	IEnumerator ItemDrop(){
		yield return new WaitForSeconds (1);
	}

	IEnumerator Dammaged(){
		aniCon.SetBool ("IsDammaged", true);
		//MonsterCurrentHP -=  ; // 플레이어의 공격력만큼 깍음
		yield return new WaitForSeconds (0.3f);
		aniCon.SetBool ("IsDammaged", false);
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == ("Weapon")) {
			Debug.Log ("hit");
			StartCoroutine(Dammaged ());

			aniCon.SetBool ("IsDammaged", true);
			//MonsterCurrentHP -=1 ;
		}

	}

	IEnumerator Fire() {
		while (true) {
			if (isfire == false) {
				yield return null;
			} else {
				Instantiate (bullet, transform.position, transform.rotation);
				yield return new WaitForSeconds (1 / fps);
			}
		}
	}
	/*
	void OnTriggerStay(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			agent.Stop ();
			isfire = true;
			//aniCon.SetBool ("IsRun", false);
			aniCon.SetBool ("IsFarAttack", true);
		}
	}*/
	/*
	void OnTriggerExit(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isfire = false;
			agent.Resume ();
		}
	}*/



	// Update is called once per frame
	void Update () {

		Dir = player.transform.position - transform.position;

		if (Vector3.Distance (player.transform.position, transform.position) <= LookDistan) {
			
			isChase = true;

		} else {
			isChase = false;

			agent.SetDestination (vecMovePos);
			aniCon.SetBool ("IsRun", true);
			agent.Resume ();
			if (Vector3.Distance (vecMovePos, transform.position) <= 5) {
				aniCon.SetBool ("IsRun", false);
				aniCon.SetBool ("IsIdle", true);

				agent.Stop (); //idle 모션이다시나오게
				//col.enabled = false;
			}
		}

		if (isChase) {
			//agent.Stop();
			aniCon.SetBool ("IsRun", true);
			agent.SetDestination (player.transform.position);
			agent.Resume ();

			if (Vector3.Distance (player.transform.position, this.transform.position) <= attackRange ){
				aniCon.SetBool ("IsRun", false);
				agent.Stop ();

				isfire = true;
				aniCon.SetBool ("IsFarAttack", true);

				Vector3 vecLookPos = player.transform.position;
				vecLookPos.y = transform.position.y;
				transform.LookAt (vecLookPos);


			} else {
				aniCon.SetBool ("IsRun", true);
				aniCon.SetBool ("IsFarAttack", false);
				isfire = false;
			}



		} else {

			isChase = false;
			isfire = false;
			aniCon.SetBool ("IsFarAttack", false);
			agent.SetDestination (vecMovePos);
			agent.Resume ();

		}


		if (MonsterCurrentHP <= 0){
			//new WaitForSeconds (5f);
			agent.Stop();
			aniCon.SetBool ("IsIdle", false);
			aniCon.SetBool ("IsFarAttack", false);
			aniCon.SetBool ("IsRun", false);
			aniCon.SetBool ("IsDie", true);
			StartCoroutine(Respawn(Respawntime));
			Instantiate (DropItem, transform.position, transform.rotation); // 2페이즈보스생성 실제로는 dropitem에 넣

			enabled = false; // 아이템을 한번만 생성하게
			//NextPattern = Time.time + patternRegTime;
			Destroy(gameObject, 10f);


			//Instantiate (ThisMonster, LivingZone.transform.position, LivingZone.transform.rotation); // 리스폰
			//enabled = false;
		}



	}
}
