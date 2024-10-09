using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TemperatureDataHandler : MonoBehaviour
{
    private string filePath;
    private TemperatureData temperatureData;
    public float baseTemperature = 40f;
    private float currentTemperature;
    private float highestTemperature;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "temperatureData.json");
        // Clear existing data on start
        temperatureData = new TemperatureData();
        currentTemperature = baseTemperature;
        highestTemperature = baseTemperature;
        SaveData(); // Save the cleared state to file
        Debug.Log($"Data file path: {filePath}");
    }

    public void SaveTemperature(float temperature)
    {
        currentTemperature = temperature;
        if (temperature > highestTemperature)
        {
            highestTemperature = temperature;
        }

        temperatureData.temperatures.Add(temperature);
        SaveData();
        Debug.Log($"Saved temperature: {temperature}°C to {filePath}");
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(temperatureData);
        File.WriteAllText(filePath, json);
    }

    private void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            temperatureData = JsonUtility.FromJson<TemperatureData>(json);
            Debug.Log("Loaded data: " + json);
        }
        else
        {
            temperatureData = new TemperatureData();
            Debug.Log("No existing data found. Initialized new temperature data.");
        }
    }

    public float GetCurrentTemperature()
    {
        return currentTemperature;
    }

    public float GetHighestTemperature()
    {
        return highestTemperature;
    }

    public List<float> GetTemperatures()
    {
        return temperatureData.temperatures;
    }
}

[System.Serializable]
public class TemperatureData
{
    public List<float> temperatures;

    public TemperatureData()
    {
        temperatures = new List<float>();
    }
}
