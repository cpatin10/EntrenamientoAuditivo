using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSetUp : MonoBehaviour {

    // sets username to be used in the game
    public static void setGameUsername(string username)
    {
        UserData.setCurrentUserame(username);

        Debug.Log("usuario de juego: " + UserData.getCurrentUsername());
    }
}
