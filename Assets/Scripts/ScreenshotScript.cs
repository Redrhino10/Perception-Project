using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotScript : MonoBehaviour
{
    public string TakeScreenshot()
    {
        //string screenshotfilename = Application.dataPath + "/Screenshots/" + System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png";
        string screenshotfilename = "C:/Users/thoma/OneDrive/Documents/Unity Projects/Perception Project/Screenshots/"
            + System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png";

        //"C:/Users/thoma/OneDrive/Documents/Unity Projects/Perception Project/Screenshots/"
        //C:\Users\thoma\OneDrive\Documents\Unity Projects\Perception Project\Screenshots
        ScreenCapture.CaptureScreenshot(screenshotfilename);
        UnityEditor.AssetDatabase.Refresh();

        return screenshotfilename;
    }
}
