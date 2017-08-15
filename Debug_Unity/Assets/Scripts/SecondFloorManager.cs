using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorManager : MonoBehaviour {

    GameObject player;
    public Transform startPosition;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        player.transform.position = startPosition.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
