using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayVertices : MonoBehaviour {


    Mesh myMesh;

    [SerializeField]
    public GameObject Dot;

    // Use this for initialization
    void Start () {
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
            if(nakedVertex[i] <= 5)
            {
                SpriteRenderer rend = tempDot.GetComponent<SpriteRenderer>();
                rend.color = new Color(0,0,0);
            }
            //Debug.Log(tempDot.transform.position.x.ToString("F4"));
            /*
            
            if (rend != null)
            {
                rend.color = new Color((float)i / 20, (float)j / 20, 0);
            }
            Debug.Log(tempDot.transform.position.x.ToString("F4"));
            */
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
