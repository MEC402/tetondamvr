using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject container = null;
        for(int i = 0; i < this.transform.childCount; i++)
        {
            if(this.transform.GetChild(i).name == "FractureContainer")
            {
                container = this.transform.GetChild(i).gameObject;
            }
        }

        for(int i = 0; i < container.transform.childCount; i++)
        {
            GameObject child = container.transform.GetChild(i).gameObject;
            var collider = child.AddComponent<MeshCollider>();
            collider.convex = true;
            var body = child.AddComponent<Rigidbody>();
           // body.isKinematic = true;
           // body.useGravity = false;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
