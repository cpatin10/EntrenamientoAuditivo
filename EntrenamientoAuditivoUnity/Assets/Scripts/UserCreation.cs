using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserCreation : MonoBehaviour {

    public InputField inputUsername;
    public Text warning;

    private string username = "";

    private void Start()
    {
        var submitEvent = new InputField.SubmitEvent();
        submitEvent.AddListener(setUsername);
        inputUsername.onEndEdit = submitEvent;
        setWarningText("");
    }

    public void saveAndSetUser ()
    {
        if (username == "")
        {
            setWarningText("Por favor ingresa un nombre");
        }
        else
        {
            saveUser();
            setCreatedUserToCurrent();
        }
    }
 
    public void setUsername (string username)
    {
        this.username = username;
    }

    // stores data in pc 
    public void saveUser ()
    {
        UserDataManager.saveUser(username);
    }

    // sets the username for playing the game
    public void setCreatedUserToCurrent ()
    {
        UserSetUp.setGameUsername(username);
    }

    private void setWarningText(string message)
    {
        warning.text = message;
    }
}
