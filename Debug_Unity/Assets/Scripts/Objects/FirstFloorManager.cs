using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorManager : MonoBehaviour {

    GameObject player;
    public GameObject initPosition;
    public GameObject officeOutPosition;
    AudioSource alert;

    // Use this for initialization
    void Start () {
        alert = GetComponent<AudioSource>();
        alert.Pause();
        player = GameObject.Find("Player");
        if (player.GetComponent<PlayerControl>().StartPosition().Contains("Down"))
        {
            alert.Play();
            alert.loop = true;
        }
        //시작하는 위치를 지정하기 위함. PlayerControl 스크립트의 startPosition 문자열을 갖는 오브젝트를 찾아 그 위치를 시작 위치로 지정.
        player.transform.position = GameObject.Find(player.GetComponent<PlayerControl>().StartPosition()).transform.position;

        player.GetComponent<AudioSource>().volume = 0.5f;
        /*
        if(player.GetComponentInChildren<Light>().enabled)                  //손전등이 활성화 상태에서 Start시 Player의 시작 위치를 과사 앞으로
            player.transform.position =
                officeOutPosition.transform.position;
        else                                                                //손전등이 비활성화 상태일 경우 Player의 시작 위치를 Default로
            player.transform.position =
                initPosition.transform.position;
        

        /*
        if (player.GetComponent<PlayerControl>().GetLED())
            player.transform.position =
                officeOutPosition.transform.position;
        else
            player.transform.position =
                initPosition.transform.position;

        /*
        switch (player.GetComponent<PlayerControl>().getLevel())
        {
            case 0:
                player.transform.position =
                    initPosition.transform.position;
                    //GameObject.Find("InitPosition").transform.position;
                break;
            case 1:
                player.transform.position =
                    officeOutPosition.transform.position;
                    //GameObject.Find("OfficeOutPosition").transform.position;
                break;
                /*
            default:
                player.transform.position =
                    initPosition.transform.position;
                    //GameObject.Find("InitPosition").transform.position;
                break;
                
                
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
