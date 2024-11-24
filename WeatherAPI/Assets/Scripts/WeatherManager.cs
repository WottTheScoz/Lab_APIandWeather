using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class WeatherManager : MonoBehaviour
{
    private Scene currentcity;
    
    private string city;
    
    string jsonApi;

    // Start is called before the first frame update
    void Start()
    {
        currentcity = SceneManager.GetActiveScene();
        city = currentcity.name;
        jsonApi = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=62526569f093fe87422ee692264bccfa";
        StartCoroutine(GetWeatherJson(OnJsonDataLoaded));
    }

    public void OnJsonDataLoaded(string data)
    {
        //Debug.Log(data);
        WeatherParser parser = GetComponent<WeatherParser>();
        parser.ParseJson(data);
    }

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using(UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError($"network problem: {request.error}");
            } 
            else if(request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"response error: {request.error}");
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetWeatherJson(Action<string> callback)
    {
        return CallAPI(jsonApi, callback);
    }
}
