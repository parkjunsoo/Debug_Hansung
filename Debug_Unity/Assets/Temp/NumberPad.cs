using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPad : MonoBehaviour {

    NumButton[] numBtn;
    public string password;
    public string inputPW;
    MeshRenderer[] numPads;
    BoxCollider[] numCols;
    public TextMesh pwText;

	// Use this for initialization
	void Awake () {
        pwText = GameObject.Find("PWText").GetComponent<TextMesh>();
        password = "8";
        numBtn = GetComponentsInChildren<NumButton>();
        inputPW = null;
        numPads = GetComponentsInChildren<MeshRenderer>();
        numCols = GetComponentsInChildren<BoxCollider>();
	}

    private void Start()
    {   
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        foreach(BoxCollider cols in numCols)
        {
            cols.enabled = false;
        }
        foreach (MeshRenderer mesh in numPads)
        {
            mesh.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Password(string pw)
    {
        if (pw.Equals("#"))
        {
            if (inputPW.Equals(password))
            {
                GameObject.Find("frontdoor_right").GetComponent<DoorOpen>().isOpening = true;
                GameObject.Find("FadeManager").GetComponent<FadeManager>().Fade(true, 1.25f);               // 비밀번호가 맞으면 Fadeout
                //Destroy(gameObject);
                DisableMesh();
                Destroy(GetComponentInParent<cakeslice.Outline>());
                Destroy(GetComponentInParent<cakeslice.Toggle>());
                return;
            }
            else
            {
                inputPW = "";
                pwText.text = "PassWord : ";
            }
        }
        else if (pw.Equals("*"))
        {
            inputPW = "";
            pwText.text = "PassWord : ";
        }
        else
        {
            inputPW += pw;
            pwText.text += pw;
        }
        Debug.Log(inputPW);
    }
    /*
    public void isCorrect(string num)
    {
        if (num.Equals(password))
            Destroy(gameObject);
    }
    */
    public void EnableMesh()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<MeshCollider>().enabled = true;
        foreach (BoxCollider cols in numCols)
        {
            cols.enabled = true;
        }
        foreach (MeshRenderer mesh in numPads)
        {
            mesh.enabled = true;
        }
    }

    public void DisableMesh()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        foreach (BoxCollider cols in numCols)
        {
            cols.enabled = false;
        }
        foreach (MeshRenderer mesh in numPads)
        {
            mesh.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisableMesh();
    }
}
