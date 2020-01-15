using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainingConductor : MonoBehaviour
{
	void Awake()
	{
		Random.InitState(2);
		classList = new List<int>();
		currentIndex = 0;
		int classCount = (is4Classes) ? 4 : 2;
		for (int i = 0; i < classCount; i++)
		{
			for (int j = 0; j < imageCountPerClass; j++)
			{
				classList.Add(i);
			}
		}

		progressPresenter.maxCount = classCount * imageCountPerClass;

		classList = classList.OrderBy(i => Random.value).ToList();
	}

	private void Start()
	{
		ShowNextImage();
	}

	List<int> classList;
	int currentIndex;
	int currentClass;
	bool finishedFlag = false;
	[SerializeField]
	ImageCreator imageCreator;
	[SerializeField]
	int imageCountPerClass;
	[SerializeField]
	JsonCreator jsonCreator;
	public bool is4Classes;
	[SerializeField]
	ProgressPresenter progressPresenter;
	[SerializeField]
	Text correctLabel;
	[SerializeField]
	Text marubatsu;

	bool isKeyAcceptable = true;

	private void Update()
	{
		if (isKeyAcceptable)
		{
			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				KeyDowned(0);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad2))
			{
				KeyDowned(1);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad3) && is4Classes)
			{
				KeyDowned(2);
			}
			else if (Input.GetKeyDown(KeyCode.Keypad4) && is4Classes)
			{
				KeyDowned(3);
			}
		}
	}

	void KeyDowned(int predictedClass)
	{
		StartCoroutine(ShowAnswerAnimation(currentClass, predictedClass));
	}

	IEnumerator ShowAnswerAnimation(int correct, int predict)
	{
		isKeyAcceptable = false;
		correctLabel.text = "答え:" + (correct + 1).ToString();
		if (correct == predict)
		{
			marubatsu.text = "O";
		}
		else
		{
			marubatsu.text = "X";
		}
		marubatsu.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		marubatsu.gameObject.SetActive(false);

		yield return new WaitForSeconds(1.5f);

		correctLabel.text = "答え:";
		isKeyAcceptable = true;
		ShowNextImage();
	}

	void ShowNextImage()
	{
		progressPresenter.currentCount = currentIndex;
		if (currentIndex < classList.Count)
		{
			currentClass = classList[currentIndex];
			imageCreator.LoadImage(currentClass);

			currentIndex++;
		}
		else
		{
			if (!finishedFlag)
			{
				correctLabel.gameObject.SetActive(false);
				progressPresenter.ShowFinishMessage();
				finishedFlag = true;

				StartCoroutine(LoadSceneDelay(2.0f));
			}
		}
	}

	IEnumerator LoadSceneDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("TestScene");
	}
}

