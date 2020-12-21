using System.Collections.Generic;
using UnityEngine;

public class Plugboard : MonoBehaviour
{
    public string wireSetting;
    public string wireSettingIdentity = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    private Dictionary<KeyCode, KeyCode> connections;

    private PlugboardInput plgInput;

    public bool IsChanging => plgInput.IsChanging;
    
    private void Awake()
    {
        plgInput = GetComponent<PlugboardInput>();
        
        connections = new Dictionary<KeyCode, KeyCode>();
        int i = 0;
        foreach (char c in wireSetting)
        {
            connections.Add(LetterConverter.IntToKeyCode(i), LetterConverter.CharToKeyCode(c));
            i += 1;
        }
    }

    public KeyCode Encode(KeyCode letter)
    {
        return connections[letter];
    }

}
