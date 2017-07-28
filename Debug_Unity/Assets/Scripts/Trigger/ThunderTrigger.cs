using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderTrigger : MonoBehaviour {

    Light thunderLight;

	// Use this for initialization
	void Awake () {
        thunderLight = GameObject.Find("Thunderlight").GetComponent<Light>();
	}
    private void OnTriggerEnter(Collider other)
    {
        thunderLight.GetComponent<Thunder>().CallIntermittent();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
