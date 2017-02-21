using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingMenu : MonoBehaviour {
    
    // On/Off Switch
    public Text onOff;
    bool off = true;

    bool unlocked = false;

    // Canvas
    public Canvas startingCanvas, Disconnect, removeCart, pressNext;
    public Text doneText, backText;
    public Button doneButton, backButton;

    void Update()
    {
        if(removeCart.gameObject.activeSelf == true) {
            backButton.gameObject.SetActive(false);
            doneText.text = "UNLOCK";
        } else
        {
            backButton.gameObject.SetActive(true);
            doneText.text = "Done";
        }

        if(doneText.text == "UNLOCK")
        {
            doneButton.image.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void ChangeCart()
    {
        startingCanvas.gameObject.SetActive(false);
        Disconnect.gameObject.SetActive(true);
    }

    public void RemoveCart()
    {
        Disconnect.gameObject.SetActive(false);
        removeCart.gameObject.SetActive(true);
    }

    public void Unlock()
    {
        if(!unlocked && doneText.text == "UNLOCK")
        {
            unlocked = true;
            doneText.text = "Done";
        } else
        {
            unlocked = false;
        }

        // Screen lock
        if (unlocked)
        {
            removeCart.gameObject.SetActive(false);
            pressNext.gameObject.SetActive(true);
        }

        Debug.Log(unlocked);
    }

    public void OnOff()
    {
        if (off)
        {
            onOff.text = "ON";
            off = false;
        } else
        {
            onOff.text = "OFF";
            off = true;
        }
    }
}
