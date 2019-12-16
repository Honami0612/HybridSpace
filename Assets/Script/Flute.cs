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

    public static bool breath_down = false;
    public static bool C_down = false;
    public static bool D_down = false;
    public static bool E_down = false;
    public static bool F_down = false;
    public static bool G_down = false;
    public static bool A_down = false;
    public static bool B_down = false;

    public static bool breath_up = false;
    public static bool C_up = false;
    public static bool D_up = false;
    public static bool E_up = false;
    public static bool F_up = false;
    public static bool G_up = false;
    public static bool A_up = false;
    public static bool B_up = false;

    void Start()
    {
        sp = new SerialPort(portName, 9600);
        sp.Open();
        sp.ReadTimeout = 1;
    }

    void Update()
    {
        C_down = false;
        D_down = false;
        E_down = false;
        F_down = false;
        G_down = false;
        A_down = false;
        B_down = false;

        C_up = false;
        D_up = false;
        E_up = false;
        F_up = false;
        G_up = false;
        A_up = false;
        B_up = false;

        if (sp.IsOpen)
        {
            try
            {
                int bite = sp.ReadByte();
                //print(bite);

                switch (bite)
                {
                    case 1: C = true; C_down = true; print("C"); break;
                    case 2: D = true; D_down = true; print("D"); break;
                    case 3: E = true; E_down = true; print("E"); break;
                    case 4: F = true; F_down = true; print("F"); break;
                    case 5: G = true; G_down = true; print("G"); break;
                    case 6: A = true; A_down = true; print("A"); break;
                    case 7: B = true; B_down = true; print("B"); break;

                    case 8: C = false; C_up = true; print("release C"); break;
                    case 9: D = false; D_up = true; print("release D"); break;
                    case 10: E = false; E_up = true; print("release E"); break;
                    case 11: F = false; F_up = true; print("release F"); break;
                    case 12: G = false; G_up = true; print("release G"); break;
                    case 13: A = false; A_up = true; print("release A"); break;
                    case 14: B = false; B_up = true; print("release B"); break;

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
