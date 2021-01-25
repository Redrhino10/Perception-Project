using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LogData
{
    public ListEntry[] logDataList;

    //public int number;
    //public string word;
}

[System.Serializable]
public class ListEntry
{
    public float timer;
    public int number;
    public string word;
    public string filelocation;
    public float zoom;
}