using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class MetalGenerator : MonoBehaviour
{
    public Transform ResourcePoint;
    public FloatingValue _value;

    public ResourcesScript Resources;
    
    private float _timer;

    private void Awake()
    {
        Resources = GameObject.FindWithTag("Resources").GetComponent<ResourcesScript>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 1f)
        {
            _timer -= 1f;
            GameObject.Instantiate(_value, ResourcePoint.position, Quaternion.identity);
            Resources.AddHoney();
        }
    }
}
