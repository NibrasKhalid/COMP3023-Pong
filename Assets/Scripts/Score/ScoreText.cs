using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void SetScore(int value)
    {
        scoreText.text = value.ToString();
    }

}
