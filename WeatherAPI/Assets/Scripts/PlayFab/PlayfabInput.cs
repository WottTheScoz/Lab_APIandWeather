using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayfabInput : MonoBehaviour
{
    public TMP_InputField deviceID;

    PlayfabManager playfabManager;

    void Start()
    {
        playfabManager = GetComponent<PlayfabManager>();
    }

    public void DeviceIDLogin()
    {
        playfabManager.DeviceIDLoginButtonClicked(deviceID.text);
    }
}
