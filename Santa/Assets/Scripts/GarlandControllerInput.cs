using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlandControllerInput : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private GameObject[] _lights;
    [SerializeField] private KeyCode _key;
    private bool _isActive = true;
    void Update()
    {
        if (Input.GetKeyDown(_key))
            SetParticles();

    }

    private void SetParticles()
    {
        _isActive = !_isActive;
        foreach (var objLight in _lights)
            objLight.SetActive(_isActive);
        foreach (var system in _particleSystems) 
            if (_isActive)
                system.Play();
            else
                system.Stop();
    }
}
