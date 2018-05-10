using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

// based on https://www.youtube.com/watch?v=Z_hJYKv6uO0&t=434s

public class UserDataManager : MonoBehaviour {

    // Paths for storing data
    private static string directoryPath;
    private static string userDataFilePath;

    private void Awake()
    {
        // Creates if it does not exist directory to hold the user data
        // it will store in root app directory
        directoryPath = Path.Combine(Application.dataPath, "Users");
        Directory.CreateDirectory(directoryPath);
        userDataFilePath = Path.Combine(directoryPath, "users.txt");
    }

    // Saves the given data as json format at the end of the file with userDataFilePath
    // In order to do so, stores data in new UserData object
    public static void saveUser(string username)
    {
        UserData data = new UserData(username);
        string jsonString = JsonUtility.ToJson(data) + " ";
        File.AppendAllText(userDataFilePath, jsonString);
    }

    // determines if a given username was already in use
    public static bool usernameExists (string username)
    {
        string usersFile = loadUsers();
        username = "\"" + username + "\"";
        if (usersFile.Contains(username))
        {
            return true;
        }
        return false;

        /*
        string[] stringSeparators = new string[] { " " };
        string usersFile = loadUsers();
        string[] usersJson = usersFile.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        */

    }

    // load file storing users into a string
    private static string loadUsers()
    {
        if (!File.Exists(userDataFilePath))
        {
            return "";
        }
        string jsonString = File.ReadAllText(userDataFilePath);
        return jsonString;
    }


}
