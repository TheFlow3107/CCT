using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket_Behavior : MonoBehaviour
{
    private Rigidbody rb;

    public float force = 5;

    Vector3 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Balls"))
        {
            var dir = Vector3.Reflect(lastVelocity.normalized, rb.velocity);

            other.GetComponent<Rigidbody>().velocity = dir.normalized * force;
        }
    }
}
