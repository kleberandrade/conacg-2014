using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Obstacle : MonoBehaviour
{
    public float speed = 4.0f;
    public Vector3 direction = -Vector3.right;

	void Start ()
    {
        collider.isTrigger = true;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
	
	void OnTriggerEnter (Collider hit)
    {
        if (hit.CompareTag("Limiter"))
            gameObject.SetActive(false);
	}
}
