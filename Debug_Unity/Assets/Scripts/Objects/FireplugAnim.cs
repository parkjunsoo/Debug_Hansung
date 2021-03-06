﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplugAnim : MonoBehaviour {

    Animator anim;
    bool thunder;
    bool animPlayed;
    GameObject gameManager;
    NipperExample nip;

	// Use this for initialization
	void Awake() {
        nip = GameObject.Find("Nipper").GetComponent<NipperExample>();
        gameManager = GameObject.Find("GameManager");
        anim = GetComponent<Animator>();
        animPlayed = false;
        thunder = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!thunder)
        {
            GameObject.Find("Thunderlight").GetComponent<Light>().GetComponent<Thunder>().CallIntermittent();
//            ex.GetComponent<Thunder>().Call();
//            gameManager.GetComponentInChildren<Thunder>().Call();
            thunder = true;
        }
    }

    private void OnTriggerStay(Collider other)      //component 중에 isTrigger 체크된 Collider가 Trigger역할을 함
    {                                               //Trigger 안에 다른 Collider가 들어와 있을 때 매 프레임마다 호출되는 함수
        if(other.tag == "Player")                   //Trigger 안에 들어와 있는 오브젝트의 태그가 "Player"이면
        {
            if (animPlayed == false && Input.GetKeyDown(KeyCode.R))     //애니메이션을 한 번만 플레이하기 위해 animPlayed == false && F키를 눌렀을 때
            {
                anim.SetTrigger("Open");                //Animator에서 작용
                animPlayed = true;                      //애니메이션을 한 번만 플레이해야 하므로 animPlayed를 true로 설정.
                nip.isOpen = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	}
}
