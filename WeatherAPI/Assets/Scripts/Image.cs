using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Image : MonoBehaviour
{
    private const string webImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Cat_August_2010-4.jpg/2560px-Cat_August_2010-4.jpg";

    private Texture2D billboard;

    private void Start()
    {
        StartCoroutine(DownloadImage(storeImage));

    }

    public IEnumerator DownloadImage(Action<Texture2D> callback) { 
        // add check here to see if texture is taken
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(webImage);
        yield return request.SendWebRequest();
        callback(DownloadHandlerTexture.GetContent(request));

    }

    public void storeImage(Texture2D image)
    {
        image = billboard;
    }
}
