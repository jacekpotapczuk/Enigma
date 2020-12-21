using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorSlot : MonoBehaviour
{
    [SerializeField]private Rotor[] rotors;
    [SerializeField]private int activeRotor;
    [SerializeField] private RotorRotator rotorRotator;

    public void ChangeRotor(int index)
    {
        activeRotor = index;
        //Debug.Log("Zmieniam na " + index);
    }
    
    public int OffSet
    {
        set => rotors[activeRotor].OffSet = value;
        get => rotors[activeRotor].OffSet;
    }

    public void Rotate()
    {
        rotors[activeRotor].Rotate();
    }
    
    public int Encode(int letter, bool reversed)
    {
        return rotors[activeRotor].Encode(letter, reversed);
    }
    
    public bool ShouldNextRotorShift()
    {
        return rotors[activeRotor].ShouldNextRotorShift();
    }

    public bool IsOnNotchKey()
    {
        return rotors[activeRotor].IsOnNotchKey();
    }


    public bool IsChanging()
    {
        return rotorRotator.IsClicked;
    }
    private void Update()
    {
        if (!rotorRotator.IsClicked)
        {
            rotorRotator.UpdateOffSetDirectly(rotors[activeRotor].OffSet);
        }
    }
    
    
}
