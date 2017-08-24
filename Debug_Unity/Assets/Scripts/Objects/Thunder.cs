using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour {

    Light thunderLight;
    AudioSource thunderSound;
    float thunderIntensity = 1.0f;

	// Use this for initialization
	void Awake() {
        thunderLight = GetComponent<Light>();
        thunderLight.intensity = 0f;
        thunderSound = GetComponent<AudioSource>();
        /*
        if(Random.Range(1,3) == 1)
        {
            StartCoroutine(ThunderLight_fast());
        }
        else
        
        if(GameObject.Find("Player").GetComponent<PlayerControl>().getLevel() != 1)
        StartCoroutine(ThunderLight_slow());
        */
//        StartCoroutine(ThunderLight_Intermittent());

    }
	
    IEnumerator ThunderLight_fast()             //뻔쩎!
    {
        thunderLight.intensity = thunderIntensity;
        yield return new WaitForSeconds(0.5f);
        thunderLight.intensity = 0f;
    }

    IEnumerator ThunderLight_slow()             //버언~~~~쩍!!
    {
        for(thunderLight.intensity = 0f; thunderLight.intensity < thunderIntensity;)
        {
            thunderLight.intensity += GameObject.Find("GameManager").GetComponent<ThunderManager>().intensity;
            //thunderLight.intensity += 0.04f;
            //thunderLight.intensity += Random.Range(-0.04f, 0.07f);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        thunderLight.intensity = 0f;
        yield return null;
    }

    IEnumerator ThunderLight_Intermittent()     //뻔쩎뻔쩎뻔쩎!!!
    {
        for (int i = 0; i < Random.Range(6,8); i++)
        {
            if (thunderLight.intensity == 0f)
            {
                thunderLight.intensity = thunderIntensity;
            }
            else {
                thunderLight.intensity = 0f;
            }
            yield return new WaitForSeconds(0.1f);
        }
        thunderLight.intensity = 0f;
    }

    public void CallIntermittent()
    {
        thunderSound.Play();
        StartCoroutine(ThunderLight_Intermittent());
    }

    public void CallFast()
    {
        thunderSound.Play();
        StartCoroutine(ThunderLight_fast());
    }

    public void CallSlow()
    {
        StartCoroutine(ThunderLight_slow());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
