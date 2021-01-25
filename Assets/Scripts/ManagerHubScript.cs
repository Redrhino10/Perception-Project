using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHubScript : MonoBehaviour
{
    public LoggingScript logScript;
    public ScreenshotScript screenshotScript;
    public CameraMovementScript cameraMovementScript;

    private void Start()
    {
        logScript = gameObject.GetComponent<LoggingScript>();
        screenshotScript = gameObject.GetComponent<ScreenshotScript>();
        cameraMovementScript = gameObject.GetComponent<CameraMovementScript>();

        if (logScript == null) { Debug.LogError("No Log script on " + gameObject.name); }
        if (screenshotScript == null) { Debug.LogError("No Screenshot script on " + gameObject.name); }
        if (cameraMovementScript == null) { Debug.LogError("No Camera Movement script on " + gameObject.name); }
    }

    private void Update()
    {
        //Add log script
        if (Input.GetKeyDown(KeyCode.F))
        {
            logScript.CheckForDefects();
            logScript.AddLogEntry();
        }

        //Save Logs
        if (Input.GetKeyDown(KeyCode.Space))
        {
            logScript.SaveLogs();
        }

        //Zoom
        cameraMovementScript.ZoomScroll(Input.GetAxis("Mouse ScrollWheel") * -20f);

        //Reset Zoom
        if(Input.GetKeyDown(KeyCode.R)) {   cameraMovementScript.ZoomSet(60);   }

        //Mouse Input
        //if(Input.GetKey(KeyCode.C))
        if (Input.GetMouseButton(1))
        {
            cameraMovementScript.FollowMouse();
        }

        //Movement
        if(Input.GetKey(KeyCode.W))
        {
            cameraMovementScript.Move(CameraMovementScript.Direction.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraMovementScript.Move(CameraMovementScript.Direction.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraMovementScript.Move(CameraMovementScript.Direction.down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraMovementScript.Move(CameraMovementScript.Direction.right);
        }
        //Rotation
        if (Input.GetKey(KeyCode.Q))
        {
            cameraMovementScript.Rotate(CameraMovementScript.Rotation.yawinverse);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cameraMovementScript.Rotate(CameraMovementScript.Rotation.yaw);
        }
    }
}
