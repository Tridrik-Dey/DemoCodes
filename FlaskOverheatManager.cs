using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskOverheatManager : MonoBehaviour
{
    private FlaskTemperatureHandler flaskTemperatureHandler;

    void Start()
    {
        flaskTemperatureHandler = GetComponent<FlaskTemperatureHandler>();
        if (flaskTemperatureHandler == null)
        {
            Debug.LogError("FlaskTemperatureHandler component not found!");
        }
    }

    void Update()
    {
        if (flaskTemperatureHandler != null && flaskTemperatureHandler.IsHeating())
        {
            if (flaskTemperatureHandler.GetCurrentTemperature() >= flaskTemperatureHandler.maxTemperature)
            {
                // This logic is now handled inside FlaskTemperatureHandler
                // So this condition will never be true here
            }
        }
    }
}
