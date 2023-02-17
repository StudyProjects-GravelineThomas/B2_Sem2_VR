using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNumber : MonoBehaviour
{
    public int Number = 0;

    public void SetNumberPlus()
    {
        Number +=1;
    }
    public void SetNumberMinus()
    {
        Number -=1;
    }
}
