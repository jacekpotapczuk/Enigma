using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugboardInput : MonoBehaviour
{
    private Plugboard plugboard;

    [SerializeField] private TMPro.TextMeshProUGUI[] inputTexts;

    private string alreadyChanged = "";
    private void Start()
    {
        plugboard = GetComponent<Plugboard>();
    }


    public bool IsChanging { private set; get; }
    
    public void OnStartEdit()
    {
        IsChanging = true;
    }

    public void OnEndEdit(string s)
    {
        UpdateWireSettings();
        IsChanging = false;
    }

    private void UpdateWireSettings()
    {
        plugboard.wireSetting = plugboard.wireSettingIdentity;
        alreadyChanged = "";
        
        Debug.Log("Before: " + plugboard.wireSetting);
        string s;
        for (int i = 0; i < inputTexts.Length; i++)
        {
            s = inputTexts[i].text;
            s = s.ToUpper();
            s = s.Remove(s.Length - 1);
            if (s.Length != 2)
                continue;
            if (!plugboard.wireSetting.Contains(s[0].ToString()))
                continue;
            if (!plugboard.wireSetting.Contains(s[1].ToString()))
                continue;
            if (alreadyChanged.Contains(s[0].ToString()))
                continue;
            if (alreadyChanged.Contains(s[1].ToString()))
                continue;
            plugboard.wireSetting = plugboard.wireSetting.Replace(s[0], '1');
            plugboard.wireSetting = plugboard.wireSetting.Replace(s[1], s[0]);
            plugboard.wireSetting = plugboard.wireSetting.Replace('1', s[1]);
            alreadyChanged += s[0];
            alreadyChanged += s[1];

        }

        Debug.Log("After: " + plugboard.wireSetting);
        
    }
}
