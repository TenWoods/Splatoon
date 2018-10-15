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
			Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)), Camera.main.transform.forward, out hitInfo);
			if (hitInfo.collider != null)
			{
				Debug.Log(hitInfo.textureCoord);
			}
		}
	}
}
