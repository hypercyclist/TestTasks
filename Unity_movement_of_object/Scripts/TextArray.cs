using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextArray
{
    private List<string> textArray;
    private int textValueIndex;
    private int textValueIndexMax;

    public TextArray()
    {
        textArray = new List<string>();
        textValueIndex = 0;
        textValueIndexMax = -1;
    }

    public void add(string _text)
    {
        textArray.Add(_text);
        textValueIndexMax++;
    }

    public void removeAt(int _index)
    {
        textArray.RemoveAt(_index);
        textValueIndexMax--;
        textValueIndex = textValueIndex >= textValueIndexMax ? 0 : textValueIndex;
    }

    public string getText()
    {
        return textArray[textValueIndex];
    }

    public void setTextValueIndexNext()
    {
        textValueIndex = textValueIndex == textValueIndexMax ? textValueIndexMax : ++textValueIndex;
    }
}
