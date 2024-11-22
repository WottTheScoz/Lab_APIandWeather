using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeatherControl : MonoBehaviour
{
    private WeatherParser data;
    
   public Dictionary<string, Material> skyboxes = new Dictionary<string, Material>();
   public List<Material> materials;

    private void Start()
    {
        data = GetComponent<WeatherParser>();
        data.OnParse += CheckWeather;
        foreach (Material mat in materials)
        {
            string temp = mat.name;
            skyboxes.Add(temp, mat);
        }
        
        //SetWeather("Night");
    }
    

    
    // this function sets the weather
    private void CheckWeather(Weather weather)
    {
        bool isClear = weather.clouds.all > 50;
        DateTime currentTime = DateTime.UtcNow;
        DateTime sunrise = DateTimeOffset.FromUnixTimeSeconds(weather.sys.sunrise).UtcDateTime;
        DateTime sunset = DateTimeOffset.FromUnixTimeSeconds(weather.sys.sunset).UtcDateTime;
       //int Sunrise = weather.sys.sunrise + weather.timezone;
       //int Sunset = weather.sys.sunset + weather.timezone;
        // Check if its raining 1/8
        if (weather.rain._1h > 1)
        {
            SetWeather("Rainy");
        }
        
        // Check if its snowing 2/8
        if (weather.snow._1h > 1)
        {
            SetWeather("Snowy");
        }
        
        
        // if its night and is clear
        switch (isClear)
        {
            case true:
                if (currentTime.CompareTo(sunrise) == 0)
                {
                    SetWeather("Sunrise");
                }else if (currentTime.CompareTo(sunrise) == -1)
                {
                    SetWeather("Night");
                }else if (currentTime.CompareTo(sunrise) == 1 && currentTime.CompareTo(sunset) == -1)
                {
                    SetWeather("Day");
                }else if (currentTime.CompareTo(sunset) == 0)
                {
                    SetWeather("Sunset");
                }
                else if (currentTime.CompareTo(sunset) == 1)
                {
                    SetWeather("Night");
                }
                else
                {
                    Debug.Log("Somethings Wrong");
                }
                break;
            case false:
                if (currentTime.CompareTo(sunrise) == 0)
                {
                    SetWeather("Sunrise");
                }else if (currentTime.CompareTo(sunrise) == -1)
                {
                    SetWeather("Night_Moonless");
                }else if (currentTime.CompareTo(sunrise) == 1 && currentTime.CompareTo(sunset) == -1)
                {
                    SetWeather("Day_Sunless");
                }else if (currentTime.CompareTo(sunset) == 0)
                {
                    SetWeather("Sunset");
                }
                else if (currentTime.CompareTo(sunset) == 1)
                {
                    SetWeather("Night_Moonless");
                }
                else
                {
                    Debug.Log("Somethings Wrong");
                }
                break;
                
        }
    }

    private void SetWeather(string condition)
    {
        
        RenderSettings.skybox = skyboxes[condition];
        
    }
}
