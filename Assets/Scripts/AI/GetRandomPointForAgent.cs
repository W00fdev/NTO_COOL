using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomPointForAgent : GetPointForAgent
{
    public Transform[] Points;
    private int _indexer;
    
    public override Vector3 GetPoint()
    {
        return Points[_indexer].position;
    }
}
