using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOffAfterThunder : MonoBehaviour {

    GameObject lampGroup;
    Light[] lamp;
    GameObject thunderGroup;
    Thunder[] thunderLight;
    public static bool isOff;

    //public Light[] offLamp;

    // Use this for initialization
    void Awake ()
    {
        //isOff = false;
        lampGroup = GameObject.Find("lampGroup");
        lamp = lampGroup.GetComponentsInChildren<Light>();  
        thunderGroup = GameObject.Find("ThunderGroup");
        thunderLight = thunderGroup.GetComponentsInChildren<Thunder>();
//        thunderLight = GameObject.Find("ThunderGroup").GetComponentsInChildren<Thunder>();
        //thunderLight = GameObject.Find("Thunderlight").GetComponent<Light>();
    }

    private void Start()
    {
        
        if (isOff)
        {
            foreach(Light light in lamp)
            {
                light.enabled = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOff)
        {
            isOff = true;
//            isOff = true;
/*
            foreach(Thunder light in thunderLight)
            {
                light.CallFast();
            }
            */
            foreach(Thunder thunder in thunderLight)
            {
                thunder.CallFast();
            }
//            thunderLight.GetComponent<Thunder>().CallFast();
            foreach (Light light in lamp)
            {
                light.enabled = false;
            }

            /*
            foreach(Light light in offLamp)
            {
                light.enabled = false;
            }
            */
        }
    }

}
