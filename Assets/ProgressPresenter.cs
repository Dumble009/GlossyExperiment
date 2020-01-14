using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressPresenter : MonoBehaviour
{
	[SerializeField]
	Text progressText;
	[SerializeField]
	Slider progressSlider;
	int _maxCount;
	public int maxCount {
		get {
			return _maxCount;
		}
		set {
			_maxCount = value;
			progressSlider.maxValue = maxCount;
		}
	}

	int _currentCount;
	public int currentCount {
		get {
			return _currentCount;
		}

		set {
			_currentCount = value;
			progressSlider.value = currentCount;
			progressText.text = string.Format("{0}/{1}", currentCount, maxCount);
		}
	}
}
