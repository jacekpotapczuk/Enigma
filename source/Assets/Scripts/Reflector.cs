using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Reflector wire setting. The first letter encodes A, second one B, ... and the last one Z. Remember that valid reflector letters have to be connected one to one. If A -> C, than C -> A")]
    private string wireSetting;

    private Dictionary<int, int> connections;

    private void Awake()
    {
        if (wireSetting.Length != LetterConverter.letterCount)
            Debug.LogError("Rotor " + gameObject.name + ". Wrong wire setting. You have to put in 26 characters.");

        connections = new Dictionary<int, int>();

        int i = 0, current;
        foreach (char c in wireSetting)
        {
            current = LetterConverter.CharToInt(c);
            connections.Add(i, current);
            i += 1;
        }
    }

    public int Encode(int letter)
    {
        return connections[letter];
    }
}
