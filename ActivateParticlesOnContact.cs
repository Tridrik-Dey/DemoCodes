using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticlesOnContact : MonoBehaviour
{
    public new ParticleSystem particleSystem; // Assign this via the inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the target that should trigger the particle emission
        if (other.CompareTag("FlameSource")) // Make sure to set the tag "FlameSource" on your flame animator GameObject
        {
            if (particleSystem != null && !particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optionally stop the particle system when the flask leaves the trigger zone
        if (other.CompareTag("FlameSource"))
        {
            if (particleSystem != null && particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}
