using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send_Luminous : MonoBehaviour
{
    public GameObject LuminousManager;
    public string LuminousObject;

    public void Send_Lumi()
    {
        if(LuminousObject == "PressurePlate")
        {
            LuminousManager.GetComponent<Luminous>().Luminous_PressurePlate();
        }
        else
        {
            if(LuminousObject == "Key")
            {
                LuminousManager.GetComponent<Luminous>().Luminous_Key();
            }
            else
            {
                if(LuminousObject == "Potion")
                {
                    LuminousManager.GetComponent<Luminous>().Luminous_Potion();
                }
                else
                {
                    if(LuminousObject == "FinalPath")
                    {
                        LuminousManager.GetComponent<Luminous>().Luminous_FinalPath();
                    }
                }
            }
        }
    }
}
