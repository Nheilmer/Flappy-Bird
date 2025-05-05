using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreListHandler : MonoBehaviour
{
    [SerializeField] private GameObject scoreItemPrefab;  // Your panel prefab
    [SerializeField] private Transform contentParent;      // The Content object under Scroll View
    [SerializeField] private GameObject ScoresMenu;
    private bool isOpen = false;
    
    public void OpenScoresMenu() {
        isOpen = !isOpen;
        ScoresMenu.SetActive(isOpen);
        foreach (Transform child in contentParent) {
            Destroy(child.gameObject);
        }

        string[] scores = ScoreDataHandler.GetScores();
        for (int i = 0; i <= (scores.Length-1); i++) {
            AddScoreEntry((i+1).ToString(), scores[i].Split(",")[0], scores[i].Split(",")[1]);
        }
    }

    public void AddScoreEntry(string Number, string Score, string Time) {
        GameObject newItem = Instantiate(scoreItemPrefab, contentParent);
        TextMeshProUGUI[] texts = newItem.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = Number;
        texts[1].text = Score;
        texts[2].text = Time;
    }
}
