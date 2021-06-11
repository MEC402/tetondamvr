using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullZoneHelper : MonoBehaviour
{
    private GameObject PullEndLocation;
    private float PullForce;
    
    public void init(GameObject pullEndLocation, float pullForce)
    {
        PullEndLocation = pullEndLocation;
        PullForce = pullForce;
    }

    public void updateForce(float pullForce)
    {
        PullForce = pullForce;
    }

    private void OnTriggerStay(Collider other)
    {
        var body = other.GetComponent<Rigidbody>();
        body.gameObject.layer = LayerMask.NameToLayer("Moving");
        //body.isKinematic = false;
        body.useGravity = true;
        body.AddForce((PullEndLocation.transform.position - other.transform.position) * PullForce);
    }

}
