using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n3VesicaPiscis : MonoBehaviour
{
    public float Cubic;
    public bool Vert;
    public bool Horiz;

    public bool Strips;
    public bool Boxes;

    public Transform CubicVert;
    public Transform CubicHoriz;
    // SCALE CHANGES
    // Strips where scale = (1, (Cubic * TRI-Angular #s up to 2n-1)
    // Rectangles(Cubic/2,(Odd numbers up to the (cubic)th odd number)
    // or
    // Tiles where only position is changed and all the scale matrices are the same.
    void Awake()
    {
        int Squared = (int)Mathf.Pow(Cubic, 2);
        //Cubic = (int)Mathf.Pow(Cubic, 3);

    }
    void Start()
    {
        float Layers = (Cubic * 2) - 1;
        int TriNum = 0;

        //(1 UNIT BY (Cubic * Triangular NUmbers in palindromic form )) RECTANGLE SUB-DIVISIONS
        if(Strips == true)
        {
            for (float x = (-Layers / 2); x < (Layers / 2); x++)     //1,3,5,7,9 = number of additions in the Triangular Numbers 1, 1+2+1, 1+2+3+2+1, 1+2+3+4+3+2+1, 1+2+3+4+5+4+3+2+1
            {
                if (x < 0)
                {
                    TriNum++;
                }
                else
                {
                    TriNum--;
                }
                if (Vert == true)
                {
                    GameObject Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    //Plane.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Plane.transform.position = new Vector3(0, 0, 10 * x + 5);
                    Plane.transform.localScale = new Vector3(Cubic * TriNum, 1, 1);
                    Plane.transform.SetParent(CubicVert);
                }
                if (Horiz == true)
                {
                    GameObject Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    //Plane.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Plane.transform.position = new Vector3(10 * x +5 , 0, 0);
                    Plane.transform.localScale = new Vector3(1, 1, Cubic * TriNum);
                    Plane.transform.SetParent(CubicHoriz);
                }
            }
        }

        int Odds = -1;
        //((Cubic/2) BY (Odd #s in Palindrome form))Rectangle Sub-Division
        if (Boxes == true)
        {
            for (float z = -Cubic ; z < Cubic; z++)     //1,3,5,7,9 = number of additions in the Triangular Numbers 1, 1+2+1, 1+2+3+2+1, 1+2+3+4+3+2+1, 1+2+3+4+5+4+3+2+1
            {
                if (z < 0)
                {
                    Odds+=2;
                }
                if(z > 0)
                {
                    Odds-=2;
                }
                if (Vert == true)
                {
                    GameObject Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    //Plane.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Plane.transform.position = new Vector3(0, 0, 5 * Cubic * z + Cubic * 5 / 2 );
                    Plane.transform.localScale = new Vector3(Odds, 1, Cubic/2);
                    Plane.transform.SetParent(CubicVert);
                }
                if (Horiz == true)
                {
                    GameObject Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    //Plane.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Plane.transform.position = new Vector3(5 * Cubic* z + Cubic * 5 / 2, 0, 0);
                    Plane.transform.localScale = new Vector3(Cubic/2, 1, Odds);
                    Plane.transform.SetParent(CubicHoriz);
                }
            }
        }

        //TILES

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {

        }
        if (Input.GetKeyDown(KeyCode.O))
        {

        }
    }
}
