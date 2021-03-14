using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class CSVParsing : MonoBehaviour
{
    public TextAsset csvFile; // Reference of CSV file
    //public Text contentArea; // Reference of contentArea where records are displayed
    public Dictionary<string, float> entries = new Dictionary<string, float>();
    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ','; // It defines field seperate chracter

    void Start()
    {
        readData();
    }
    // Read data from CSV file
    private void readData()
    {
        string[] records = csvFile.text.Split(lineSeperater);
        string last = "";
        foreach (string record in records)
        {
            string[] fields = record.Split(fieldSeperator);
            //print(fields[1]);
            entries.Add(fields[0], float.Parse(fields[1]));
            last = fields[0];
        }
        //contentArea.text = last + " => " + entries[last];
    }


    // Get path for given CSV file
    private static string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath;
#elif UNITY_ANDROID
return Application.persistentDataPath;// +fileName;
#elif UNITY_IPHONE
return GetiPhoneDocumentsPath();// +"/"+fileName;
#else
return Application.dataPath;// +"/"+ fileName;
#endif
    }
    // Get the path in iOS device
    private static string GetiPhoneDocumentsPath()
    {
        string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
        path = path.Substring(0, path.LastIndexOf('/'));
        return path + "/Documents";
    }

}