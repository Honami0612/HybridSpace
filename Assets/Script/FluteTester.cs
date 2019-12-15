using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class FluteTester : MonoBehaviour
{
    private Text targetText;

    //public string portName = "/dev/cu.usbmodem1431";
    //SerialPort sp;

    //private bool breath = false;
    //private bool C = false;
    //private bool D = false;
    //private bool E = false;
    //private bool F = false;
    //private bool G = false;
    //private bool A = false;
    //private bool B = false;

    void Start()
    {
        //sp = new SerialPort(portName, 9600);
        //sp.Open();
        //sp.ReadTimeout = 1;
        targetText = GetComponent<Text>();
    }

    void Update()
    {
        //if (sp.IsOpen)
        //{
        //    try
        //    {
        //        int bite = sp.ReadByte();
        //        print(bite);

        //        switch (bite)
        //        {
        //            case 1: C = true; break;
        //            case 2: D = true; break;
        //            case 3: E = true; break;
        //            case 4: F = true; break;
        //            case 5: G = true; break;
        //            case 6: A = true; break;
        //            case 7: B = true; break;

        //            case 8: C = false; break;
        //            case 9: D = false; break;
        //            case 10: E = false; break;
        //            case 11: F = false; break;
        //            case 12: G = false; break;
        //            case 13: A = false; break;
        //            case 14: B = false; break;

        //            case 15: breath = true; break;
        //            case 16: breath = false; break;

        //            default: break;
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        //print("ReadByte error");
        //    }
        //}

        targetText.text = "";
        targetText.text += "Breath: " + Flute.breath + "\n\n";
        targetText.text += "C: " + Flute.C + "\n";
        targetText.text += "D: " + Flute.D + "\n";
        targetText.text += "E: " + Flute.E + "\n";
        targetText.text += "F: " + Flute.F + "\n";
        targetText.text += "G: " + Flute.G + "\n";
        targetText.text += "A: " + Flute.A + "\n";
        targetText.text += "B: " + Flute.B + "\n";

    }
}
