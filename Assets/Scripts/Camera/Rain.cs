using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private bool _isRain = false;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(120f, 180f));

            if (_isRain)
            {
                _particleSystem.Stop();
            }
            else
            {
                _particleSystem.Play();
            }
            _isRain = !_isRain;
        }
    }
}
