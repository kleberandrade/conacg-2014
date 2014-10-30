using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Score score;
    public SpawnerObsctacle spawner;
    public float time = 4.0f;
    public float repeatRate = 2.5f;

	void OnEnable ()
    {
        Player.OnGameover += OnGameover;
        ScoreZone.OnScoreUp += OnScoreUp;
	}

	void OnDisable ()
    {
        Player.OnGameover -= OnGameover;
        ScoreZone.OnScoreUp -= OnScoreUp;
	}

    void Start()
    {
        InvokeRepeating("Spawner", time, repeatRate);
    }

    void OnGameover()
    {
        Debug.Log("Game Over");
        int bestScore = score.GetBestScore();
        if (score.Point > bestScore)
        {
            score.SaveBestScore();
            Debug.Log("New Best Score: " + score.Point);
        }
        else
        {
            Debug.Log("Final Score: " + score.Point);
        }

        CancelInvoke("Spawner");
    }

    void OnScoreUp()
    {
        score.Point += 1;
        Debug.Log("Score: " + score.Point);
    }

    void Spawner()
    {
        spawner.Spawn();
    }
}
