using System;
using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEditor;
using UnityEngine;

public class LightGarlandController : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private ParticleSystem _garlandParticle;

    void Update()
    {
        if (_garlandParticle.isStopped)
            SetPositionsToParticle();
        // var particles = new ParticleSystem.Particle[_garlandParticle.main.maxParticles];
        // //var amount = _garlandParticle.GetParticles(particles);
        // for (int i = 0; i < _positions.Length; i++)
        //     particles[i].position = _positions[i].position;
        // _garlandParticle.SetParticles(particles);
    }
    
    private void SetPositionsToParticle()
    {
        _garlandParticle.Play();
        // var particles = new ParticleSystem.Particle[_garlandParticle.main.maxParticles];
        // //var amount = _garlandParticle.GetParticles(particles);
        // for (int i = 0; i < _positions.Length; i++)
        //     particles[i].position = _positions[i].position;
        // _garlandParticle.SetParticles(particles);
    }
}
