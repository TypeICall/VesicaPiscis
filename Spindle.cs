using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spindle : MonoBehaviour
{
    public float Quartic;
    public bool Vert;
    public bool Horiz;

    public Transform QuarVert;
    public Transform QuarHoriz;

    public bool Strips;
    public bool Boxes;
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
        int yTriNum = 0;
        if (Strips == true)
        {
            for (float y = -Layers / 2 + 1; y < Layers / 2; y++)            //Y Layers total centered about the XY plane so it goes half in pos y and half in neg y
            {
                float Stripes = Mathf.Abs(y) * 2 - 1;                               // Number of strips in each layer,odd numbers = 1,3,5,7,9,
                TriNum = 0;
                if(y < 0)
                {
                    yTriNum++;
                }
                else
                {
                    yTriNum--;
                }
                for (float x = (-Stripes / 2); x < (Stripes / 2)-1; x++)   //How many layers there are along the Y axis.
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
                        GameObject Bawx = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if(y >= 0)
                        {
                            Bawx.transform.position = new Vector3(10 * Stripes * (x + 1), 5 * y * (Stripes - 1), 0);
                        }
                        else
                        {
                            Bawx.transform.position = new Vector3(10 * Stripes * (x + 1), 5*y*(Stripes -1), 0);
                        }
                        Bawx.transform.localScale = new Vector3(Stripes * 10, Stripes*10, Stripes * TriNum * 10);
                        Bawx.transform.SetParent(QuarVert);
                    }
                    if (Horiz == true)
                    {
                        GameObject Bawx = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (y > 0)
                        {
                            Bawx.transform.position = new Vector3(0, 5 * y * (Stripes - 1), 10 * x * Stripes + Stripes * 10);
                        }
                        else
                        {
                            Bawx.transform.position = new Vector3(0, 5 * y * (Stripes - 1), 10 * x * Stripes + Stripes * 10);
                        }
                        Bawx.transform.localScale = new Vector3(Stripes * TriNum * 10, 10*Stripes, Stripes * 10);
                        Bawx.transform.SetParent(QuarVert);
                    }
                }
            }
        }

        int Count = 0;

        if (Boxes == true)
        {
            for (float z = -Quartic; z < Quartic - 1; z++)     //1,3,5,7,9 = number of additions in the Triangular Numbers 1, 1+2+1, 1+2+3+2+1, 1+2+3+4+3+2+1, 1+2+3+4+5+4+3+2+1
            {
                if (z < 0)
                {
                    Count++;
                }
                if (z >= 0)
                {
                    Count--;
                }
                if (Vert == true)
                {
                    GameObject Bawx = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //Bawx.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Bawx.transform.position = new Vector3(10 * Quartic * (z + 1), 0, 0);
                    Bawx.transform.localScale = new Vector3(Quartic * 10, Quartic * 10, Quartic * Count * 10);
                    Bawx.transform.SetParent(QuarVert);
                }
                if (Horiz == true)
                {
                    GameObject Bawx = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //Bawx.transform.rotation.eulerAngles = new Vector3(90,0,0);
                    Bawx.transform.position = new Vector3(0, 0, 10 * Quartic * (z + 1));
                    Bawx.transform.localScale = new Vector3(Quartic * Count * 10, Quartic * 10, Quartic * 10);
                    Bawx.transform.SetParent(QuarHoriz);
                }
            }
        }

        //TILES

    }

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
