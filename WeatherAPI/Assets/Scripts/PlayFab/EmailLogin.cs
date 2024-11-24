using PlayFab.ClientModels;
using PlayFab;

public class EmailLogin : ILogin
{
    string email;
    string password;

    public EmailLogin(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public void Login(System.Action<LoginResult> onSuccess, System.Action<PlayFabError> onFailure)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = password,
            //CreateAccount = true
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, onSuccess, onFailure);
    }
}
