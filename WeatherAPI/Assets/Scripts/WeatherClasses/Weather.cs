using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weather
{
    public Coordinates coord;
    public WeatherData[] weather;
    public string @base;
    public MainData main;
    public int visibility;
    public WindData wind;
    public RainData rain;
    public SnowData snow;
    public CloudData clouds;
    public int dt;
    public SysData sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;

    // When getting a piece of data from a Weather instance, the format should be:
    // Weather.weather[index].property
    // For example, if I want to get the description of an instance named Orlando:
    // string desc = Orlando.weather[0].description
    // As of now, the index seems to be arbitrary, so I'd recommend using 0.
}

[System.Serializable]
public class Coordinates
{
    public float lon;
    public float lat;
}

[System.Serializable]
public class WeatherData
{
    public int id;
    public string main;
    public string description;
    public string icon;
}

[System.Serializable]
public class MainData
{
    public float temp;
    public float feels_like;
    public float temp_min;
    public float temp_max;
    public int pressure;
    public int humidity;
    public int sea_level;
    public int grnd_level;
}

[System.Serializable]
public class WindData
{
    public float speed;
    public int deg;
    public float gust;
}

[System.Serializable]
public class RainData
{
    public float _1h;
}

[System.Serializable]
public class SnowData
{
    public float _1h;
}

[System.Serializable]
public class CloudData
{
    public int all;
}

[System.Serializable]
public class SysData
{
    public int type;
    public int id;
    public string country;
    public int sunrise;
    public int sunset;
}
