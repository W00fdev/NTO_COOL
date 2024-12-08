using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingValue : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _duration;
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private float _fadeSpeed;

    void Start()
    {
        GameObject.Destroy(gameObject, _duration);
    }

    private void Update()
    {
        transform.position += Vector3.up * (Time.deltaTime * _speed);
        _group.alpha -= Time.deltaTime * _fadeSpeed;
        _group.alpha = Mathf.Max(_group.alpha, 0f);
    }
}
