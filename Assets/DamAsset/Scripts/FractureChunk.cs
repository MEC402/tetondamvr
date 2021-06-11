using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FractureChunk: MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<Joint, FractureChunk> JointToChunk = new Dictionary<Joint, FractureChunk>();
    private Dictionary<FractureChunk, Joint> ChunkToJoint = new Dictionary<FractureChunk, Joint>();
    public bool HasBrokenJoints;

    public HashSet<FractureChunk> Neighbours = new HashSet<FractureChunk>();
    public FractureChunk[] NeighboursArray = new FractureChunk[0];


    public void Setup()
    {        
        this.Freeze();
        foreach (var joint in GetComponents<Joint>())
        {
            var chunk = joint.connectedBody.gameObject.GetComponent<FractureChunk>();
            JointToChunk[joint] = chunk;
            ChunkToJoint[chunk] = joint;
        }

        foreach (var chunkNode in ChunkToJoint.Keys)
        {
            Neighbours.Add(chunkNode);

            if (chunkNode.Contains(this) == false)
            {
                chunkNode.Neighbours.Add(this);
            }
        }

        NeighboursArray = Neighbours.ToArray();
    }

    private bool Contains(FractureChunk chunkNode)
    {
        return Neighbours.Contains(chunkNode);
    }

    public void Freeze()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Unfreeze()
    {
        var rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.gameObject.layer = LayerMask.NameToLayer("UnFrozenChunks");
    }
       

    private void OnJointBreak(float breakForce)
    {
        HasBrokenJoints = true;
        this.Unfreeze();
    }
    public void CleanBrokenJoints()
    {
        var brokenLinks = JointToChunk.Keys.Where(j => j == false).ToList();
        foreach (var link in brokenLinks)
        {
            var body = JointToChunk[link];

            JointToChunk.Remove(link);
            ChunkToJoint.Remove(body);

            body.Remove(this);
            Neighbours.Remove(body);
        }

        NeighboursArray = Neighbours.ToArray();
        HasBrokenJoints = false;
    }

    private void Remove(FractureChunk chunkNode)
    {
        ChunkToJoint.Remove(chunkNode);
        Neighbours.Remove(chunkNode);
        NeighboursArray = Neighbours.ToArray();
    }

}
