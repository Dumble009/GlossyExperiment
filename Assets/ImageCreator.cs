﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageCreator : MonoBehaviour
{
	private void Awake()
	{
		string resourcesPath = Application.dataPath + "/Resources/" + rootDirName + "/";
		fileNamesList = new List<string[]>();

		fileNamesList.Add(GetFileNamesUnderPath(resourcesPath + "1"));
		fileNamesList.Add(GetFileNamesUnderPath(resourcesPath + "2"));
		if (is4Classes)
		{
			fileNamesList.Add(GetFileNamesUnderPath(resourcesPath + "3"));
			fileNamesList.Add(GetFileNamesUnderPath(resourcesPath + "4"));
		}
	}
	

	List<string[]> fileNamesList;
	[SerializeField]
	ImagePresenter presenter;
	[SerializeField]
	ExperimentConductor exConductor;
	[SerializeField]
	string rootDirName;
	[SerializeField]
	bool is4Classes;

	public void LoadImage(int index)
	{
		int length = fileNamesList[index].Length;
		int imageIndex = Random.Range(0, length);
		string fileName = fileNamesList[index][imageIndex];

		Sprite sprite = Resources.Load<Sprite>(rootDirName + "/" + (index + 1).ToString() + "/" + fileName);
		Debug.Log(fileName);
		presenter.ShowImage(sprite);
	}

	string[] GetFileNamesUnderPath(string path)
	{
		string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
		
		List<string> retFileNames = new List<string>();

		foreach (string file in files)
		{
			retFileNames.Add(Path.GetFileNameWithoutExtension(file));
		}

		return retFileNames.ToArray();
	}
}
