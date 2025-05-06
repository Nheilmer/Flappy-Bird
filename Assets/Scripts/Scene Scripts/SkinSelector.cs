using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    /* Colors
     * 925A5A RED (146,90,90)
     * 7B5A91 VIOLET (123,90,145)
     * 5A5C91 BLUE (90,92,145)
     * 5A7991 CYAN (90,121,145)
     * 63915A GREEN (99,145,90)
     * 91825A BROWN (145,130,90)
     * 916D5A RED ORANGE (145,109,90)
     */
    
    [SerializeField] private Image BirdPrefab;
    private static string dataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    private int selectedColorIndex = 0;
    private Color selectedColor;
    private string[] Colors = {
        "#925A5A",
        "#7B5A91",
        "#5A5C91",
        "#5A7991",
        "#63915A",
        "#91825A",
        "#916D5A"
    };

    public void SwitchColorRight() {
        selectedColorIndex++;
        if (selectedColorIndex >= Colors.Length) {
            selectedColorIndex = 0;
        }

        if (ColorUtility.TryParseHtmlString(Colors[selectedColorIndex], out selectedColor)) {
            BirdPrefab.color = selectedColor;
        }
    }

    public void SwitchColorLeft() {
        selectedColorIndex--;
        if (selectedColorIndex <= -1) {
            selectedColorIndex = 6;
        }

        if (ColorUtility.TryParseHtmlString(Colors[selectedColorIndex], out selectedColor)) {
            BirdPrefab.color = selectedColor;
        }
    }

    public void SaveBirdPreset() {
        string presetData = Colors[selectedColorIndex] + "\n" + selectedColorIndex;
        string filePath = Path.Combine(dataPath, "FlappyShape/SavedBirdPreset.txt");
        File.WriteAllText(filePath, presetData);
        
        SceneManager.LoadScene("Game");

    }

    public static string[] storePresetToArray() {
        string[] datas = new string[2];
        string filePath = Path.Combine(dataPath, "FlappyShape/SavedBirdPreset.txt");
        if (File.Exists(filePath)) {
            datas = File.ReadAllLines(filePath);
        }
        return datas;
    }
}
