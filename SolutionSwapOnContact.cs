using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionSwapOnContact : MonoBehaviour
{
    public GameObject initialSolution;  // Assign this in the inspector
    public GameObject replacementSolution; // Assign this in the inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the flame
        if (other.CompareTag("FlameSource"))
        {
            // Disable the initial solution and enable the replacement
            if (initialSolution.activeInHierarchy)
            {
                initialSolution.SetActive(false);
                replacementSolution.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optionally, revert back to the original solution when leaving the flame area
        if (other.CompareTag("FlameSource"))
        {
            if (replacementSolution.activeInHierarchy)
            {
                replacementSolution.SetActive(false);
                initialSolution.SetActive(true);
            }
        }
    }
}
