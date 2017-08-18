using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour {

    Transform doorTransform;
    public bool isOpening;

    private void Awake()
    {
        doorTransform = this.transform;
        isOpening = false;
    }

    void Open()
    {
        this.transform.Rotate(0f, -0.6f, 0f);
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(this.transform.rotation.y);
        if (isOpening && this.transform.rotation.y <= 0.503f)
            Open();
        //-5E-17
        
        if (this.transform.rotation.y >= -2.5E-17)
        //        if (this.transform.rotation.y >= 0f)
            SceneManager.LoadScene("office");
            
    }
}
