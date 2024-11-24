using PlayFab.ClientModels;
using PlayFab;
using UnityEngine;

public class PlayfabManager
{
    LoginManager loginManager;
    string savedEmailKey = "SavedEmail";
    string userEmail;

    void Start()
    {
        loginManager = new LoginManager();

        // Check if email is saved
        if(PlayerPrefs.HasKey(savedEmailKey))
        {
            string savedEmail = PlayerPrefs.GetString(savedEmailKey);

            // Auto-login with saved email
            EmailLoginButtonClicked(savedEmail, "Saved Password");
        }
    }

    // Example method for triggering email login
    public void EmailLoginButtonClicked(string email, string password)
    {
        userEmail = email;
        loginManager.SetLoginMethod(new EmailLogin(email, password));
        loginManager.Login(OnLoginSuccess, OnLoginFailure);
    }

    // Example method for triggering device ID login
    public void DeviceIDLoginButtonClicked(string deviceID)
    {
        loginManager.SetLoginMethod(new DeviceLogin(deviceID));
        loginManager.Login(OnLoginSuccess, OnLoginFailure);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful!");
        // You can handle success here, such as loading player data

        // Save email for future auto-login
        if(!string.IsNullOrEmpty(userEmail))
            PlayerPrefs.SetString(savedEmailKey, userEmail);

        // Load player data
        LoadPlayerData(result.PlayFabId);
    }

    void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.ErrorMessage);
    }

    void LoadPlayerData(string playFabId)
    {
        var request = new GetUserDataRequest
        {
            PlayFabId = playFabId
        };

        PlayFabClientAPI.GetUserData(request, OnDataSuccess, OnDataFailure);
    }

    void OnDataSuccess(GetUserDataResult result)
    {
        // Process player data here
        Debug.Log("Player data loaded successfully");
    }

    void OnDataFailure(PlayFabError error)
    {
        Debug.LogError("Failed to load player data: " + error.ErrorMessage);
    }
}
