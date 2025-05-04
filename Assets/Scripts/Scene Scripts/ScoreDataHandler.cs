using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreDataHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string textToSave = "Hello, this is saved text!";
        string path = Application.persistentDataPath + "/myfile.txt";

        File.WriteAllText(path, textToSave);

        Debug.Log("File saved to: " + path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
