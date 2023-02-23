using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorButtonHandler : MonoBehaviour
{
    [SerializeField] Button colorSwapButton;
    public delegate void ColorButtonPressed();
    public static event ColorButtonPressed OnColorButtonPressed;
    int  buttonCounter;
    [SerializeField] TMP_Text  buttonCounterText;
  




    public void ButtonPressed()
    {
        OnColorButtonPressed();
        buttonCounter++;
        buttonCounterText.text = buttonCounter.ToString();
      
    }
    public void ResetButton()
    {
        colorSwapButton.interactable = false;
        colorSwapButton.interactable = true;

    }
}
