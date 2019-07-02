using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class grid : MonoBehaviour
{
    public int xSize, zSize;
    private Vector3[] _vertices;
    private Mesh _mesh;
    
    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
        _mesh.name = "Procedural Grid";

        _vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        Vector2[] uv = new Vector2[_vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                _vertices[i] = new Vector3(x, 0, z);
                uv[i] = new Vector2((float)x / xSize, (float)z / zSize);
            }
        }

        _mesh.vertices = _vertices;
        _mesh.uv = uv;

        int[] triangles = new int[xSize * zSize * 6];
        for (int ti = 0, vi = 0, z = 0; z < zSize; z++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;                
            }
        }

        _mesh.triangles = triangles;
        _mesh.RecalculateNormals();

        // create new colors array where the colors will be created.
        Color[] colors = new Color[_vertices.Length];

        for (int i = 0; i < _vertices.Length; i++)
        {



            //colors[i] = Color.Lerp(Color.red, Color.green, _vertices[i].x / 10);
            double dist = Vector3.Distance(_vertices[13], _vertices[i]);


            //colors[i] = new Color(_vertices[i].x / 10, 0, _vertices[i].z / 10);
            colors[i] = new Color((float)dist / 10, 1, 1);

            if(Random.Range(0, xSize) > 6)
            {
                colors[i] = new Color(0, 0, 0);
            }

        }            

        // assign the array of colors to the Mesh.
        _mesh.colors = colors;

    }
}
