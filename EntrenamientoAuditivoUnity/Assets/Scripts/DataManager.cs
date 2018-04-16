using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour {

    // Paths for storing data
    private static string directoryPath;
    private static string secondLvlFilePath;
    private static string firstLvlFilePath;  

    private void Awake()
    {
        // Creates if it does not exist directory to hold the user data
        // it will store in root app directory
        directoryPath = Path.Combine(Application.dataPath, "UserData");
        Directory.CreateDirectory(directoryPath);
      
        secondLvlFilePath = Path.Combine(directoryPath, "secondLevel.txt");
        firstLvlFilePath = Path.Combine(directoryPath, "firstLevel.txt");
    }

    // Saves the given data as json format at the end of the file with secondLvlFilePath
    // In order to do so, stores data in new AnswerData3D object
    static public void saveSecondLvlAnswer(bool correct, int expectedInterval, int inputInterval,
        string firstNote, string expectedNote, string inputNote, float time)
    {
        AnswerData3D data = new AnswerData3D(correct, expectedInterval, inputInterval, firstNote, expectedNote, inputNote, time);
        string jsonString = JsonUtility.ToJson(data);
        File.AppendAllText(secondLvlFilePath, jsonString);
    }
    
    // Saves the given data as json format at the end of the file with secondLvlFilePath
    // In order to do so, stores data in new AnswerData3D object
    static public void saveFirstLvlAnswer(bool correct, int expectedInterval,
        string firstNote, string expectedNote, string inputNote, float time)
    {
        AnswerData2D data = new AnswerData2D(correct, expectedInterval, firstNote, expectedNote, inputNote, time);
        string jsonString = JsonUtility.ToJson(data);
        File.AppendAllText(secondLvlFilePath, jsonString);
    }
}
