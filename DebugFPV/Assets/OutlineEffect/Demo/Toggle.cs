using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
    public class Toggle : MonoBehaviour
    { 
        // Use this for initialization
        void Start()
        {
            GetComponent<Outline>().enabled = false;
        }
        
        private void OnTriggerEnter(Collider other)
        {
                GetComponent<Outline>().enabled = true;
        }

        private void OnTriggerExit(Collider other)
        {
                GetComponent<Outline>().enabled = false;
        }
    }
}