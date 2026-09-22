using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        Instance = this;
        UpdateDisplay();
    }

    public void AddPoints(int amount)
    {
        score += amount;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if (scoreText != null)
            scoreText.text = "Coins: " + score;
    }
}