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
        if (Input.GetKeyDown(KeyCode.A))
        {
            logScript.AddLogEntry();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            logScript.SaveLogs();
        }

        if(Input.GetKey(KeyCode.W))
        {
            cameraMovementScript.Move(CameraMovementScript.Direction.up);
        }
    }
}
