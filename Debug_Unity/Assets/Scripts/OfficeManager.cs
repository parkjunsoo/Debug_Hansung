using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Player").GetComponent<AudioSource>().volume = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
