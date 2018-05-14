using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Adding buttons dynamically based on https://forum.unity.com/threads/how-to-create-ui-button-dynamically.393160/

public class UserListLoad : MonoBehaviour {

    public GameObject buttonPrefab;
    public RectTransform ParentPanel;

    private string[] usernames;

    // Use this for initialization
    void Start ()
    {
        retreiveUsernames();
        createButtons();
    }

    private void retreiveUsernames ()
    {
        usernames = UserDataManager.getUsersList();
    }

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

    void ButtonClicked(string buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }
}
