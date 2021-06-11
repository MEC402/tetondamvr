using Project.Scripts.Fractures;
using Project.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FractureManager : MonoBehaviour
{
    // Start is called before the first frame update
    private FractureChunk[] chunks;
    private bool RunSearch = false;
    public float stress;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.tag != "Static")
            {

                var collider = child.gameObject.AddComponent<MeshCollider>();
                collider.convex = true;


                var body = child.gameObject.AddComponent<Rigidbody>();
                body.constraints = RigidbodyConstraints.FreezeAll;
                body.mass = 10;
                child.gameObject.AddComponent<FractureChunk>();
                //body.isKinematic = true;

                FractureUtils.ConnectTouchingChunks(child.gameObject, stress);
            }
        }

        chunks = this.GetComponentsInChildren<FractureChunk>();
        foreach (FractureChunk chunk in chunks)
        {
            chunk.Setup();
        }

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (child.tag != "Static")
                {
                    var body = child.gameObject.GetComponent<Rigidbody>();
                    body.isKinematic = false;
                    body.AddForce(this.transform.forward * 400);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        
        foreach (var brokenNodes in chunks.Where(n => n.HasBrokenJoints))
        {
            brokenNodes.CleanBrokenJoints();
            RunSearch = true;
        }
        //sif (RunSearch)
            //sSearchGraph(chunks);

    }

    public void SearchGraph(FractureChunk[] objects)
    {
        var anchors = objects.Where(o => o.GetComponent<Rigidbody>().isKinematic).ToList();

        ISet<FractureChunk> search = new HashSet<FractureChunk>(objects);
        foreach (var o in anchors)
        {
            if (search.Contains(o))
            {
                var subVisited = new HashSet<FractureChunk>();
                Traverse(o, search, subVisited);
                search = search.Where(s => subVisited.Contains(s) == false).ToSet();
            }
        }
        foreach (var sub in search)
        {
            sub.Unfreeze();
        }
    }

    private void Traverse(FractureChunk o, ISet<FractureChunk> search, ISet<FractureChunk> visited)
    {
        if (search.Contains(o) && visited.Contains(o) == false)
        {
            visited.Add(o);

            for (var i = 0; i < o.NeighboursArray.Length; i++)
            {
                var neighbour = o.NeighboursArray[i];
                Traverse(neighbour, search, visited);
            }
        }
    }

}
