using System.Collections.Generic;
using UnityEngine;

public class Lampboard : MonoBehaviour
{
    [SerializeField]
    private Lamp[] lamps;

    private Dictionary<KeyCode, Lamp> lampDict;

    private void Awake()
    {
        lampDict = new Dictionary<KeyCode, Lamp>();
        foreach (Lamp l in lamps)
        {
            lampDict.Add(l.key, l);
        }
    }


    public void Highlight(KeyCode key)
    {
        Lamp lamp = lampDict[key];
        if (lamp == null)
        {
            Debug.LogError("Given key is not supported.");
            return;
        }
        lamp.Highlight();
    }


}
