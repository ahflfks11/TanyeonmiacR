using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class KeyWordList : MonoBehaviour {

	public int DiceNum01;
	public List<string> _KSubject;
	public string _Ksub;

	void Start(){
		DiceNum01 = Random.Range (0, 7);
		KSubSelect ();
	}

	void KSubSelect(){
		if (DiceNum01 == 0)
			_Ksub = "누군가가";
		if (DiceNum01 == 1)
			_Ksub = "내가";
		if (DiceNum01 == 2)
			_Ksub = "친구가";
		if (DiceNum01 == 3)
			_Ksub = "신장180cm의 고등어가";
		if (DiceNum01 == 4)
			_Ksub = "이웃집 형이 기르는 강아지가";
		if (DiceNum01 == 5)
			_Ksub = "시장 아주머니가";
		if (DiceNum01 == 6)
			_Ksub = "군부대 전방을 뛰어다니는 고라니가";
		
	}

}
