using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlandControllerInput : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystems;
    private bool _isActive;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            SetParticles();

    }

    private void SetParticles()
    {
        _isActive = !_isActive;
        foreach (var system in _particleSystems) 
            if (_isActive)
                system.Play();
            else
                system.Stop();
    }
}
