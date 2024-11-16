using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weather
{
    public WeatherData[] weather;

    // When getting a piece of data from a Weather instance, the format should be:
    // Weather.weather[index].property
    // For example, if I want to get the description of an instance named Orlando:
    // string desc = Orlando.weather[0].description
    // As of now, the index seems to be arbitrary, so I'd recommend using 0.
}

[System.Serializable]
public class WeatherData
{
    public int id;
    public string main;
    public string description;
    public string icon;
}
