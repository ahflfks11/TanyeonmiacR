using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeywordFarming : MonoBehaviour {

	public List<KeyWordList> KSubject;//주어
	public string KObject; //목적어
	public string KAdverb; //부사, 꾸며주는말
	public string Kverb; //동사

	// Use this for initialization
	void Start () {
		
	
	}

	void KSubJectSelect(){
		List<string> KSub01 = new List<string>()
		{
			"",
			"평범한",
			"신장 180cm의",
			"럭셔리한",
			"수산시장의",
			"군부대 전방을 뛰어다니는",
			"못생긴",
			"잘생긴",
			"목이긴",
			"3배빠른",
			"신출귀몰한",
			"대한민국 야스오 장인인",
			"겐지 장인인",
			"곰같은",
			"시속100km의",
			"10살에 곰을 잡은",
			"소름돋는",
			"더위먹은",
			"힘스탯 Max찍은",
			"먹다남은",
			"우주의",
			"형용할 수 없는"
		};
		List<string> KSub02 = new List<string> () {
			"내가",
			"친구가",
			"마오리족이",
			"아주머니가",
			"다람쥐가",
			"고라니가",
			"고등어가",
			"당신이",
			"옆집 형이",
			"이웃집 누나가 기르는 강아지가",
			"도적이",
			"전설의 전사가",
			"법사가"
		};
		List<string> KObj01 = new List<string> () {
			"사과를",
			"고등어를",
			"여름을",
			"더위를",
		};

		List<string> KAdver = new List<string> () {
			"시원하게",
			"열심히",
			"느긋하게",
			"열정적으로",
			"미친듯이",
			"바보처럼",
			"스마트하게",
			"바보같이",
			"그윽한 눈빛과 함께",
			"춤추면서",
			"시속 210km로 달리며",
			"누구보다 빠르게 남들과는 다르게",
			"대국적으로",
			"소중하게"
		};

		List<string> Kver = new List<string> () {
			"먹는",
			"던지는",
			"휘두르는",
			"결혼하는",
			"칼로 베는"
		};


	}

	void WordFusion(){
		//string Result = KSubJectSelect;
			
	}

	// Update is called once per frame
	void Update () {
	
	}
}
