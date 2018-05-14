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
        usernames = UserDataManager.getUsersList();
        UserDataManager.printList(usernames);

        createButtons();
    }

    // Update is called once per frame
    void Update () {

    }

    private void createButtons ()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject goButton = (GameObject)Instantiate(buttonPrefab);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            int tempInt = i;

            tempButton.GetComponentInChildren<Text>().text = "" + i;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }
}
