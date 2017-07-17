using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbering : MonoBehaviour {

    public string input;
    GameObject numberpad;

	// Use this for initialization
	void Awake () {
        numberpad = GameObject.Find("numberPad");
	}
	
    public string Call()
    {
        var ex = numberpad.GetComponent<NumberPad>();
        if (input.Equals("*") && input.Equals("#"))
        {
//            Debug.Log(input);
            //ex.inputPW += input.ToString();
            return input;

        }
        else if (input.Equals("*"))
        {
            Debug.Log(input);
            //ex.inputPW = "";
            return null;
        }
        else
        {
            Debug.Log(input);
            //ex.isCorrect();
            return null;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
