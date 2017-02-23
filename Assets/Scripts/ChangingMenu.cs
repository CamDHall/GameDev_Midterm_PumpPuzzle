using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangingMenu : MonoBehaviour {
    
    // On/Off Switch
    public Text onOff;
    bool off = true;

    bool unlocked = false;

    // Filled
    float filledtimer;
    bool whileFilling = true;
    bool filling = false;
    bool finishedFilling = false;
    int filled = 0;
    int fillNeeded;

    // Cannula
    bool cannulaBool = false;
    int cannulaFilled = 0;
    int cannulaFillNeeded = 3;
    bool finishedCannula = false;
    float timerCannulaFill;

    // Canvas
    public Canvas startingCanvas, Disconnect, removeCart, fillCart, fillTubing, disconnectWarning, fillCannula, resume;
    public Text doneText, backText, startStop, amountFilled, cannulaAmount, cannulaStart;
    public Button doneButton, backButton, lockedButton;

    void Start()
    {
        filledtimer = Time.time + 1.5f;
        fillNeeded = Random.Range(10, 18);
    }

    void Update()
    {
        if(removeCart.gameObject.activeSelf == true || fillCart.gameObject.activeSelf == true) {
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

        if(unlocked)
        {
            lockedButton.image.color = new Color(255, 255, 255, 0.5f);
        }

        // Filling 
        if(filling && cannulaBool == false)
        {
            if(Time.time > filledtimer)
            {
                filled++;
                filledtimer = Time.time + 1.5f;
            }
            amountFilled.text = "Amount filled: " + filled.ToString();
        }

        if(cannulaBool == true)
        {
            if (Time.time > timerCannulaFill)
            {
                cannulaFilled++;
                timerCannulaFill = Time.time + 1.75f;
                cannulaAmount.text = "Amount filled: " + cannulaFilled.ToString();
            }
        }

        if(cannulaFilled == cannulaFillNeeded)
        {
            cannulaStart.text = "FINISH";
            finishedCannula = true;

        }

        if(filled == fillNeeded)
        {
            startStop.text = "FINISH";
            finishedFilling = true;
        }
    }

    public void ChangeCart()
    {
        startingCanvas.gameObject.SetActive(false);
        Disconnect.gameObject.SetActive(true);
    }

    public void NextButton()
    {
        if (Disconnect.gameObject.activeSelf == true)
        {
            Disconnect.gameObject.SetActive(false);
            removeCart.gameObject.SetActive(true);
        }

        if(disconnectWarning.gameObject.activeSelf == true)
        {
            disconnectWarning.gameObject.SetActive(false);
            fillTubing.gameObject.SetActive(true);
        }
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
    }

    public void LockedScreen()
    {
        // Screen lock
        if (unlocked && removeCart.gameObject.activeSelf == true)
        {
            removeCart.gameObject.SetActive(false);
            fillCart.gameObject.SetActive(true);
        }

        if(unlocked && fillCart.gameObject.activeSelf == true)
        {
            fillCart.gameObject.SetActive(false);
            disconnectWarning.gameObject.SetActive(true);
        }
    }

    public void StartStop()
    {
        if (whileFilling)
        {
            if (startStop.text == "START")
            {
                startStop.text = "STOP";
                filling = true;
            }
            else
            {
                startStop.text = "START";
                filling = false;
            }

            if (finishedFilling)
            {
                fillTubing.gameObject.SetActive(false);
                startingCanvas.gameObject.SetActive(true);
                whileFilling = false;
            }
        }
    }

    public void FillCannula()
    {
        if(finishedFilling)
        {
            fillCannula.gameObject.SetActive(true);
            startingCanvas.gameObject.SetActive(false);
            timerCannulaFill = Time.time + 1.75f;
        }
    }

    public void CannulaStartStop()
    {
        if (cannulaStart.text == "START")
        {
            cannulaStart.text = "Filling";
            cannulaBool = true;
        }
        if(finishedCannula)
        {
            fillCannula.gameObject.SetActive(false);
            resume.gameObject.SetActive(true);
        }
    }

    public void Resume()
    {
        SceneManager.LoadScene("Win");
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
