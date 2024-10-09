//using UnityEngine;
//using UnityEngine.UI;

//public class FlaskTemperatureHandler : MonoBehaviour
//{
//    public float baseTemperature = 40f;
//    public float maxTemperature = 100f;
//    public float heatingTime = 7000f; // Time in milliseconds
//    private float currentTemperature;
//    private float heatingDuration;
//    private Vector3 initialPosition;
//    private Quaternion initialRotation;
//    private bool isHeating = false;
//    private float highestTemperature = 40f;
//    public GameObject solution; // The old solution object
//    public GameObject solutionSpoiled; // The spoiled solution object
//    public Button resetButton; // The reset button
//    private TemperatureDataHandler temperatureDataHandler;

//    void Start()
//    {
//        currentTemperature = baseTemperature;
//        initialPosition = transform.position;
//        initialRotation = transform.rotation;
//        temperatureDataHandler = FindObjectOfType<TemperatureDataHandler>();

//        if (solution != null)
//        {
//            solution.SetActive(true); // Ensure the old solution is active at start
//        }
//        if (solutionSpoiled != null)
//        {
//            solutionSpoiled.SetActive(false); // Initially hide the spoiled solution
//        }
//        if (resetButton != null)
//        {
//            resetButton.gameObject.SetActive(false); // Initially hide the reset button
//            resetButton.onClick.AddListener(ResetSolution); // Add click listener for the reset button
//        }
//    }

//    void Update()
//    {
//        if (isHeating)
//        {
//            heatingDuration += Time.deltaTime * 1000; // Convert to milliseconds
//            currentTemperature = Mathf.Lerp(baseTemperature, maxTemperature, heatingDuration / heatingTime);
//            highestTemperature = Mathf.Max(highestTemperature, currentTemperature);
//            Debug.Log($"Current Temperature: {currentTemperature}°F"); // Print temperature to console

//            if (heatingDuration >= heatingTime && solutionSpoiled != null && !solutionSpoiled.activeSelf)
//            {
//                CrossedLimit();
//            }
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("FlameSource"))
//        {
//            StartHeating();
//        }
//        else if (other.CompareTag("FlatObjectLayer"))
//        {
//            PrintHighestTemperature();
//        }
//        else if (other.CompareTag("FlameSource"))
//        {
//            ResetSolution();
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("FlameSource"))
//        {
//            StopHeating();
//        }
//    }

//    private void StartHeating()
//    {
//        Debug.Log("Starting to heat.");
//        isHeating = true;
//        heatingDuration = 0f; // Reset heating duration
//        currentTemperature = baseTemperature; // Reset temperature
//    }

//    private void StopHeating()
//    {
//        Debug.Log("Stopping heating.");
//        isHeating = false;
//    }

//    private void PrintHighestTemperature()
//    {
//        Debug.Log($"Highest Temperature: {highestTemperature}°F");
//        temperatureDataHandler.SaveTemperature(highestTemperature); // Save highest temperature
//    }

//    private void CrossedLimit()
//    {
//        Debug.Log("DANGER!! YOU HAVE CROSSED LIMIT!! TRY AGAIN.");
//        if (solution != null)
//        {
//            solution.SetActive(false); // Deactivate the old solution
//        }
//        if (solutionSpoiled != null)
//        {
//            solutionSpoiled.SetActive(true); // Activate the spoiled solution
//        }
//        if (resetButton != null)
//        {
//            resetButton.gameObject.SetActive(true); // Show the reset button
//        }
//    }

//    public void ResetSolution()
//    {
//        Debug.Log("Resetting solution.");
//        if (solution != null)
//        {
//            solution.SetActive(true); // Reactivate the old solution
//        }
//        if (solutionSpoiled != null)
//        {
//            solutionSpoiled.SetActive(false); // Deactivate the spoiled solution
//        }
//        if (resetButton != null)
//        {
//            resetButton.gameObject.SetActive(false); // Hide the reset button
//        }
//        currentTemperature = baseTemperature; // Reset temperature to initial value
//        highestTemperature = baseTemperature; // Reset highest temperature to initial value
//        heatingDuration = 0f; // Reset heating duration
//        isHeating = false; // Ensure heating is stopped
//       // Debug.Log($"Highest Temperature: {currentTemperature}°F");
//    }

