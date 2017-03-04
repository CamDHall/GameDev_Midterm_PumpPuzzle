using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannulaProgress : MonoBehaviour
{

    Image foregroundImage;
    float filled;
    float fillNeeded = 3;
    float percent = 0;

    void Start()
    {
        foregroundImage = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        filled = (float)(ChangingMenu.cannulaFilled);
        percent = filled / fillNeeded;
        foregroundImage.fillAmount = percent;
    }
}