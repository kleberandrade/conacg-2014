using UnityEngine;
using System.Collections;

public class DisableScript : MonoBehaviour 
{
    private MonoBehaviour[] scripts;

    void Start()
    {
        scripts = GetComponents<MonoBehaviour>();
    }
	
	void OnEnable () 
    {
        Player.OnGameover += OnGameover;
	}

    void OnDisable()
    {
        Player.OnGameover -= OnGameover;
    }

    void OnGameover()
    {
        foreach (MonoBehaviour mb in scripts)
            mb.enabled = false;
    }
}
