using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ScoreDataHandler : MonoBehaviour
{
    private static string dataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    private static string filePath = Path.Combine(dataPath, "FlappyShape/ScoreDatas.txt");

    public static void SaveScore(string Score, string Time) {
        string data = Score + "," + Time;
        File.AppendAllText(filePath, data + "\n");
    }

    public static string[] GetScores() {
        if (!File.Exists(filePath)) return null;
        string[] datas = File.ReadAllLines(filePath);
        return datas;
    }
}
