using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

        Debug.Log(directoryPath);
    }

    // Saves the given data as json format at the end of the file with userDataFilePath
    // In order to do so, stores data in new UserData object
    public static void saveUser(string username)
    {
        UserData data = new UserData(username);
        string jsonString = JsonUtility.ToJson(data);
        File.AppendAllText(userDataFilePath, jsonString);
    }
}
