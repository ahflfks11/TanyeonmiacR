using UnityEngine;
using System.Collections;

public class PlayerPosMgr : MonoBehaviour {

    private PlayerCtrl player;

    public static int StatusPos; //0 - None, 1-UP->DOWN , 2-DOWN->UP , 3-LEFT->RIGHT, 4-RIGHT->LEFT

    public Vector3[] doorPos = new Vector3[4];


    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }
	
	void Update () {
	    if(StatusPos!=0)
        {
            MovePlayer();
            StatusPos = 0;
        }
	}

    void MovePlayer()
    {
        switch(StatusPos)
        {
            case 1:
                player.transform.position = doorPos[0];

                break;
            case 2:
                player.transform.position = doorPos[1];

                break;
            case 3:
                player.transform.position = doorPos[2];

                break;
            case 4:
                player.transform.position = doorPos[3];

                break;

        }
    }


}
