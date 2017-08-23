using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    public bool isCut;

	// Use this for initialization
	void Start () {
        isCut = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cut()
    {
        isCut = true;
        GetComponent<MeshFilter>().mesh = GameObject.Find("Lock_Open").GetComponent<MeshFilter>().mesh;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<cakeslice.Outline>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Plane")           //충돌한 collider의 tag가 'Plane'일 경우 호출
            Debug.Log("CollisionEnter in Script_Lock Called");
    }

}