//    public float GetCurrentTemperature()
//    {
//        return currentTemperature;
//    }

//    public bool IsHeating()
//    {
//        return isHeating;
//    }
//}


using UnityEngine;
using UnityEngine.UI;

public class FlaskTemperatureHandler : MonoBehaviour
{
    public float baseTemperature = 40f;
    public float maxTemperature = 100f;
    public float heatingTime = 7000f; // Time in milliseconds
    private float currentTemperature;
    private float heatingDuration;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isHeating = false;
    private float highestTemperature = 40f;
    public GameObject solution; // The old solution object
    public GameObject solutionSpoiled; // The spoiled solution object
    public Button resetButton; // The reset button
    private TemperatureDataHandler temperatureDataHandler;

    void Start()
    {
        currentTemperature = baseTemperature;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        temperatureDataHandler = FindObjectOfType<TemperatureDataHandler>();

        if (solution != null)
        {
            solution.SetActive(true); // Ensure the old solution is active at start
        }
        if (solutionSpoiled != null)
        {
            solutionSpoiled.SetActive(false); // Initially hide the spoiled solution
        }
        if (resetButton != null)
        {
            resetButton.gameObject.SetActive(false); // Initially hide the reset button
            resetButton.onClick.AddListener(ResetSolution); // Add click listener for the reset button
        }
    }

    void Update()
    {
        if (isHeating)
        {
            heatingDuration += Time.deltaTime * 1000; // Convert to milliseconds
            currentTemperature = Mathf.Lerp(baseTemperature, maxTemperature, heatingDuration / heatingTime);
            highestTemperature = Mathf.Max(highestTemperature, currentTemperature);
            Debug.Log($"Current Temperature: {currentTemperature}°C"); // Print temperature to console

            if (heatingDuration >= heatingTime && solutionSpoiled != null && !solutionSpoiled.activeSelf)
            {
                CrossedLimit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlameSource"))
        {
            StartHeating();
        }
        else if (other.CompareTag("FlatObjectLayer"))
        {
            SaveCurrentTemperature();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FlameSource"))
        {
            StopHeating();
        }
    }

    private void StartHeating()
    {
        Debug.Log("Starting to heat.");
        isHeating = true;
        heatingDuration = 0f; // Reset heating duration
        currentTemperature = baseTemperature; // Reset temperature
    }

    private void StopHeating()
    {
        Debug.Log("Stopping heating.");
        isHeating = false;
    }

    private void SaveCurrentTemperature()
    {
        Debug.Log($"Current Temperature: {currentTemperature}°C");
        temperatureDataHandler.SaveTemperature(currentTemperature); // Save the current temperature
    }

    private void CrossedLimit()
    {
        Debug.Log("DANGER!! YOU HAVE CROSSED LIMIT!! TRY AGAIN.");
        if (solution != null)
        {
            solution.SetActive(false); // Deactivate the old solution
        }
        if (solutionSpoiled != null)
        {
            solutionSpoiled.SetActive(true); // Activate the spoiled solution
        }
        if (resetButton != null)
        {
            resetButton.gameObject.SetActive(true); // Show the reset button
        }
    }

    public void ResetSolution()
    {
        Debug.Log("Resetting solution.");
        if (solution != null)
        {
            solution.SetActive(true); // Reactivate the old solution
        }
        if (solutionSpoiled != null)
        {
            solutionSpoiled.SetActive(false); // Deactivate the spoiled solution
        }
        if (resetButton != null)
        {
            resetButton.gameObject.SetActive(false); // Hide the reset button
        }
        currentTemperature = baseTemperature; // Reset temperature to initial value
        highestTemperature = baseTemperature; // Reset highest temperature to initial value
        heatingDuration = 0f; // Reset heating duration
        isHeating = false; // Ensure heating is stopped
    }

    public float GetCurrentTemperature()
    {
        return currentTemperature;
    }

    public bool IsHeating()
    {
        return isHeating;
    }
}
