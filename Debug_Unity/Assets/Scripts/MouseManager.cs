using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    

    public GameObject selectedObject;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //RaycastHit[] hits = Physics.RaycastAll(ray);
        if(Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log("Mouse is over:" + hitInfo.collider.name);
            GameObject hitObject = hitInfo.transform.root.gameObject;
            
            HoverObject(hitObject);
        }
        else
        {
            ClearSelection();
        }
     
	}
    void HoverObject(GameObject obj)
    {
        if(selectedObject != null)
        {
            if (obj == selectedObject) return;
            ClearSelection();
        }
        selectedObject = obj;
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach(Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.green;
            r.material = m; 
        }
    } 
    void ClearSelection()
    {
        if (selectedObject == null)
            return;
        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }
        selectedObject = null;
    }
}
