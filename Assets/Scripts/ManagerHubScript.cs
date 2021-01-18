using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHubScript : MonoBehaviour
{
    public LoggingScript logScript;
    public ScreenshotScript screenshotScript;

    private void Start()
    {
        logScript = gameObject.GetComponent<LoggingScript>();

        if(logScript == null) { Debug.LogError("No Log script on " + gameObject.name); }
    }
}
