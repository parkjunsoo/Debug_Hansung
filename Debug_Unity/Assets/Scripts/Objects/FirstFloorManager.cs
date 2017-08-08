using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorManager : MonoBehaviour {

    GameObject player;
    public GameObject initPosition;
    public GameObject officeOutPosition;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        if(player.GetComponentInChildren<Light>().enabled)
            player.transform.position =
                officeOutPosition.transform.position;
        else
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
