using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Lamp : MonoBehaviour
{
    public KeyCode key;

    [SerializeField]
    private Text text;

    private Color standardColor = Color.black;
    private Color highlightColor = Color.yellow;

    private void Awake()
    {
        text.text = key.ToString();
    }

    public void Highlight()
    {
        Highlight(0.5f);
    }

    public void Highlight(float time)
    {
        StartCoroutine(HighlightCorutine(time));
    }

    private IEnumerator HighlightCorutine(float time)
    {
        text.color = highlightColor;
        yield return new WaitForSeconds(time);
        text.color = standardColor;
    }

}
