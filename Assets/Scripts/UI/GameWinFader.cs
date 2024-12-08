using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvas;
    private float _speed = 1.5f;

    private void Awake()
    {
        _canvas.alpha = 0f;
    }

    void Update()
    {
        _canvas.alpha += Time.deltaTime * _speed;
        _canvas.alpha = Math.Min(_canvas.alpha, 1f);
    }
}
