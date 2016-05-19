﻿using UnityEngine;
using System.Collections;

public class ParticlePlayer : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem bloodExplosion;
    [SerializeField]
    private ParticleSystem bloodBursts;
    [SerializeField]
    private ParticleSystem speedLines;

    void Start()
    {
        CollisionDetection.OnDeadEvent += BloodExplosion;
        CollisionDetection.OnImpaleEvent += BloodBursts;
        Player.OnSpeedLinesEvent += ToggleSpeedLines;
    }

    void Update()
    {

    }

    void BloodExplosion()
    {
        bloodExplosion.Play();
    }

    void BloodBursts(Collision collision)
    {
        bloodBursts.Play();
    }

    void OnDestroy()
    {
        CollisionDetection.OnDeadEvent -= BloodExplosion;
        CollisionDetection.OnImpaleEvent -= BloodBursts;
        Player.OnSpeedLinesEvent -= ToggleSpeedLines;
    }

    void ToggleSpeedLines()
    {
        if (speedLines.isPlaying)
        {
            speedLines.Stop();
        }
        else
        {
            speedLines.Play();
        }
    }
}