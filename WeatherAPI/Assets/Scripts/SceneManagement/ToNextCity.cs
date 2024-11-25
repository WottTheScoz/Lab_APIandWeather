using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextCity : MonoBehaviour
{
    public int maxBuildIndex = 2;

    public void ChangeCity()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if(nextIndex > maxBuildIndex)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextIndex);
        }
    }
}
