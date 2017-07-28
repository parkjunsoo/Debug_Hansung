using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisappearTrigger : MonoBehaviour {

    EnemyAppear parent;

	// Use this for initialization
	void Awake () {
        parent = GetComponentInParent<EnemyAppear>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        parent.disappear = true;
    }
    private void OnTriggerExit(Collider other)
    {
        parent.disappear = false;
    }
}
