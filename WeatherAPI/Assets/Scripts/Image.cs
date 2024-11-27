using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class Image : MonoBehaviour
{
    public string webImage = "https://comicbook.com/wp-content/uploads/sites/4/2021/10/ac368aaa-5b41-45c8-9644-f816b8dd1809.jpg?resize=1024,536";
    
    public MeshRenderer PosterMaterial;
    private Texture2D texture;
    

    private void Start()
    {
        PosterMaterial = gameObject.GetComponent<MeshRenderer>();
        //StartCoroutine(DownloadImage(storeImage));
        GetWebImage(SetImage);
        

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

    public void SetImage(Texture2D image)
    {
        texture = image;
        PosterMaterial.material.mainTexture = texture;
    }

    void GetWebImage(Action<Texture2D> callback)
    {
        if(texture != null)
        {
            callback(texture);
        }
        else
        {
            StartCoroutine(DownloadImage(callback));
        }
    }
}
