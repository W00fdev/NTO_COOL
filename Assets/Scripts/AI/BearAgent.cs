using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAgent : MonoBehaviour
{
    [SerializeField] private GameObject _resourceItem;
    
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;
    
    private bool _toWork;
    private bool _prevToWork;
    
    private void Start()
    {
        _startPosition = transform.position;
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

            direction = (_targetPosition - _startPosition).normalized;

            if (Vector3.Distance(transform.position, _targetPosition) < 0.5f)
                _toWork = false;
        }
        else
        {
            if (_prevToWork)
                FromWork();

            direction = (_startPosition - _targetPosition).normalized;
            
            if (Vector3.Distance(transform.position, _startPosition) < 0.5f)
                _toWork = true;
        }        
        
        transform.position += direction * (_speed * Time.deltaTime);
        
    }

    private void ToWork()
    {
        _toWork = true;
        _prevToWork = true;
        
        _animator.SetTrigger("ToWork");
        
        _resourceItem.gameObject.SetActive(false);
        transform.forward = Vector3.forward;
    }
    
    private void FromWork()
    {
        _toWork = false;
        _prevToWork = false;
        
        _animator.SetTrigger("FromWork");
        _resourceItem.gameObject.SetActive(true);
        transform.forward = Vector3.back;
    }
}
