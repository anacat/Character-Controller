using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExplosionController : MonoBehaviour
{
    public List<ParticleSystem> explosionParticles;

    public void PlayExplosion()
    {
        foreach(ParticleSystem particles in explosionParticles)
        {
            particles.Play();
        }
    }
}
