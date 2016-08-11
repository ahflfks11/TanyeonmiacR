using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{

    public GameObject openImage;
    public bool up, down, left, right;
    public int SceneNumber;

    private PlayerCtrl player;
    private bool isOpen;
    private int mapNum;

    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
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
            Debug.Log("상하");
            mapNum = Random.Range(0, 6);

            
            while(mapNum==SceneNumber)
            {
                Debug.Log(mapNum);
                mapNum = Random.Range(0, 6);
            }
        }
        else if(left || right)
        {
            Debug.Log("좌우");
            mapNum = Random.Range(3, 10);

            while (mapNum == SceneNumber)
            {
                Debug.Log(mapNum);
                mapNum = Random.Range(3, 10);
            }
        }

        StartCoroutine("SceneLoading");
    }

    IEnumerator SceneLoading()
    {
        Debug.Log("씬 이동 >> " + mapNum);
        yield return new WaitForSeconds(1.5f);
        DataSend();
        SceneManager.LoadScene(mapNum);
    }

    void DataSend()
    {
        if(up)
            PlayerPosMgr.StatusPos = 1;
        else if(down)       
            PlayerPosMgr.StatusPos = 2;        
        else if(left)
            PlayerPosMgr.StatusPos = 3;
        else if(right)
            PlayerPosMgr.StatusPos = 4;
    }
}
