using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingMenu : MonoBehaviour {
    
    // On/Off Switch
    public Text onOff;
    bool off = true;

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
