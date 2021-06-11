using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject person;
    public GameObject endpoint;
    public float speed = 0.25f;
    public float waitTime = 50;
    void Start()
    {
        person = this.transform.gameObject;
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(waitTime);
        person.transform.LookAt(endpoint.transform.position);
        while (Vector3.Distance(endpoint.transform.position, person.transform.position) > .5)
        {
            person.transform.position += person.transform.TransformDirection(new Vector3(0, 0, speed * Time.deltaTime));
            yield return null;
        }        
    }
}
