using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearAgent : MonoBehaviour
{
    [SerializeField] private GameObject _resourceItem;
    
    [SerializeField] private GetPointForAgent _resourceTarget;
    [SerializeField] private GetPointForAgent _factoryTarget;
    [SerializeField] private GetRandomPointForAgent _flagTarget;
    
    [SerializeField] private float _speed;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    private Vector3 _targetPosition;
    private bool _toWork;
    private bool _prevToWork;
    
    private void Start()
    {
        _toWork = true;
        _prevToWork = false;


    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        
        if (_toWork)
        {
            if (_prevToWork == false)
                ToWork();

            var positionWithoutY = transform.position;
            positionWithoutY.y = 0f;
            
            var targetWithoutY = _targetPosition;
            targetWithoutY.y = 0f;
            
            if (_agent.isStopped || Vector3.Distance(positionWithoutY, targetWithoutY) < 0.5f)
                _toWork = false; 
        }
        else
        {
            if (_prevToWork)
                FromWork();

            var positionWithoutY = transform.position;
            positionWithoutY.y = 0f;
            
            var targetWithoutY = _targetPosition;
            targetWithoutY.y = 0f;
            
            if (_agent.isStopped || Vector3.Distance(positionWithoutY, targetWithoutY) < 0.5f)
                _toWork = true;
            
            //if (Vector3.Distance(transform.position, _startPosition) < 0.5f)
            //    _toWork = true;
        }        
        
        //transform.position += direction * (_speed * Time.deltaTime);
    }

    private void ToWork()
    {
        _toWork = true;
        _prevToWork = true;
        
        _animator.SetTrigger("ToWork");
        
        _resourceItem.gameObject.SetActive(false);
        //transform.forward = Vector3.forward;
        
        _targetPosition = _factoryTarget.GetPoint();
        _agent.SetDestination(_targetPosition);
    }
    
    private void FromWork()
    {
        _toWork = false;
        _prevToWork = false;
        
        _animator.SetTrigger("FromWork");
        _resourceItem.gameObject.SetActive(true);
        transform.forward = Vector3.back;
        
        _targetPosition = _resourceTarget.GetPoint();
        _agent.SetDestination(_targetPosition);
    }
}
