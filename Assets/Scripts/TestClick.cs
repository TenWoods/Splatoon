using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClick : MonoBehaviour 
{  
    [SerializeField]
    private Texture2D splatTexture;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider != null)
                {
                    Splat s = hitInfo.collider.GetComponent<Splat>();
                    if (s != null)
                    {
                        //Debug.Log(hitInfo.textureCoord);
                        s.SplatInk(hitInfo.textureCoord, splatTexture);
                    }
                }
            }
        }
    }
}
