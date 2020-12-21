using UnityEngine;

public static class LetterConverter 
{
    // methods to convert letters between char, int, KeyCode
    // int type: A = 0, B = 1, ..., Z = 25
    public const int letterCount = 26;
    public const int charOffset = 65;
    public const int keyCodeOffset = 97;

    public static KeyCode CharToKeyCode(char letter)
    {
        char.ToUpper(letter);
        int letterInt = CharToInt(letter);
        return IntToKeyCode(letterInt);
    }

    public static char KeyCodeToChar(KeyCode letter)
    {
        int letterInt = KeyCodeToInt(letter);
        return IntToChar(letterInt);
    }

    public static int KeyCodeToInt(KeyCode letter)
    {
        int value = (int)letter - keyCodeOffset;

        if (value >= 0 && value <= 25)
        {
            return value;
        }
        else
        {
            Debug.LogError("Given KeyCode is not a valid letter.");
            return -1;
        }
    }

    public static KeyCode IntToKeyCode(int letter)
    {
        if (letter >= 0 && letter <= 25)
        {
            return (KeyCode)(letter + keyCodeOffset);
        }
        else
        {
            Debug.LogError("Given int is not a valid letter.");
            return KeyCode.None;
        }
    }

    public static int CharToInt(char letter)
    {
        char.ToUpper(letter);
        int value = (int)letter - charOffset;
        if(value >= 0 && value <= 25)
        {
            return value;
        }
        else
        {
            Debug.LogError("Given char is not a valid letter.");
            return -1;
        }
    }

    public static char IntToChar(int letter)
    {
        if (letter >= 0 && letter <= 25)
        {
            return (char)(letter + charOffset);
        }
        else
        {
            Debug.LogError("Given int is not a valid letter.");
            return new char();
        }
    }



}
