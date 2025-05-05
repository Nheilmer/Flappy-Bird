using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DificultyModifier : MonoBehaviour
{
    private static string dataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    private static string filePath = Path.Combine(dataPath, "DificultyData.txt");

    public static void setDificulty(int diffType) {
        File.WriteAllText(filePath, diffType.ToString());
    }
}
