using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        this.transform.Rotate(0f, 0f, 0.5f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isOpening && this.transform.rotation.z <= 0.703f)
            Open();
	}
}
