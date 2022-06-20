using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(9.8f * 20, 9.8f * 20, 9.8f * 20));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
