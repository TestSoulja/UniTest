using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicks : MonoBehaviour
{
    public Button AddClicksButton;
    public Text ClicksText;
    public int clicks;

    public void AddClicks()
    {
        clicks++;
        ClicksText.text = $"{clicks}";
    }

}
