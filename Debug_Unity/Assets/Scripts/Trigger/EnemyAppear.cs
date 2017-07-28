using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour {

    public bool appear;
    public bool disappear;
    public Transform enemy;
    public Transform appearPoint;

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        if (enemy.position.x - appearPoint.position.x >= 0.01f && appear)
            enemy.Translate(new Vector3(0,0.02f,0));
        if (enemy.position.x - appearPoint.position.x <= 1f && disappear)
            enemy.Translate(new Vector3(0, -0.02f, 0));
    }
}
