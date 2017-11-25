using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingMesh : MonoBehaviour {

	int sideWidth = 10;

	// Use this for initialization
	void Start () {
		Mesh mesh = new Mesh();
		mesh.vertices = CreateParabloid(10, 10);
		mesh.triangles = TriangulateMesh();
		mesh.uv = CalculateUVs();
		mesh.RecalculateNormals();
		gameObject.GetComponent<MeshFilter>().mesh = mesh;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector3[] CreateParabloid(float width, float height){
		Vector3[] vertices = new Vector3[sideWidth * sideWidth];
		for (int x = 0; x < sideWidth; x++) {
			for (int y = 0; y < sideWidth; y++) {

				float py = height / (sideWidth - 1) * y;
				float px = -Sqrt(py) + (2*Sqrt(py) / (sideWidth - 1) * x);
				float pz = -Sqrt(Math.Max(y - px * px, 0));

				Debug.Log(py);

				vertices[y + x * sideWidth] = new Vector3(px, py, pz);
			}
		}
		return vertices;
	}

	int[] TriangulateMesh()	{
		int[] indices = new int[(sideWidth - 1) * (sideWidth - 1) * 6];

		for (int x = 0; x < sideWidth - 1; x++) {
			for (int y = 0; y < sideWidth - 1; y++) {
				int location = x * sideWidth + y;
				int index = x * (sideWidth - 1) + y;
				indices[index * 6] = location;
				indices[index * 6 + 1] = location + 1;
				indices[index * 6 + 2] = location + sideWidth + 1;

				indices[index * 6 + 3] = location;
				indices[index * 6 + 4] = location + sideWidth + 1;
				indices[index * 6 + 5] = location + sideWidth;
			}
		}

		return indices;
	}

	Vector2[] CalculateUVs() {

		Vector2[] uvs = new Vector2[sideWidth * sideWidth];

		for (int x = 0; x < sideWidth; x++) {
			for (int y = 0; y < sideWidth; y++) {
				uvs[y + x * sideWidth] = new Vector2(1 / (float)sideWidth * x, 1 / (float)sideWidth * y);
			}
		}

		return uvs;
	}

	float Sqrt(float num){
		return (float)Math.Sqrt(num);
	}
}

