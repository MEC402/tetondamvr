using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullZoneManager : MonoBehaviour
{
    public int DelayTime;
    public float PullForce;
    public float TotalTime;
    public float yMoveDistance;
    public float xMoveDistance;
    public float finalScale;
    private GameObject PullZone;
    private GameObject PullEndLocation;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "PullZone")
            {
                PullZone = this.transform.GetChild(i).gameObject;
            }
            else
            {
                PullEndLocation = this.transform.GetChild(i).gameObject;
            }
        }

        PullZone.GetComponent<PullZoneHelper>().init(PullEndLocation,PullForce);

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position + (transform.right * xMoveDistance + transform.up * yMoveDistance);
        Vector3 startingScale = transform.localScale;
        Vector3 finalSize = new Vector3(1, finalScale, finalScale);
        var time = TotalTime;
        float elapsedTime = 0;

        yield return new WaitForSecondsRealtime(DelayTime);


        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
           // transform.localScale = Vector3.Lerp(startingScale, finalSize, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PullZone.GetComponent<PullZoneHelper>().updateForce(PullForce);
    }
    
}
