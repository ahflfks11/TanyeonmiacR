using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossPattern : MonoBehaviour {

	public GameObject Boss;
	public float BossHP;
	public List<BossPatternlist> listPattern;
	public List<BossPatternlist> listPattern2;

	public float Pattern2starthp;
	public float Pattern2bosssize;

	//Use this for initalization
	void Start() {
		
		StartCoroutine (BossPatternNum ());
	}
		
	private float bossHp(){
		return GetComponent<MonsterMove> ().MonsterHP;
	}

	IEnumerator BossPatternNum()
	{
		if (BossHP >= Pattern2starthp)
		{
			foreach (BossPatternlist info in listPattern)
			{
				

				if (BossHP < Pattern2starthp)
				{
					break;
				}

				foreach (GameObject obj in info.listObjPattern)
				{
					//Rigidbody2D temp;
					Instantiate (obj, transform.position, transform.rotation);
					//temp = obj.GetComponent<Rigidbody2D> ();
					//temp.transform.parent = this.gameObject.transform;
					//Destroy (obj, info.waitTime);
					//obj.transform.parent = Boss.transform;
				}
				yield return new WaitForSeconds (info.waitTime);
			}

		}
		else if (BossHP < Pattern2starthp)
		{
			transform.localScale = new Vector3 (Pattern2bosssize, Pattern2bosssize, Pattern2bosssize);

			foreach (BossPatternlist info2 in listPattern2)
			{
				if (BossHP < 0f)
				{
					StopCoroutine (BossPatternNum ());
					break;
				}

				foreach (GameObject obj in info2.listObjPattern)
				{
					Instantiate (obj, transform.position, transform.rotation);
					//obj.transform.parent = this.gameObject.transform;
					//Destroy (obj, info2.waitTime);
				}
				yield return new WaitForSeconds (info2.waitTime);
			}
		}
		//yield return new WaitForSeconds(
		if (BossHP <= 0f)
		{
			StopCoroutine (BossPatternNum ());
		}
		else if (BossHP > 0)
		{
			StartCoroutine (BossPatternNum ());
		}
	}

	//Update is called once per frame
	void Update() {
		BossHP = bossHp ();
	}
}
