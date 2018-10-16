using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTexCoord : MonoBehaviour 
{
	private void Update()  
	{
		RaycastHit hitInfo;
		if (Input.GetMouseButton(0))
		{
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hitInfo.collider != null)
			{
				Debug.Log(hitInfo.textureCoord);
			}
		}
	}
}
