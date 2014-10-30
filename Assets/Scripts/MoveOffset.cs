using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour
{
    private Material materialRef;
    public float speed = 2.0f;
    public Vector2 direction = -Vector2.right;

	void Start ()
    {
        materialRef = renderer.material;
	}
	
	void Update ()
    {
        materialRef.SetTextureOffset("_MainTex", direction * speed * Time.time);
	}
}
