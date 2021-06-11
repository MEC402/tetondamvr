using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChunks : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject child;
    void Start()
    {
        child = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if(collision.transform.gameObject.layer == LayerMask.NameToLayer("Moving"))
        {
            var obj = collision.transform.gameObject;
            var body = obj.GetComponent<Rigidbody>();
            body.AddForce((child.transform.position - obj.transform.position));
        }
        
    }
}
