using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDExample : MonoBehaviour {

    private void Start()
    {
        if (GameObject.Find("Player").GetComponent<PlayerControl>().GetLED())
            Destroy(gameObject);
    }

    public void Call()
    {
        Destroy(gameObject);
    }
    
}
