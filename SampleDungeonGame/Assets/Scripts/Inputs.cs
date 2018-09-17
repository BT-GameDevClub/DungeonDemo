using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{

    Character controller;
    CameraClass cam;
    Vector3 lastLook;

    // Use this for initialization
    void Start()
    {
        controller = new Character(gameObject);
        cam = new CameraClass(controller, CameraClass.CameraMode.Follow, 10);
        Physics.IgnoreLayerCollision(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Ray mouseRay = cam.Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = 1 << 9;

        if (Physics.Raycast(mouseRay, out hit, 50, layerMask))
        {
            lastLook = hit.point;
        }

        controller.Update(new Vector3(x, 0, y), lastLook);
        cam.Update();

        if (Input.GetKeyDown("space"))
        {
            controller.Shoot();
        }
    }
}
