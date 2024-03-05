using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    public int maximum;
    public int current;
    public Image mask;
    private int increase = 1;
    // private int decrease = 1;

    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float) current / (float) maximum;
        mask.fillAmount = fillAmount;
    }

    public void increaseCurrent()
    {
        current += increase;
    }
}
