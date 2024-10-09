
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ShowTemperaturePanel : MonoBehaviour
{
    public GameObject temperaturePanel;  // The panel that will be shown
    public TextMeshProUGUI temperatureText; // The TextMeshProUGUI element that displays the temperature
    public string flaskTag = "Flask";    // Tag to identify the flask object
    public TemperatureDataHandler temperatureDataHandler; // Reference to the TemperatureDataHandler script

    private void Start()
    {
        // Ensure the panel is initially hidden
        if (temperaturePanel != null)
        {
            temperaturePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the flask
        if (other.CompareTag(flaskTag))
        {
            // Retrieve the latest temperature data from the flask
            float currentTemperature = temperatureDataHandler.GetCurrentTemperature();

            // Display the temperature on the panel
            if (temperatureText != null)
            {
                temperatureText.text = $"Current Temperature: {currentTemperature}°C";
            }

            // Show the panel
            if (temperaturePanel != null)
            {
                temperaturePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the flask
        if (other.CompareTag(flaskTag))
        {
            // Hide the panel when the flask is removed
            if (temperaturePanel != null)
            {
                temperaturePanel.SetActive(false);
            }
        }
    }
}

