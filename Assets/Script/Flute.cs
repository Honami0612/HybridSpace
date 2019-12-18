using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class Flute : MonoBehaviour
{
    public string portName = "/dev/cu.usbmodem1431";
    SerialPort sp;
    public bool useFlute = true;

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

    public AudioSource audioSourceC;
    public AudioSource audioSourceD;
    public AudioSource audioSourceE;
    public AudioSource audioSourceF;
    public AudioSource audioSourceG;
    public AudioSource audioSourceA;
    public AudioSource audioSourceB;

    public AudioClip soundC;
    public AudioClip soundD;
    public AudioClip soundE;
    public AudioClip soundF;
    public AudioClip soundG;
    public AudioClip soundA;
    public AudioClip soundB;



    void Start()
    {
        sp = new SerialPort(portName, 9600);
        sp.Open();
        sp.ReadTimeout = 1;
    }

    void Update()
    {
        FalsifyAllUpDown();

        if (useFlute)
        {
            UpdateFluteStatus();
        }
        else
        {
            UpdateFluteStatusByKey();
        }
        
        CheckAudio();
    }




    void FalsifyAllUpDown()
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
    }




    void UpdateFluteStatus()
    {
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




    void UpdateFluteStatusByKey()
    {
        C = Input.GetKey(KeyCode.R);
        D = Input.GetKey(KeyCode.E);
        E = Input.GetKey(KeyCode.W);
        F = Input.GetKey(KeyCode.U);
        G = Input.GetKey(KeyCode.I);
        A = Input.GetKey(KeyCode.O);
        B = Input.GetKey(KeyCode.P);

        C_down = Input.GetKeyDown(KeyCode.R);
        D_down = Input.GetKeyDown(KeyCode.E);
        E_down = Input.GetKeyDown(KeyCode.W);
        F_down = Input.GetKeyDown(KeyCode.U);
        G_down = Input.GetKeyDown(KeyCode.I);
        A_down = Input.GetKeyDown(KeyCode.O);
        B_down = Input.GetKeyDown(KeyCode.P);

        C_up = Input.GetKeyUp(KeyCode.R);
        D_up = Input.GetKeyUp(KeyCode.E);
        E_up = Input.GetKeyUp(KeyCode.W);
        F_up = Input.GetKeyUp(KeyCode.U);
        G_up = Input.GetKeyUp(KeyCode.I);
        A_up = Input.GetKeyUp(KeyCode.O);
        B_up = Input.GetKeyUp(KeyCode.P);
    }



    void CheckAudio()
    {
        if (C_down) audioSourceC.PlayOneShot(soundC);
        if (D_down) audioSourceD.PlayOneShot(soundD);
        if (E_down) audioSourceE.PlayOneShot(soundE);
        if (F_down) audioSourceF.PlayOneShot(soundF);
        if (G_down) audioSourceG.PlayOneShot(soundG);
        if (A_down) audioSourceA.PlayOneShot(soundA);
        if (B_down) audioSourceB.PlayOneShot(soundB);

        if (C_up) audioSourceC.Stop();
        if (D_up) audioSourceD.Stop();
        if (E_up) audioSourceE.Stop();
        if (F_up) audioSourceF.Stop();
        if (G_up) audioSourceG.Stop();
        if (A_up) audioSourceA.Stop();
        if (B_up) audioSourceB.Stop();
    }




}
