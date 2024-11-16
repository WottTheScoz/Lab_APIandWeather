using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherParser : MonoBehaviour
{
    public delegate void ParserDelegate(Weather weather);
    public event ParserDelegate OnParse;

    public void ParseJson(string data)
    {
        Weather weather = JsonUtility.FromJson<Weather>(data);

        OnParse?.Invoke(weather);
    }
}
