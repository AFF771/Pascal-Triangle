using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Numerics;

public class PascalTriangle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PascalText;
    [SerializeField] int numRows = 6;

    private int inputSize;
    private float TextSize;
    private float fInputSize;

    private int PascalMode;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PascalMode = 0;
            PascalTFunction(inputSize);

        } else if (Input.GetKeyDown(KeyCode.X))
        {
            PascalMode = 1;
            PascalTGraphic(inputSize);
        }

    }

    public void ReadStringInput(string s) // read input text and change text font size acordingly
    {
        inputSize = int.Parse(s) -1;
        fInputSize = float.Parse(s);
        //Debug.Log(inputSize);

        if (inputSize <= 1)
        {
            TextSize = 40;
        }
        else
        {
            TextSize = (65 / (0.3f * fInputSize +1))*1.5f;
        }

        Debug.Log(TextSize);
        PascalText.fontSize = TextSize;

        if (PascalMode == 0)
        {
            PascalTFunction(inputSize);

        } else if (PascalMode == 1)
        {
            PascalTGraphic(inputSize);
        }

    }

    public void PascalTFunction(int size)
    {
        PascalText.text = "";
        string RowAnswer = "";
        //Debug.Log(size);

        int row, column;
        BigInteger n = 1;

        if (size > 0)
        {
            for(row=0; row < (size+1); row++)
            {

                for (column=0; column <= row; column++)
                {
                    if (column == 0 || row == 0)
                    {
                        n = 1;
                        RowAnswer = "";
                    }
                    else
                    {
                        n = n * (row - column + 1) / column;
                    }
                    
                    RowAnswer += (" " + n.ToString() + " ");
                }

                PascalText.text += "<br>" + RowAnswer;
            }
        }
    }

    public void PascalTGraphic(int size)
    {
        PascalText.text = "";
        string RowAnswer = "";
        //Debug.Log(size);

        int row, column;
        BigInteger n = 1;

        if (size > 0)
        {
            for (row = 0; row < (size + 1); row++)
            {

                for (column = 0; column <= row; column++)
                {
                    if (column == 0 || row == 0)
                    {
                        n = 1;
                        RowAnswer = "";
                    }
                    else
                    {
                        n = n * (row - column + 1) / column;
                    }

                    if (n % 2 == 0)
                    {
                        RowAnswer += "   ";
                    }
                    else
                    {
                        RowAnswer += " # ";
                    }
                }

                PascalText.text += "<br>" + RowAnswer;
            }
        }
    }
}
