using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearAgent : MonoBehaviour
{
    [SerializeField] private GameObject _resourceItem;
    
    [SerializeField] private GetPointForAgent _resourceTarget;
    [SerializeField] private GetPointForAgent _factoryTarget;
    private GetRandomPointForAgent _flagTarget;
    
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    private Vector3 _targetPosition;
    private bool _toWork;
    private bool _prevToWork;
    private bool _toFlag;
    private bool _isStopped;

    private void Awake()
    {
        _toWork = true;
        _prevToWork = false;

        SelfInitialize();
    }

    private void SelfInitialize()
    {
        _flagTarget = GameObject.FindGameObjectWithTag("Flag").GetComponent<GetRandomPointForAgent>();
    }
    
    public void GoToFlag()
    {
        _toFlag = true;
        _targetPosition = _flagTarget.GetPoint();

        _animator.SetTrigger("ToWork");
        _resourceItem.gameObject.SetActive(false);
        _agent.SetDestination(_targetPosition);
    }

    
    private void OnFlag()
    {
        _toFlag = false;
        _agent.isStopped = true;
        _targetPosition = Vector3.forward * 1000f;
        _isStopped = true;
        
        _animator.SetTrigger("HappyIdle");
    }
    
    private void Update()
    {
        if (_toFlag && !_isStopped)
        {
            var positionWithoutY = transform.position;
            positionWithoutY.y = 0f;
            
            var targetWithoutY = _targetPosition;
            targetWithoutY.y = 0f;

            if (_agent.isStopped || Vector3.Distance(positionWithoutY, targetWithoutY) < 0.5f)
            {
                OnFlag();
            } 
            
            return;
        }
        
        if (_toWork && !_isStopped)
        {
            if (_prevToWork == false)
                ToWork();

            var positionWithoutY = transform.position;
            positionWithoutY.y = 0f;
            
            var targetWithoutY = _targetPosition;
            targetWithoutY.y = 0f;
            
            if (Vector3.Distance(positionWithoutY, targetWithoutY) < 0.5f)
                _toWork = false; 
        }
        else if (!_isStopped)
        {
            if (_prevToWork)
                FromWork();

            var positionWithoutY = transform.position;
            positionWithoutY.y = 0f;
            
            var targetWithoutY = _targetPosition;
            targetWithoutY.y = 0f;
            
            if (Vector3.Distance(positionWithoutY, targetWithoutY) < 0.5f)
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
