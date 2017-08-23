using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerOpen : MonoBehaviour {

    bool opening;

	// Use this for initialization
	void Start () {
		
	}
	
    //y값 기준으로 -0.9까지

	// Update is called once per frame
	void Update () {
        if (opening && this.transform.rotation.y >= -0.9f)
            Open();
	}

    void Open()
    {
        this.transform.Rotate(0, -1f, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.R) && GameObject.Find("Lock_Close").GetComponent<Lock>().isCut)
        {
            opening = true;
            GameObject.Find("Thunderlight").GetComponent<Thunder>().CallIntermittent();
        }
    }

}
