using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    private static string dataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    private static string filePath = Path.Combine(dataPath, "FlappyShape");

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(filePath)) {
            Directory.CreateDirectory(filePath);

            string dificultyFile = Path.Combine(filePath, "DificultyData.txt");
            if (!File.Exists(dificultyFile)) {
                File.WriteAllText(dificultyFile, "DificultyData");
            }

            string saveBirdPreset = Path.Combine(filePath, "SavedBirdPreset.txt");
            if (!File.Exists(dificultyFile)) {
                File.WriteAllText(dificultyFile, "SavedBirdPreset");
            }

            string scoreDatas = Path.Combine(filePath, "ScoreDatas.txt");
            if (!File.Exists(dificultyFile)) {
                File.WriteAllText(dificultyFile, "ScoreDatas");
            }
        }
    }

    public static void CloseSystem() {
        Application.Quit();
    }
}
