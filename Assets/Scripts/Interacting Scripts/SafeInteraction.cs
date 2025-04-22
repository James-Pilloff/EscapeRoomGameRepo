using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeInteraction : MonoBehaviour, IInteractable
{
    public GameObject safeCanvas;
    public TMP_Text displayText;
    public GameObject containedItem;
    public string correctCode = "1234";

    private string inputString;
    private bool unlocked;

    public void Interact(){
        if(!unlocked){
            safeCanvas.SetActive(true);  
        }
    }

    void Start()
    {
        containedItem.SetActive(false);
        safeCanvas.SetActive(false);
        inputString = "";
        unlocked = false;
    }

    void Update()
    {
        if (safeCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            safeCanvas.SetActive(false);
        }
    }

    public void AddDigit(string digit)
    {
        if (unlocked || inputString.Length >= correctCode.Length) return;

        inputString += digit;
        UpdateDisplay();
    }

    public void ClearInput()
    {
        if (unlocked) return;

        inputString = "";
        UpdateDisplay();
    }

    public void SubmitCode()
    {
        if (unlocked) return;

        if (inputString == correctCode)
        {
            UnlockSafe();
        }
        else
        {
            inputString = "";
            UpdateDisplay();
        }
    }

    void UnlockSafe()
    {
        unlocked = true;
        if (containedItem != null) containedItem.SetActive(true);
        safeCanvas.SetActive(false);
        containedItem.SetActive(true);
    }

    void UpdateDisplay()
    {
        displayText.text = inputString.PadRight(correctCode.Length, '_');
    }
}
