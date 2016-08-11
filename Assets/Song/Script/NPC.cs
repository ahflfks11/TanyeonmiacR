using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    public GameObject NPCCommunity;
    public Text characterName;
    public Text characterText;
    public string[] textStr;
    public string[] nameStr;
    public GameObject characterImage;

    private PlayerCtrl player;
    private bool isNearby=false;
    private bool isChating;
    private int count;


    private AudioSource audioSource;
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        audioSource = GetComponent<AudioSource>();
    }

	void Update () {
	    if(isNearby)
        {
            NPCState();
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            Debug.Log("ㅎㅇ");
            isNearby = true;
        }

    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("ㅂㅇ");
            isNearby = false;
        }
    }


    void NPCState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!NPCCommunity.activeSelf)
            {
                NPCCommunity.SetActive(true);
                isChating = true;
                Time.timeScale = 0;
                audioSource.Play();

                characterText.text = textStr[0];
                characterName.text = nameStr[0];
                count = 1;

            }
            else if(isChating)
            {
                if (textStr.Length == 1)
                {
                    count = 0;
                    Time.timeScale = 1;
                    NPCCommunity.SetActive(false);
                }
                else
                {
                    characterText.text = textStr[count];
                    characterName.text = nameStr[count];

                    count++;

                    Debug.Log(count);
                    Debug.Log(textStr.Length);
                    if (textStr.Length == count)
                    {
                        isChating = false;
                    }
                }
                
            }
            else if(!isChating)
            {
                characterText.text = textStr[0];
//                characterImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Characters/Kong_basic") as Sprite;
                count = 0;
                Time.timeScale = 1;
                NPCCommunity.SetActive(false);
            }
        }
    }
}
