using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Adding buttons dynamically based on https://forum.unity.com/threads/how-to-create-ui-button-dynamically.393160/

public class UserListLoad : MonoBehaviour {

    public GameObject buttonPrefab;
    public RectTransform ParentPanel;
    public string nextScene;

    private string[] usernames;

    // Use this for initialization
    void Start ()
    {
        retreiveUsernames();
        createButtons();
    }

    // gets the usernames array saved in memory
    private void retreiveUsernames ()
    {
        usernames = UserDataManager.getUsersList();
    }

    // Creates buttons that represent the usernames currently saved
    private void createButtons ()
    {
        foreach (string username in usernames)
        {
            GameObject goButton = (GameObject)Instantiate(buttonPrefab);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();

            tempButton.GetComponentInChildren<Text>().text = username;

            tempButton.onClick.AddListener(() => ButtonClicked(username));
        }
    }

    // Logic when one button representing the username is clicked
    // Sets the username for the game and changes the scene
    void ButtonClicked(string username)
    {
        setCurrentUsername(username);
        ChangeScene();
    }

    // sets the username for playing the game
    private void setCurrentUsername(string username)
    {
        UserData.setCurrentUserame(username);
    }

    // changes current scene to defined one
    private void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
