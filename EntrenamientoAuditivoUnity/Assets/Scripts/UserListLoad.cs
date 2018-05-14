using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserListLoad : MonoBehaviour {

    public GameObject buttonPrefab;

    public RectTransform ParentPanel;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < 25; i++)
        {
            GameObject goButton = (GameObject)Instantiate(buttonPrefab);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            int tempInt = i;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }

    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void createButton ()
    {
        GameObject goButton = (GameObject)Instantiate(buttonPrefab);
        Button tempButton = goButton.GetComponent<Button>();
    }
}
