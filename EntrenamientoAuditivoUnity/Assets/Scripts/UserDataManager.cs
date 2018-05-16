﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

// based on https://www.youtube.com/watch?v=Z_hJYKv6uO0&t=434s

public class UserDataManager : MonoBehaviour {

    // Paths for storing data
    private static string directoryPath;
    private static string userDataFilePath;

    public static readonly string USERS_DIRECTORY_NAME = "Users";

    private void Awake()
    {
        // Creates if it does not exist directory to hold the user data
        // it will store in root app directory
        directoryPath = Path.Combine(Application.dataPath, USERS_DIRECTORY_NAME);
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
        string[] users = getUsersList();
        foreach (string user in users)
        {
            if (String.Equals(user, username))
            {
                return true;
            }
        }
        return false;
    }

    public static string[] getUsersList ()
    {
        string usersFile = loadUsers();

        if (String.Equals(usersFile, ""))
        {
            return new string[0];
        }        

        string[] stringSeparators = new string[] { " " };
        string[] usersJson = usersFile.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        string[] list = new string[usersJson.Length];

        for (int i = 0; i < list.Length; ++i)
        {
            list[i] = getUserInRegister(usersJson[i]);
        }

        return list;
    }

    // Gets the username in a register
    private static string getUserInRegister(string register)
    {
        int usernameBeginning = register.IndexOf(':') + 2;
        int usernameEnd = register.LastIndexOf('\"');
        int usernameLenght = usernameEnd - usernameBeginning;

        string username = register.Substring(usernameBeginning, usernameLenght);
        return username;
    }

    // For debugging purposes
    // prints string array
    public static void printList(string[] list)
    {
        foreach (string user in list)
        {
            Debug.Log(user);
        }
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
