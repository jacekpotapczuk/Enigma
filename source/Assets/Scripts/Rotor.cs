using System.Collections.Generic;
using UnityEngine;



public class Rotor : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Rotor wire setting. The first letter encodes A, second one B, ... and the last one Z.")]
    private string wireSetting;

    [SerializeField]
    private string notchKey;
    private int notchKeyInt;

    private Dictionary<int, int> connections;
    private Dictionary<int, int> connectionsReversed;

    public int OffSet { set; get; }

    private RotorRotator rotation;

    private void Awake()
    {
        if (wireSetting.Length != LetterConverter.letterCount)
            Debug.LogError("Rotor " + gameObject.name + ". Wrong wire setting. You have to put in 26 characters.");
        if (notchKey.Length != 1 && notchKey.Length != 0)
            Debug.LogError("Rotor " + gameObject.name + ". Notch key is supposed to be 1 character.");
        if(notchKey.Length > 0) // TODO: ZROBIC REFLECTOR CLASS
            notchKeyInt = LetterConverter.CharToInt(notchKey[0]);
        OffSet = 0;
        connections = new Dictionary<int, int>();
        connectionsReversed = new Dictionary<int, int>();

        int i = 0, current;
        foreach (char c in wireSetting)
        {
            current = LetterConverter.CharToInt(c);
            connections.Add(i, current);
            connectionsReversed.Add(current, i);
            i += 1;
        }
    }

    public void Rotate()
    {
        OffSet = Utility.Mod((OffSet + 1), LetterConverter.letterCount);
    }

    public int Encode(int letter, bool reversed)
    {
        if (reversed)
            return connectionsReversed[letter];
        else
            return connections[letter];
    }

    public bool ShouldNextRotorShift()  // should be called always after making a rotation
    {
        if (OffSet == Utility.Mod(notchKeyInt + 1, LetterConverter.letterCount))
            return true;
        else
            return false;
    }

    public bool IsOnNotchKey()
    {
        if (OffSet == notchKeyInt)
            return true;
        else
            return false;
    }

}
