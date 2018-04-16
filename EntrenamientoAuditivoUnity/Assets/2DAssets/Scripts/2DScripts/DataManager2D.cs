 using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager2D : MonoBehaviour {

	// Paths for storing data	
	private static string _directoryPath;
	private static string _firstLvlFilePath;

	private void Awake()
	{
		// Creates if it does not exist directory to hold the user data
		// it will store in root app directory
		_directoryPath = Path.Combine(Application.dataPath, "UserData");
		Directory.CreateDirectory(_directoryPath);
      
		_firstLvlFilePath = Path.Combine(_directoryPath, "firstLevel.txt");
	}

	// Saves the given data as json format at the end of the file with secondLvlFilePath
	// In order to do so, stores data in new AnswerData3D object
	static public void SaveFirstLvlAnswer(bool correct, int expectedInterval, int inputInterval,
		string firstNote, string expectedNote, string inputNote, float time)
	{
		AnswerData2D data = new AnswerData2D(correct, expectedInterval, inputInterval, firstNote, expectedNote, inputNote, time);
		string jsonString = JsonUtility.ToJson(data);
		File.AppendAllText(_firstLvlFilePath, jsonString);
	}
}
