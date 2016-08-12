using UnityEngine;
using System;
using System.Collections;

public class MapInformation : MonoBehaviour {

    public string mapName;
    public int sceneNum;
    public static int prevMap;
    public static bool up, down, left, right;

    enum SceneNumber {
        grass =3,
        Gray2,
        Gray,
        Gold,
        Purple,
        FourWay,
        Yellow,
        Despair,
        Pink,
        RedWine,
        Green,
        grave,
        Skyblue
    };
	void Start () {
        SceneNumber sceneNumber = (SceneNumber) Enum.Parse(typeof(SceneNumber), mapName);
        sceneNum = (int) sceneNumber;
	}
	
	void Update () {
	
	}

    public void DoorFalse()
    {
        up = down = left = right = false;
    }
}
