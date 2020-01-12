using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePresenter : MonoBehaviour
{
	[SerializeField]
	SpriteRenderer renderer;
	[SerializeField]
	Image imageRenderer;

	public void ShowImage(Sprite sprite)
	{
		renderer.sprite = sprite;
		imageRenderer.sprite = sprite;
	}
}
