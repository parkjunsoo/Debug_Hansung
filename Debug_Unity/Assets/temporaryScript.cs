using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temporaryScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("firstFloor");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
