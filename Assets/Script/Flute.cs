using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class Flute : MonoBehaviour
{
    public string portName = "/dev/cu.usbmodem1431";
    SerialPort sp;

    public static bool breath = false;
    public static bool C = false;
    public static bool D = false;
    public static bool E = false;
    public static bool F = false;
    public static bool G = false;
    public static bool A = false;
    public static bool B = false;

    void Start()
    {
        sp = new SerialPort(portName, 9600);
        sp.Open();
        sp.ReadTimeout = 1;
    }

    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                int bite = sp.ReadByte();
                //print(bite);

                switch (bite)
                {
                    case 1: C = true; print("C"); break;
                    case 2: D = true; print("D"); break;
                    case 3: E = true; print("E"); break;
                    case 4: F = true; print("F"); break;
                    case 5: G = true; print("G"); break;
                    case 6: A = true; print("A"); break;
                    case 7: B = true; print("B"); break;

                    case 8: C = false; print("release C"); break;
                    case 9: D = false; print("release D"); break;
                    case 10: E = false; print("release E"); break;
                    case 11: F = false; print("release F"); break;
                    case 12: G = false; print("release G"); break;
                    case 13: A = false; print("release A"); break;
                    case 14: B = false; print("release B"); break;

                    case 15: breath = true; print("Breath"); break;
                    case 16: breath = false; print("stop breathing"); break;

                    default: break;
                }
            }
            catch (System.Exception)
            {
                //print("ReadByte error");
            }
        }

    }
}
