using UnityEngine;

public class GetPointForAgent : MonoBehaviour
{
    [SerializeField] private Transform _point;
    
    public virtual Vector3 GetPoint() 
        => _point.position;
}