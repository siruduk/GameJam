using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : ObjectBase
{
    public float t;
    //Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.useGravity = true;
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
            ReleaseObject();
    }
}
