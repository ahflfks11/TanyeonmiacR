using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPlayer : MonoBehaviour {

    private PlayerCtrl player;
    private float time = 0f;

	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }
	
	
	void Update () {
        if(Time.time - time > 0.5f)
        {
            DontDestroyOnLoad(player);
            PlayerPosMgr.StatusPos = 0;
            SceneManager.LoadScene("FourWay");
        }
	}
}
