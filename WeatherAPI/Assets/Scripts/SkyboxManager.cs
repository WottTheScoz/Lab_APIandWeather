using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public Material clouds;
    public Material rain;

    Skyboxes skyboxes;

    WeatherParser parser;

    private void Start()
    {
        skyboxes.AddSkybox("clouds", clouds);
        skyboxes.AddSkybox("rain", rain);

        parser = GetComponent<WeatherParser>();
        parser.OnParse += ChangeSkybox;
    }

    public void ChangeSkybox(Weather weather) 
    {
        string[] names = skyboxes.GetNames();

        for (int i = 0; i < names.Length; ++i) 
        {
            if (weather.weather[0].main.Equals(name))
            {
                // logic for changing skybox
                Material[] materials = skyboxes.GetMaterials();
                RenderSettings.skybox = materials[i];
                break;
            }
        }
    }
}
