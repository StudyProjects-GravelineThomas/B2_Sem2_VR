using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luminous : MonoBehaviour
{
    public GameObject PressurePlate_Luminous;
    public GameObject Key_Luminous;
    public GameObject Potion_Luminous;
    public GameObject FinalPath_Luminous;
    public int WhichOne =0;
    public string Lum_Obj;

    public void Luminous_PressurePlate()
    {
       PressurePlate_Luminous.SetActive(true); 
    }

    public void Luminous_Key()
    {
        PressurePlate_Luminous.SetActive(false);
        Key_Luminous.SetActive(true);
    }

    public void Luminous_Potion()
    {
        Key_Luminous.SetActive(false);
        Potion_Luminous.SetActive(true);
    }

    public void Luminous_FinalPath()
    {
        Potion_Luminous.SetActive(false);
        FinalPath_Luminous.SetActive(true);
    }

    /*public void LuminousProtocol()
    {
        if(WhichOne ==0)
        {
            PressurePlate_Luminous.SetActive(true);
            WhichOne+=1;
        }
        else
        {
            if(WhichOne ==1)
            {
                PressurePlate_Luminous.SetActive(false);
                Key_Luminous.SetActive(true);
                WhichOne+=1;
            }
            else
            {
                if(WhichOne ==2)
                {
                    Key_Luminous.SetActive(false);
                    Potion_Luminous.SetActive(true);
                    WhichOne+=1;
                }
                else
                {
                    if(WhichOne ==3)
                    {
                        Potion_Luminous.SetActive(false);
                        FinalPath_Luminous.SetActive(true);
                        WhichOne+=1;
                    }
                }
            }

        }
    }*/

}
