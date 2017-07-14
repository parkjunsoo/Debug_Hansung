using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NipperExample : MonoBehaviour {

    GameObject playerCharacter;

    public void Call()
    {
        var player = playerCharacter.GetComponent<PlayerItems>();         //player에, 가져온 playerCharacter의 PlayerControl 스크립트를 가져와 저장 
        player.getNipper = true;                //Nipper를 얻었는지를 판단하는 부울 변수를 true로 설정
        Destroy(gameObject);
    }

    // Use this for initialization
    void Awake () {
        playerCharacter = GameObject.Find("Player");                //이름이 "Player"인 GameObject를 가져와 playerCharacter 변수에 저장
	}

}
