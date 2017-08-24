using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    // Use this for initialization
    void Start () {
        if (GameObject.Find("Player").GetComponent<PlayerControl>().IsOff())
            this.GetComponent<Light>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
