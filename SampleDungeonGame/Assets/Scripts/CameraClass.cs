using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClass
{
    readonly Character controller;
    public Camera Camera;
    public enum CameraMode {Follow, Orbit}
    public CameraMode State;
    public int Zoom;

    public CameraClass(Character player, CameraMode state, int zoom)
    {
        State = state;
        Zoom = zoom;
        controller = player;
        GameObject cameraObject = new GameObject("Main Camera");
        Camera = cameraObject.AddComponent<Camera>();
    }

    public void Update()
    {
        switch (State)
        {
            case CameraMode.Follow:
                Vector3 offset = new Vector3(0, 10, -5);
                Vector3 charPos = controller.charModel.transform.position;
                Camera.transform.position = charPos + offset;
                Camera.transform.rotation = Quaternion.LookRotation(-offset);
                break;
            case CameraMode.Orbit:

                break;
        }
    }
}
