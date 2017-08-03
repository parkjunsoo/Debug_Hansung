using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorManager : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
        switch (player.GetComponent<PlayerControl>().getLevel())
        {
            case 0:
                player.GetComponent<PlayerControl>().startTransform =
                    GameObject.Find("InitPosition").transform;
                break;
            case 1:
                player.GetComponent<PlayerControl>().startTransform =
                    GameObject.Find("OfficeOutPosition").transform;
                break;
            default:
                player.GetComponent<PlayerControl>().startTransform =
                    GameObject.Find("InitPosition").transform;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
