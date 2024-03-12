using UnityEngine;
using System.Collections;

public class ParticleToTarget : MonoBehaviour
{
    public float suckCD = 1f;
    private Transform Target;
    private ParticleSystem particle;
    private static ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1000];
    int count;

    void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
        particle = GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        count = particle.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle particle = particles[i];
            if ((particle.startLifetime - particle.remainingLifetime) < suckCD) return;
            
            Vector3 v1 = this.particle.transform.TransformPoint(particle.position);
            Vector3 v2 = Target.position;
            
            Vector3 tarPos = (v2 - v1) *  (particle.remainingLifetime / (particle.startLifetime-suckCD));
            particle.position = this.particle.transform.InverseTransformPoint(v2 - tarPos);
            particles[i] = particle;
        }

        particle.SetParticles(particles, count);
    }

    void ParticleToTargetUpdate()
    {
        
    }
}