using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderTrigger : MonoBehaviour {

    Thunder[] thunderLight;
    AudioSource rainySound;

	// Use this for initialization
	void Awake () {
        rainySound = GameObject.Find("Player").GetComponent<AudioSource>();
        thunderLight = GameObject.Find("ThunderGroup").GetComponentsInChildren<Thunder>();
	}
    private void OnTriggerEnter(Collider other)
    {
        rainySound.volume = 0.7f;
        foreach(Thunder thunder in thunderLight)
        {
            thunder.CallIntermittent();
        }
        //thunderLight.GetComponent<Thunder>().CallIntermittent();
    }
    private void OnTriggerExit(Collider other)
    {
        rainySound.volume = 0.5f;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
