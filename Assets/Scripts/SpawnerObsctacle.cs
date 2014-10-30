using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerObsctacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleAmount = 5;
    private List<GameObject> obstaclesPooled;

    public Transform maxLimiter;
    public Transform minLimiter;

	void Start () 
    {
        obstaclesPooled = new List<GameObject>();
        for (int i = 0; i < obstacleAmount; i++)
        {
            GameObject go = (GameObject)Instantiate(obstaclePrefab);
            go.SetActive(false);
            obstaclesPooled.Add(go);
        }
	}
	
	GameObject NextObject ()
    {
        for (int i = 0; i < obstaclesPooled.Count; i++)
        {
            if (!obstaclesPooled[i].activeInHierarchy)
                return obstaclesPooled[i];
        }

        return null;
	}

    public void Spawn()
    {
        GameObject go = NextObject();

        if (go == null)
            return;

        Vector3 position = transform.position;
        position.y = Random.Range(minLimiter.position.y, maxLimiter.position.y);
        go.transform.position = position;
        go.SetActive(true);
    }
}
