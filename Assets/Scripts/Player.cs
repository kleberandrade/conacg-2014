using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour 
{
    public delegate void PlayerHandler();
    public static event PlayerHandler OnGameover;

    public float force = 500.0f;
    public float gravity = -15.0f;
    public float speed = 4.0f;

    private bool isAlive = true;
    private bool touch = false;

	void Start () 
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GetComponent<Rigidbody>().constraints -= RigidbodyConstraints.FreezePositionY;
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            touch = true;
	}

    void FixedUpdate()
    {
        if (isAlive)
        {
            if (touch)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().AddForce(Vector3.up * force);
                touch = false;
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * gravity);
            }

            GetComponent<Rigidbody>().velocity += Vector3.right * speed;

            int sign = Vector3.Cross(Vector3.right, GetComponent<Rigidbody>().velocity.normalized).z < 0 ? -1 : 1;
            transform.rotation = Quaternion.Euler(Vector3.forward * Vector3.Angle(Vector3.right, GetComponent<Rigidbody>().velocity.normalized) * sign);
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (isAlive)
        {
            isAlive = false;
            if (OnGameover != null)
                OnGameover();
        }
    }
}
