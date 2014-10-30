using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
    public int Point { get; set; }

	void Start () 
    {
        Point = 0;
	}

	public void SaveBestScore () 
    {
        PlayerPrefs.SetInt("BestScore", Point);
        PlayerPrefs.Save();
	}

    public int GetBestScore()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
            return 0;

        return PlayerPrefs.GetInt("BestScore");
    }
}
