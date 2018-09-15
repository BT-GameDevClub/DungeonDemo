using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour {

    Character controller;
    Camera cam;
    Vector3 lastLook;

	// Use this for initialization
	void Start () {
        controller = new Character(gameObject);
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = 1 << 9;

        if (Physics.Raycast(mouseRay, out hit, layerMask)) {
            lastLook = hit.point;
        }

        controller.Update(new Vector3(x, 0, y), lastLook);
	}
}
