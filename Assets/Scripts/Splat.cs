using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splat : MonoBehaviour 
{
	//墨水层纹理
	private Texture2D _inkTexture;
	//物体材质
	private Material _material;
	//墨水层绘制是否可用
	[SerializeField]
	private bool isEnable = false;
	//纹理宽度与高度
	[SerializeField]
	private int textureWidth = 256;
	[SerializeField]
	private int textureHeight = 256;
	private readonly Color init_color = new Color(0, 0, 0, 0);

	public RawImage testi;

	/// <summary>
	/// 初始化墨水层的纹理,检测是否可用
	/// </summary>
	private void Awake()
	{
		Renderer renderer = GetComponent<Renderer>();
		if (renderer == null)
		{
			//Debug.Log("Lost Renderer");
			return;
		}
		_material = renderer.material;
		if (_material == null)
		{
			//Debug.Log("No Material");
			return;
		}
		if (_material.shader.name == "Custom/SplatShader")
		{
			//Debug.Log("true");
			_inkTexture = new Texture2D(textureWidth, textureHeight);
			for (int i = 0; i < textureWidth; i++)
			{
				for (int j = 0; j < textureHeight; j++)
				{
					_inkTexture.SetPixel(i, j, init_color);
				}
			}
			_inkTexture.Apply();
			//设置shader里的墨水层纹理
			_material.SetTexture("_InkTex", _inkTexture);
			testi.texture = _inkTexture;
			isEnable = true;
		}
	}

	public void SplatInk(Vector2 texcoord, Texture2D splatTex)
	{
		//Debug.Log("splat");
		if (!isEnable)
		{
			return;
		}
		//计算在墨水层的绘制原点
		int o_x = (int)(texcoord.x * textureWidth) - splatTex.width / 2;
		int o_y = (int)(texcoord.y * textureHeight) - splatTex.height / 2;
		int x, y;
		Color existColor, inkColor;
		Color finalColor;
		//将当前的颜色画在墨水层的相应位置
		for (int i = 0; i < splatTex.width; i++)
		{
			for (int j = 0; j < splatTex.height; j++)
			{
				x = o_x + i;
				y = o_y + j;
				if (x >= textureWidth)
				{
					x = textureWidth;
				}
				if (y >= textureHeight)
				{
					y = textureHeight;
				}
				Debug.Log(x + "," + y);
				existColor = _inkTexture.GetPixel(x, y);
				inkColor = splatTex.GetPixel(i, j);
				finalColor = Color.Lerp(existColor, inkColor, inkColor.a);
				finalColor.a = existColor.a + inkColor.a;
				_inkTexture.SetPixel(x, y, finalColor);
			}
		}
		_inkTexture.Apply();
	}
}
