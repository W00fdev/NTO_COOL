using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomPointForAgent : GetPointForAgent
{
    public Transform[] Points;
    private int _indexer;
    
    public override Vector3 GetPoint()
    {
        int index = _indexer;
        _indexer++;
        _indexer %= Points.Length;
        return Points[index].position;
    }
}
