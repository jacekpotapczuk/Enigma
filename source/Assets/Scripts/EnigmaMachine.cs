using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnigmaMachine : MonoBehaviour
{
    [SerializeField]
    private Lampboard lampboard;

    [SerializeField]
    private RotorManager rotorManager;

    [SerializeField]
    private Plugboard plugboard;


    public void Testuejse()
    {
        Debug.Log("Testuje se");
    }
    private void Update()
    {
        KeyCode keyPressed = GetInput();

        if (keyPressed != KeyCode.None)
        {
            if (rotorManager.IsAnyRotorChanging() || plugboard.IsChanging)
                return;
                    
            KeyCode result = Encode(keyPressed);
            Debug.Log(keyPressed.ToString() + " -> " + result.ToString());
            lampboard.Highlight(result);
        }
    }

    public void EncodeString(string text)
    {
        string encodedText = "";
        foreach (char c in text)
        {
            encodedText += Encode(LetterConverter.CharToKeyCode(c)).ToString();
        }
        Debug.Log("Encoded text: \n" + encodedText);
    }

    private KeyCode Encode(KeyCode letter)
    {

        letter = plugboard.Encode(letter);
        letter = rotorManager.Encode(letter);
        letter = plugboard.Encode(letter);
        return letter;
    }


    private KeyCode GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            return KeyCode.Q;
        else if (Input.GetKeyDown(KeyCode.W))
            return KeyCode.W;
        else if (Input.GetKeyDown(KeyCode.E))
            return KeyCode.E;
        else if (Input.GetKeyDown(KeyCode.R))
            return KeyCode.R;
        else if (Input.GetKeyDown(KeyCode.T))
            return KeyCode.T;
        else if (Input.GetKeyDown(KeyCode.Z))
            return KeyCode.Z;
        else if (Input.GetKeyDown(KeyCode.U))
            return KeyCode.U;
        else if (Input.GetKeyDown(KeyCode.I))
            return KeyCode.I;
        else if (Input.GetKeyDown(KeyCode.O))
            return KeyCode.O;
        else if (Input.GetKeyDown(KeyCode.A))
            return KeyCode.A;
        else if (Input.GetKeyDown(KeyCode.S))
            return KeyCode.S;
        else if (Input.GetKeyDown(KeyCode.D))
            return KeyCode.D;
        else if (Input.GetKeyDown(KeyCode.F))
            return KeyCode.F;
        else if (Input.GetKeyDown(KeyCode.G))
            return KeyCode.G;
        else if (Input.GetKeyDown(KeyCode.H))
            return KeyCode.H;
        else if (Input.GetKeyDown(KeyCode.J))
            return KeyCode.J;
        else if (Input.GetKeyDown(KeyCode.K))
            return KeyCode.K;
        else if (Input.GetKeyDown(KeyCode.P))
            return KeyCode.P;
        else if (Input.GetKeyDown(KeyCode.Y))
            return KeyCode.Y;
        else if (Input.GetKeyDown(KeyCode.X))
            return KeyCode.X;
        else if (Input.GetKeyDown(KeyCode.C))
            return KeyCode.C;
        else if (Input.GetKeyDown(KeyCode.V))
            return KeyCode.V;
        else if (Input.GetKeyDown(KeyCode.B))
            return KeyCode.B;
        else if (Input.GetKeyDown(KeyCode.N))
            return KeyCode.N;
        else if (Input.GetKeyDown(KeyCode.M))
            return KeyCode.M;
        else if (Input.GetKeyDown(KeyCode.L))
            return KeyCode.L;

        return KeyCode.None;
    }
}
