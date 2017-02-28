using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangingMenu : MonoBehaviour {

    bool unlocked = false;
    bool canFill = false;
    // Filled
    float filledtimer;
    bool whileFilling = true;
    bool filling = false;
    bool finishedFilling = false;
    public static int filled = 0;
    int fillNeeded;

    // Cannula
    bool cannulaBool = false;
    int cannulaFilled = 0;
    int cannulaFillNeeded = 3;
    bool finishedCannula = false;
    float timerCannulaFill;

    // Canvas
    public Canvas startingCanvas, Disconnect, removeCart, fillCart, fillTubing, disconnectWarning, fillCannula;
    public Text doneText, backText, startStop, amountFilled, cannulaAmount, cannulaStart;
    public Button doneButton, backButton, lockedButton, resume;

    // Spawning Bools
    public static bool cartChanged = false;
    public static bool cartFilled = false;
    public static bool cannulaFinished = false;

    void Start()
    {
        filledtimer = Time.timeSinceLevelLoad + 1.5f;
        fillNeeded = Random.Range(10, 18);
        Progress.fillNeeded = fillNeeded;

        // Reset Variables
        filled = 0;
        cartChanged = false;
        cartFilled = false;
        cannulaFinished = false;

    }

    void Update()
    {
        if (removeCart.gameObject.activeSelf == true || fillCart.gameObject.activeSelf == true) {
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
            if (Time.timeSinceLevelLoad > filledtimer)
            {
                filled++;
                filledtimer = Time.timeSinceLevelLoad + 1.5f;
            }
            amountFilled.text = "Amount filled: " + filled.ToString();
        }

        if(cannulaBool == true)
        {
            if (Time.timeSinceLevelLoad > timerCannulaFill)
            {
                cannulaFilled++;
                timerCannulaFill = Time.timeSinceLevelLoad + 1.75f;
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

    public void FirstNextButton()
    {
            Disconnect.gameObject.SetActive(false);
            removeCart.gameObject.SetActive(true);
    }

    public void SecondNextButton()
    {
        disconnectWarning.gameObject.SetActive(false);
        fillTubing.gameObject.SetActive(true);
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

    // Remove cart
    public void LockedScreen()
    {
        // Screen lock
        if (unlocked && removeCart.gameObject.activeSelf == true)
        {
            removeCart.gameObject.SetActive(false);
            fillCart.gameObject.SetActive(true);
            cartChanged = true;
            canFill = true;
        }

        if(unlocked && fillCart.gameObject.activeSelf == true)
        {
            fillCart.gameObject.SetActive(false);
            disconnectWarning.gameObject.SetActive(true);
        }
    }

    // Fill cart
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
                cartFilled = true;
            }
        }
    }

    public void FillCannula()
    {
        if(finishedFilling)
        {
            fillCannula.gameObject.SetActive(true);
            startingCanvas.gameObject.SetActive(false);
            timerCannulaFill = Time.timeSinceLevelLoad + 1.75f;
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
            startingCanvas.gameObject.SetActive(true);
            cannulaFinished = true;
            resume.image.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void Resume()
    {
        if(finishedCannula)
        {
            Debug.Log("FIN");
            SceneManager.LoadScene("Win");
        }
    }

    // Full tubing
    public void FillTubing()
    {
        if(canFill)
        {
            startingCanvas.gameObject.SetActive(false);
            fillTubing.gameObject.SetActive(true);
        }
    }

    public void Begin()
    {
        SceneManager.LoadScene("main");
    }

    public void Back()
    {
        Disconnect.gameObject.SetActive(false);
        removeCart.gameObject.SetActive(false);
        fillCart.gameObject.SetActive(false);
        fillTubing.gameObject.SetActive(false);
        disconnectWarning.gameObject.SetActive(false);
        fillCannula.gameObject.SetActive(false);

        startingCanvas.gameObject.SetActive(true);
    }
}
