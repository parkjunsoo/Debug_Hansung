using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour {

    Light thunderLight;

	// Use this for initialization
	void Awake() {
        thunderLight = GetComponent<Light>();
        thunderLight.intensity = 0f;
        /*
        if(Random.Range(1,3) == 1)
        {
            StartCoroutine(ThunderLight_fast());
        }
        else
        */
        StartCoroutine(ThunderLight_slow());
        
//        StartCoroutine(ThunderLight_Intermittent());

    }
	
    IEnumerator ThunderLight_fast()             //뻔쩎!
    {
        thunderLight.intensity = 1.5f;
        yield return new WaitForSeconds(0.5f);
        thunderLight.intensity = 0f;
    }

    IEnumerator ThunderLight_slow()             //버언~~~~쩍!!
    {
        for(thunderLight.intensity = 0f;thunderLight.intensity < 1.5f;)
        {
            thunderLight.intensity += Random.Range(-0.04f, 0.07f);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        thunderLight.intensity = 0f;
        yield return null;
    }

    IEnumerator ThunderLight_Intermittent()     //뻔쩎뻔쩎뻔쩎!!!
    {
        for(int i = 0; i < Random.Range(6,8); i++)
        {
            if (thunderLight.intensity == 0f)
                thunderLight.intensity = 1.2f;
            else
                thunderLight.intensity = 0f;
            yield return new WaitForSeconds(0.1f);
        }
        thunderLight.intensity = 0f;
    }

    public void Call()
    {
        StartCoroutine(ThunderLight_Intermittent());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
