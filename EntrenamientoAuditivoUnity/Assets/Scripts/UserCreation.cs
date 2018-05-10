using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserCreation : MonoBehaviour {

    public InputField inputUsername;
    private string username;

    private void Start()
    {
        var submitEvent = new InputField.SubmitEvent();
        submitEvent.AddListener(setUsername);
        inputUsername.onEndEdit = submitEvent;
    }

    public void saveAndSetUser ()
    {
        saveUser();
        setCreatedUserToCurrent();
    }
 
    public void setUsername (string username)
    {
        this.username = username;
    }

    public void saveUser ()
    {
        UserDataManager.saveUser(username);
    }

    public void setCreatedUserToCurrent ()
    {
        UserSetUp.setGameUsername(username);
    }
}
