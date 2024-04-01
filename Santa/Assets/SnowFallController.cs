using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFallController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _snowParticle;

    private void Start()
    {
        StartSnow();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartSnow();
    }

    private void StartSnow()
    {
        var isActive = !_snowParticle.isPlaying;
        if (isActive)
            _snowParticle.Play();
        else
            _snowParticle.Pause();
    }
}
