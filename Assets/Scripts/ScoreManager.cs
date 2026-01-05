using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Texts")]
    public Text scoreText1;
    public Text scoreText2;
    public Text bestScoreText;

    private int score;
    private int bestScore;

    private void OnEnable()
    {
        // Рестарт очков при включении объекта
        score = 0;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateUI();
    }

    // ➕ Добавить очко игроку
    public void AddScore(int value)
    {
        score += value;
        CheckBestScore();
        UpdateUI();
    }

    // 🏆 Проверка лучшего результата
    private void CheckBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    // 🔄 Обновление текста
    private void UpdateUI()
    {
        scoreText1.text = score.ToString();
        scoreText2.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    // 🔁 Ручной сброс (если понадобится)
    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }
}
