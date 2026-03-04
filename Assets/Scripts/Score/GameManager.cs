using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1, scorePlayer2;
    public ScoreText ScoreLeft, ScoreRight;

    public void OnScoreZoneBreached(int id)
    {
        if (id == 1)
        {
            scorePlayer1++;
        }

        if (id == 2)
        {
            scorePlayer2++;
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreLeft.SetScore(scorePlayer1);
        ScoreRight.SetScore(scorePlayer2);
    }
    
}
