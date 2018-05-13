using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserCreation : MonoBehaviour {

    public InputField inputUsername;
    public Text warning;
    public string sceneName;

    private string username = "";

    private void Start()
    {
        var submitEvent = new InputField.SubmitEvent();
        submitEvent.AddListener(setUsername);
        inputUsername.onEndEdit = submitEvent;
        setWarningText("");
    }

    // saves new user and sets it as the current game user
    // changes scene to the given one
    public void saveAndContinue ()
    {
        if (username == "")
        {
            setWarningText("Por favor ingresa un nombre");
        }
        else if (UserDataManager.usernameExists(username)) {
            setWarningText("Este nombre ya existe, por favor escoge uno nuevo");
        }
        else
        {
            saveUser();
            setCreatedUserToCurrent();
            ChangeScene();
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

    // sets the given string as the message of the warning text
    private void setWarningText(string message)
    {
        warning.text = message;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
