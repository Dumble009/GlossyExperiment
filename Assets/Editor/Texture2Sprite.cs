using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Texture2Sprite : AssetPostprocessor
{
	void OnPreprocessTexture()
	{
		TextureImporter textureImporter = assetImporter as TextureImporter;

		textureImporter.textureType = TextureImporterType.Sprite;
	}
}
