using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Obstacle : MonoBehaviour
{
    public float speed = 4.0f;
    public Vector3 direction = -Vector3.right;

	void Start ()
    {
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
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
