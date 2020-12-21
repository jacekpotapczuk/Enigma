using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorSlot : MonoBehaviour
{
    [SerializeField]private Reflector[] reflectors;
    [SerializeField]private int activeReflector;

    public void ChangeReflector(int index)
    {
        activeReflector = index;
        //Debug.Log("Zmieniam na " + index);
    }
    
    public int Encode(int letter)
    {
        return reflectors[activeReflector].Encode(letter);
    }
    
    
}
