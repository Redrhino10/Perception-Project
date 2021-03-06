﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggingScript : MonoBehaviour
{
    //[SerializeField] private LogData _LogData = new LogData();
    private LogData logData = new LogData();
    public List<ListEntry> Listyboi;
    private int counter = 0;
    private float timer = 0;

    private Camera mainCamera;
    private GameObject[] defects;

    private void Start()
    {
        defects = null;
        //Listyboi.Add(new ListEntry() { number = 1, word = "one" });
        //Listyboi.Add(new ListEntry() { number = 2, word = "two" });
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //Debug.Log("Main camera is on " + mainCamera + ", defects = " + defects.Length);
    }

    

    public bool truefalse()
    { 
        return Random.Range(0, 2) == 1;
    }

    public void AddLogEntry()
    {
        string Screenshotfile =
        gameObject.GetComponent<ManagerHubScript>().screenshotScript.TakeScreenshot();

        Listyboi.Add(new ListEntry()
        {
            timer = timer,
            number = counter,
            word = truefalse().ToString(),
            filelocation = Screenshotfile,
            zoom = mainCamera.GetComponent<Camera>().fieldOfView
        });
        counter++;
        Debug.Log("Entry Number = " + counter);
    }

    public void SaveLogs()
    {
        logData.logDataList = Listyboi.ToArray();

        SaveIntoJSON();
        Debug.Log("Saved");
    }

    public void SaveIntoJSON()
    {
        string data = JsonUtility.ToJson(logData);
        //System.IO.File.WriteAllText(Application.persistentDataPath + 
        //    "/LogData.json", data);

        System.IO.File.WriteAllText("C:/Users/thoma/OneDrive/Documents/Unity Projects/Perception Project/LogData.json", data);
    }

    public void Update()
    {
        timer += Time.deltaTime;

        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            logData.logDataList = Listyboi.ToArray();

            SaveIntoJSON();
            Debug.Log("Saved");
        }
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            CheckForDefects();

            string Screenshotfile = 
            gameObject.GetComponent<ManagerHubScript>().screenshotScript.TakeScreenshot();

            Listyboi.Add(new ListEntry()
            {
                timer = timer,
                number = counter,
                word = truefalse().ToString(),
                filelocation = Screenshotfile
            });
            counter++;
            Debug.Log("Counter = " + counter);
        }
        */
    }

    public void CheckForDefects()
    {
        defects = GameObject.FindGameObjectsWithTag("Defect");
        int defectcount = 0;

        foreach (GameObject XXX in defects)
        {
            Vector3 screenPoint = mainCamera.WorldToViewportPoint(XXX.transform.position);
            if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
            {
                defectcount += 1;
            }
        }
        Debug.LogWarning("Defects = " + defectcount.ToString());
    }
}
