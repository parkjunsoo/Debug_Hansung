using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOffAfterThunder : MonoBehaviour {

    GameObject lampGroup;
    Light[] lamp;
    Light thunderLight;
    bool isOff;

    // Use this for initialization
    void Awake ()
    {
        isOff = false;
        lampGroup = GameObject.Find("lampGroup");
        lamp = lampGroup.GetComponentsInChildren<Light>();
        thunderLight = GameObject.Find("Thunderlight").GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOff)
        {
            isOff = true;
            thunderLight.GetComponent<Thunder>().CallFast();
            foreach (Light light in lamp)
            {
                light.enabled = false;
            }
        }
    }

}
