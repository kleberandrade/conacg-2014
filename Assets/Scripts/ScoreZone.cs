using UnityEngine;
using System.Collections;

public class ScoreZone : MonoBehaviour 
{
    public delegate void ScoreZoneHandler();
    public static event ScoreZoneHandler OnScoreUp;

	void Start ()
    {
        GetComponent<Collider>().isTrigger = true;
	}

	void OnTriggerEnter (Collider hit) 
    {
        if (OnScoreUp != null)
            OnScoreUp();
	}
}
