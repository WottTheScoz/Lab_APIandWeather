using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class Image : MonoBehaviour
{
    public string webImage = "https://comicbook.com/wp-content/uploads/sites/4/2021/10/ac368aaa-5b41-45c8-9644-f816b8dd1809.jpg?resize=1024,536";

    private Texture2D posterTexture2D;
    public MeshRenderer PosterMaterial;

    private void Start()
    {
        //StartCoroutine(DownloadImage(storeImage));
        GetWebImage(storeImage);
        PosterMaterial = gameObject.GetComponent<MeshRenderer>();

    }

    public IEnumerator DownloadImage(Action<Texture2D> callback) { 
        // add check here to see if texture is taken
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(webImage))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("The request ran into a protocol error");
            }

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("The request ran into a connection error");
            }
            else
            {
                callback(DownloadHandlerTexture.GetContent(request));
            }
        }
        
    }

    public void storeImage(Texture2D image)
    {
        if (posterTexture2D == null)
        {
            posterTexture2D = image;
            PosterMaterial.material.mainTexture = image;

        }
        else
        {
            PosterMaterial.material.mainTexture = posterTexture2D;
        }
        
    }

    void GetWebImage(Action<Texture2D> callback)
    {
        if(posterTexture2D != null)
        {
            callback(posterTexture2D);
        }
        else
        {
            StartCoroutine(DownloadImage(callback));
        }
    }
}
