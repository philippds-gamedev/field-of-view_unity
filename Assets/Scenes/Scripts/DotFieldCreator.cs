using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotFieldCreator : MonoBehaviour {

    [SerializeField]
    public GameObject Dot;


    // Use this for initialization
    void Start () {
        generateDotGrid();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void generateDotGrid()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject tempDot = Instantiate(Dot, new Vector3(i, 0, j), Quaternion.Euler(90, 0, 0));
                SpriteRenderer rend = tempDot.GetComponent<SpriteRenderer>();
                if (rend != null)
                {
                    rend.color = new Color((float)i / 20, (float)j / 20, 0);
                }
                Debug.Log(tempDot.transform.position.x.ToString("F4"));
            }         
        }
    }

}
