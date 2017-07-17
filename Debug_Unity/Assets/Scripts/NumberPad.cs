using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPad : MonoBehaviour {

    public string password;                //일치해야 할 패스워드
    public string inputPW;                 //사용자가 입력한 패스워드
    public Numbering num;

	// Use this for initialization
	void Awake () {
        password = "1";
        num = GetComponentInChildren<Numbering>();
	}
	
    public bool isCorrect()
    {
        if (inputPW.Equals(password))
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }
    
    private void FixedUpdate()
    {
        if (num.Call() != null)
        {
            inputPW += num.Call();
            Debug.Log(inputPW);
        }
        if (inputPW.Equals(password))
            Destroy(gameObject);
    }
    

}
