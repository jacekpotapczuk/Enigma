using UnityEngine;

public class RotorManager : MonoBehaviour
{
    [SerializeField]
    private RotorSlot rightRotor;
    [SerializeField]
    private RotorSlot midRotor;
    [SerializeField]
    private RotorSlot leftRotor;
    [SerializeField]
    private ReflectorSlot reflector;

    private bool isDoubleStep = false;

    private void Start()
    {
        leftRotor.OffSet = 0;
        midRotor.OffSet = 0;
        rightRotor.OffSet = 0;
    }

    public bool IsAnyRotorChanging()
    {
        bool anyRotorChanging = false;
        if (rightRotor.IsChanging())
            anyRotorChanging = true;
        if (midRotor.IsChanging())
            anyRotorChanging = true;    
        if (leftRotor.IsChanging())
            anyRotorChanging = true;

        return anyRotorChanging;
    }
    

    public KeyCode Encode(KeyCode letter)
    {

        
        int current = LetterConverter.KeyCodeToInt(letter);
        rightRotor.Rotate();
        current = Utility.Mod((current + rightRotor.OffSet), LetterConverter.letterCount);
        current = rightRotor.Encode(current, false);
        
        //Debug.Log("After right rotor (offset used: " + rightRotor.OffSet + "): " + LetterConverter.IntToChar(current));
        //Debug.Log("aaaa " + rightRotor);
        
        if (rightRotor.ShouldNextRotorShift())
        {
            midRotor.Rotate();
            //Debug.Log("MID ROTOR ROTAION");
        }
        if (isDoubleStep)
        {
            midRotor.Rotate();
            leftRotor.Rotate();
            isDoubleStep = false;
            //Debug.Log("LEFT ROTOR ROTAION");
        }

        if (midRotor.IsOnNotchKey())  // double-step, because of this notch letter in middle rotor is used only to encode one letter
        {
            isDoubleStep = true;
            //Debug.Log("DOUBLE STEP MARKED");
        }
        int posDif;
        posDif = midRotor.OffSet - rightRotor.OffSet;
        current = Utility.Mod((current + posDif), LetterConverter.letterCount);
        current = midRotor.Encode(current, false);
        //Debug.Log("After mid rotor (offset used: " + midRotor.OffSet + "): " + LetterConverter.IntToChar(current));


        posDif = leftRotor.OffSet - midRotor.OffSet;
        current = Utility.Mod((current + posDif), LetterConverter.letterCount);
        current = leftRotor.Encode(current, false);
        //Debug.Log("After left rotor (offset used: " + leftRotor.OffSet + "): " + LetterConverter.IntToChar(current));

        // reflector
        current = Utility.Mod((current - leftRotor.OffSet), LetterConverter.letterCount);
        current = reflector.Encode(current);
        current = Utility.Mod((current + leftRotor.OffSet), LetterConverter.letterCount);
        //Debug.Log("After reflector: " + LetterConverter.IntToChar(current));

        current = leftRotor.Encode(current, true);
        //Debug.Log("After left reversed rotor (offset used: " + leftRotor.OffSet + "): " + LetterConverter.IntToChar(current));

        posDif = midRotor.OffSet - leftRotor.OffSet;
        current = Utility.Mod((current + posDif), LetterConverter.letterCount);
        current = midRotor.Encode(current, true);
        //Debug.Log("After mid reversed rotor (offset used: " + midRotor.OffSet + "): " + LetterConverter.IntToChar(current));

        posDif = rightRotor.OffSet - midRotor.OffSet;
        current = Utility.Mod((current + posDif), LetterConverter.letterCount);
        current = rightRotor.Encode(current, true);
        //Debug.Log("After right reversed rotor (offset used: " + rightRotor.OffSet + "): " + LetterConverter.IntToChar(current));

        current = Utility.Mod((current - rightRotor.OffSet), LetterConverter.letterCount);
        //Debug.Log("Final: " + LetterConverter.IntToChar(current));
        return LetterConverter.IntToKeyCode(current);
    }

}
