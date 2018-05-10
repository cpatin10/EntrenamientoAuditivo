using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData {

    private static string currentUsername = "";

    public string username;

	public UserData (string username)
    {
        this.username = username;
    }

    public static void setCurrentUserame (string username)
    {
        currentUsername = username;
    }

    public static string getCurrentUsername ()
    {
        return currentUsername;
    }
}
