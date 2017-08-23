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
        fadeTime += Time.deltaTime;
        if (fadeTime - triggerTime >= 1.0f && triggerTime != 0f)
            SceneManager.LoadScene("firstFloor");
	}

    private void OnTriggerEnter(Collider other)
    {
        triggerTime = Time.time;
        fadeTime = Time.time;
        GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.0f);
        player.GetComponent<PlayerControl>().SetPosition("OfficeOutPosition");      //나가서 firstFloor 씬이 로드되었을 때의 시작 위치를 지정
    }

    private void OnTriggerStay(Collider other)
    {
        //fadeTime += Time.deltaTime;
        if(fadeTime - triggerTime >= 1.0f && triggerTime != 0f)
            SceneManager.LoadScene("firstFloor");
    }
}
