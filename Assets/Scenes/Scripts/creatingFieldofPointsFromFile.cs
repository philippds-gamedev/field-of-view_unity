using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class creatingFieldofPointsFromFile : MonoBehaviour {

    [SerializeField]
    public GameObject Dot;

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }


    /*
    // Use this for initialization
    void Start()
    {
        myMesh = GetComponent<MeshFilter>().mesh;


        int[] nakedVertex = new int[myMesh.vertexCount];

        //myMesh.vertices[0].


        //Debug.Log(myMesh.vertexCount.ToString("F4"));

        for (int i = 0; i < myMesh.triangles.Length; i++)
        {
            nakedVertex[myMesh.triangles[i]]++;
        }

        for (int i = 0; i < myMesh.vertexCount; i++)
        {
            GameObject tempDot = Instantiate(Dot, new Vector3(myMesh.vertices[i].x, 0, -myMesh.vertices[i].y), Quaternion.Euler(90, 0, 0));
            if (nakedVertex[i] <= 5)
            {
                SpriteRenderer rend = tempDot.GetComponent<SpriteRenderer>();
                rend.color = new Color(0, 0, 0);
            }
            //Debug.Log(tempDot.transform.position.x.ToString("F4"));
            
            
            if (rend != null)
            {
                rend.color = new Color((float)i / 20, (float)j / 20, 0);
            }
            Debug.Log(tempDot.transform.position.x.ToString("F4"));
        }
    }
    */
    
    /*
    // Update is called once per frame
    void Update()
    {

    }
    */
}
