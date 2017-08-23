using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSecondFloor : MonoBehaviour {

    GameObject player;
    float time;
    float fadeTime;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time - fadeTime >= 1.25f && fadeTime != 0)
        {
            SceneManager.LoadScene("secondFloor");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //if (player.GetComponent<PlayerControl>().GetLED())
        {
            fadeTime = time;
            GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.25f);
        }
    }
    
}
