using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPad : MonoBehaviour {

    NumButton[] numBtn;
    public string password;
    public string inputPW;

	// Use this for initialization
	void Awake () {
        password = "8";
        numBtn = GetComponentsInChildren<NumButton>();
        inputPW = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Password(string pw)
    {
        if (pw.Equals("#"))
        {
            if (inputPW.Equals(password))
                Destroy(gameObject);
        }
        inputPW += pw;
        Debug.Log(inputPW);
    }

    public void isCorrect(string num)
    {
        if (num.Equals(password))
            Destroy(gameObject);
    }

}
