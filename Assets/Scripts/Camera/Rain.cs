using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Light Light;
    private ParticleSystem _particleSystem;
    private bool _isRain = false;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }
    private void Update()
    {
        if (_isRain && Light.intensity > 0.25f)
            LightIntensity(-1);
        else if (!_isRain && Light.intensity < 0.5f)
            LightIntensity(1);


    }
    private void LightIntensity(int mult)
    {
        Light.intensity += 0.1f * Time.deltaTime * mult;
    }
    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(12f, 18f));

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
