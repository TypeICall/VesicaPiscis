using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n4VesicaPiscis : MonoBehaviour
{
    public float Quartic;
    public bool Vert;
    public bool Horiz;

    public bool Strips;
    public bool Boxes;

    public Transform QuarVert;
    public Transform QuarHoriz;

    // SCALE CHANGES
    // Strips where scale = (1, (Cubic * TRI-Angular #s up to 2n-1)
    // Rectangles(Cubic/2,(Odd numbers up to the (cubic)th odd number)
    // or
    // Tiles where only position is changed and all the scale matrices are the same.
    void Awake()
    {

    }
    void Start()
    {
        float Layers = (Quartic * 2) - 1;
        int TriNum = 0;

        //(1 UNIT BY (Cubic * Triangular NUmbers in palindromic form )) RECTANGLE SUB-DIVISIONS
        if (Strips == true)
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
                    Plane.transform.position = new Vector3(0, 0, 5 * Quartic * (2 * x + 1));
                    Plane.transform.localScale = new Vector3(Quartic * TriNum, 1, Quartic);

                    Plane.transform.SetParent(QuarVert);
                }
                if (Horiz == true)
                {
                    GameObject Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    //Plane.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Plane.transform.position = new Vector3(5 * Quartic * (2 * x + 1), 0, 0);
                    Plane.transform.localScale = new Vector3(Quartic, 1, Quartic * TriNum);
                    Plane.transform.SetParent(QuarHoriz);
                }
            }
        }
        int Odds = -1;
        if (Boxes == true)
        {
            for (float z = -Quartic; z < Quartic; z++)     //1,3,5,7,9 = number of additions in the Triangular Numbers 1, 1+2+1, 1+2+3+2+1, 1+2+3+4+3+2+1, 1+2+3+4+5+4+3+2+1
            {
                if (z < 0)
                {
                    Odds += 2;
                }
                if (z > 0)
                {
                    Odds -= 2;
                }
                if (Vert == true)
                {
                    GameObject Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    //Plane.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Plane.transform.position = new Vector3(0, 0, 5 * Quartic * z + Quartic * 5 / 2);
                    Plane.transform.localScale = new Vector3(Odds * Quartic, 1, Quartic / 2);
                    Plane.transform.SetParent(QuarVert);
                }
                if (Horiz == true)
                {
                    GameObject Plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    //Plane.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Plane.transform.position = new Vector3(5 * Quartic * z + Quartic * 5 / 2, 0, 0);
                    Plane.transform.localScale = new Vector3(Quartic / 2, 1, Odds * Quartic);
                    Plane.transform.SetParent(QuarHoriz);
                }
            }
        }

        {
            void Update()
            {
                if (Input.GetKeyDown(KeyCode.I))
                {

                }
                if (Input.GetKeyDown(KeyCode.O))
                {

                }
            }
        }
    }
}
