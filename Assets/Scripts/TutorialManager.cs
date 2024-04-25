using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System;
using Kino;

public class TutorialManager : MonoBehaviour
{
    string tutorialText;
    [SerializeField]GameObject tutorialPane;
    [SerializeField]TextMeshProUGUI text;
    void Awake()
    {
        SetTutorialPane(false);
    }
    public void tutorial(string text, bool paneEnable)
    {
        SetTutorialText(text);
        SetTutorialPane(paneEnable);
    }
    public void SetTutorialText(string text)
    {
        this.text.text = text;
    }
    public void SetTutorialPane(bool paneEnable)
    {
        tutorialPane.SetActive(paneEnable);
    }
    public void closePane()
    {
        SetTutorialPane(false);
    }
}
