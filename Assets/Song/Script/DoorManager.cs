using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{

	public GameObject openImage;
	public bool up, down, left, right;
	public int SceneNumber;


	private PlayerCtrl player;
    private MapInformation mapInfo;

	private bool isOpen;
	private int mapNum;

	private AudioSource audioSource;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        mapInfo = GameObject.Find("MapInfo").GetComponent<MapInformation>();

		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if(isOpen)
		{
			DoorState();
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			isOpen = true;
		}

	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag=="Player")
		{

			isOpen = false;
		}
	}

	void DoorState()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!openImage.activeSelf)
			{
				openImage.SetActive(true);
				audioSource.Play();
				DontDestroyOnLoad(player);
				MoveScene();
			}
			else
			{
				openImage.SetActive(false);
			}
		}
	}


	void MoveScene()
	{
		if(up || down)
		{
            if ((MapInformation.up && up) || (MapInformation.down && down))
            {
                mapNum = MapInformation.prevMap;
            }
            else
            {
                mapNum = Random.Range(3, 10);

                while (mapNum == mapInfo.sceneNum)
                {
                    Debug.Log(mapNum);
                    mapNum = Random.Range(3, 10);
                }
            }
		}
		else if(left || right)
		{
            if ((MapInformation.left && left) || (MapInformation.right && right))
            {
                mapNum = MapInformation.prevMap;
            }

            else
            {
                mapNum = Random.Range(6, 16);

                while (mapNum == mapInfo.sceneNum)
                {
                    Debug.Log(mapNum);
                    mapNum = Random.Range(6, 16);
                }
            }
		}

        StartCoroutine("SceneLoading");

    }

	IEnumerator SceneLoading()
	{
        yield return new WaitForSeconds(1.5f);
        mapInfo.DoorFalse();
        DataSend();
		SceneManager.LoadScene(mapNum);
	}

    void DataSend()
	{
        MapInformation.prevMap = mapInfo.sceneNum;

        if (up)
        {
            PlayerPosMgr.StatusPos = 1;
            MapInformation.down = true;
        }
        else if (down)
        {
            PlayerPosMgr.StatusPos = 2;
            MapInformation.up = true;
        }
        else if (left)
        {
            PlayerPosMgr.StatusPos = 3;
            MapInformation.right = true;
        }
        else if (right)
        {
            PlayerPosMgr.StatusPos = 4;
            MapInformation.left = true;
        }

	}
}
