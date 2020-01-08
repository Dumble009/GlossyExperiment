using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePresenter : MonoBehaviour
{
	[SerializeField]
	SpriteRenderer renderer;

	public void ShowImage(Sprite sprite)
	{
		renderer.sprite = sprite;
	}
}
