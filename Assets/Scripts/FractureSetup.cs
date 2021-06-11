using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var body = other.GetComponent<Rigidbody>();
        body.useGravity = false;
        body.isKinematic = true;
    }
}
