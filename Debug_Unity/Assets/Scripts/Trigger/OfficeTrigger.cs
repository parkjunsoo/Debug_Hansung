using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfficeTrigger : MonoBehaviour {

    GameObject player;
    float triggerTime;
    float fadeTime;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        triggerTime = Time.time;
        fadeTime = Time.time;
        if(player.GetComponent<PlayerControl>().GetLED())
            GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.0f);
    }

    private void OnTriggerStay(Collider other)
    {
        fadeTime += Time.deltaTime;
        if(fadeTime - triggerTime >= 1.0f && player.GetComponent<PlayerControl>().GetLED())
            SceneManager.LoadScene("firstFloor");
    }
}
