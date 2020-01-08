using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExperimentConductor : MonoBehaviour
{
    void Awake()
    {
		classList = new List<int>();
		currentIndex = 0;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < imageCountPerClass; j++)
			{
				classList.Add(i);
			}
		}
		
		classList = classList.OrderBy(i => System.Guid.NewGuid()).ToList();

		cm_Data = new ConfusionMatrixData();
    }

	private void Start()
	{
		ShowNextImage();
	}

	List<int> classList;
	int currentIndex;
	int currentClass;
	bool createJsonFlag = false;
	[SerializeField]
	ImageCreator imageCreator;
	[SerializeField]
	int imageCountPerClass;
	[SerializeField]
	JsonCreator jsonCreator;
	ConfusionMatrixData cm_Data;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			KeyDowned(0);
		}
		else if(Input.GetKeyDown(KeyCode.Keypad2))
		{
			KeyDowned(1);
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			KeyDowned(2);
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			KeyDowned(3);
		}
	}

	void KeyDowned(int predictedClass)
	{
		cm_Data.correctClasses.Add(currentClass);
		cm_Data.predictedClasses.Add(predictedClass);

		ShowNextImage();
	}

	void ShowNextImage()
	{
		if (currentIndex < classList.Count)
		{
			currentClass = classList[currentIndex];
			imageCreator.LoadImage(currentClass);

			currentIndex++;
		}
		else
		{
			if (!createJsonFlag)
			{
				jsonCreator.CreateJson(cm_Data);

				createJsonFlag = true;
			}
		}
	}
}

[System.Serializable]
public class ConfusionMatrixData
{
	public List<int> correctClasses;
	public List<int> predictedClasses;

	public ConfusionMatrixData()
	{
		correctClasses = new List<int>();
		predictedClasses = new List<int>();
	}
}
