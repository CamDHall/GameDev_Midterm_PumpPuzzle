using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{

    Image foregroundImage;
    float filled;
    public static float fillNeeded= 0;
    float percent= 0;

    void Start()
    {
        foregroundImage = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        filled = (float)(ChangingMenu.filled);
        percent = filled / fillNeeded;
        Debug.Log(percent);
        foregroundImage.fillAmount = percent;
    }
}