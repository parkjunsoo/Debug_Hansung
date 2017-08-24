using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoFirstFloor : MonoBehaviour {

    float time;
    float fadeTime;

    private void OnTriggerEnter(Collider other)
    {
        time = Time.time;
        fadeTime = time;
        GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.25f);
        GameObject.Find("Player").GetComponent<PlayerControl>().SetPosition("DownPosition");
        //GameObject.Find("Player").GetComponent<PlayerControl>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        //fadeTime += Time.deltaTime;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fadeTime += Time.deltaTime;
        if (fadeTime - time >= 1.25f && time != 0)
            SceneManager.LoadScene("firstFloor");
	}
}
