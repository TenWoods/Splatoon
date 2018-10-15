using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMesh : MonoBehaviour 
{
	private MeshFilter mf;
	//private MeshRenderer mr;
	[SerializeField]
	private int pointNum;

	public Material mat;

	private void Start() 
	{
		mf = GetComponent<MeshFilter>();
		//mr = GetComponent<MeshRenderer>();
		//DrawTriangle();
		//DrawSquare();
		DrawCircle(pointNum, 0, 0, 1);
	}

	private void Update() 
	{
		
	}

	private void DrawTriangle()
	{
		Mesh m = mf.mesh;
		m.Clear();
		Vector3[] vertices = new Vector3[]{new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)};
		m.vertices = vertices;
		m.triangles = new int[]{0, 1, 2};
	}

	private void DrawSquare()
	{
		Mesh m = mf.mesh;
		m.Clear();
		Vector3[] vertices = new Vector3[]{new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(0, 1, 0)};
		m.vertices = vertices;
		m.triangles = new int[]{0, 1, 2, 
								0, 2, 3};
	}

	private void DrawCircle(int pointNum, float x, float y, float r)
	{
		Mesh m = mf.mesh;
		Vector3[] vertices = new Vector3[pointNum + 1];
		vertices[0] = new Vector3(x, y, 0);
		float a = 0;
		for(int i = 1; i < vertices.Length; i++)
		{
			vertices[i] = new Vector3(x + r * Mathf.Cos(a), y + r * Mathf.Sin(a));
			a += 2 * Mathf.PI / pointNum;
		}
		int[] triangles = new int[3 * pointNum];
		for (int i = 0, j = 1; i < 3 * pointNum - 3; i += 3, j++)
		{
			triangles[i] = 0;
			triangles[i + 1] = j;
			triangles[i + 2] = j + 1;
		}
		triangles[3 * pointNum - 3] = 0;
		triangles[3 * pointNum - 2] = pointNum;
		triangles[3 * pointNum - 1] = 1;
		m.Clear();
		m.vertices = vertices;
		m.triangles = triangles;
		m.RecalculateNormals();
	}
}
