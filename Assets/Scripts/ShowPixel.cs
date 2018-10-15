using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPixel : MonoBehaviour 
{
	public Texture2D testTexture;

	private void Start()
	{
		for (int i = 0; i < testTexture.height; i++)
		{
			for (int j = 0; j < testTexture.width; j++)
			{
				print("透明通道" + testTexture.GetPixel(i, j).a);
				print(testTexture.GetPixel(i, j));
			}
		}
	}
}
