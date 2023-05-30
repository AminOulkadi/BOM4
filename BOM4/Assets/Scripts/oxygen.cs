using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oxygen : MonoBehaviour
{
    public float oxygenLevel = 15;
    float nextTime = 0;
    bool done = false;
    public Image overlayImage;
    private float targetAlpha = 0f;

    private void Start()
    {
        overlayImage.color = Color.clear;
    }

    void Update()
    {
        if (Time.time >= nextTime && !done)
        {
            nextTime = Time.time + 1;
            oxygenLevel = oxygenLevel - 1;
            Debug.Log(oxygenLevel);

            if (oxygenLevel < 1)
            {
                
                done = true; 
            }
            targetAlpha = (10 - oxygenLevel) / 10;
            targetAlpha = Mathf.Clamp01(targetAlpha);
            Debug.Log(targetAlpha);
        }

        Color currentColor = overlayImage.color;
        float alpha = Mathf.MoveTowards(currentColor.a, targetAlpha, 0.25f * Time.deltaTime);
        overlayImage.color = new Color(0f, 0f, 0f, alpha);
        
    }

    public virtual void Interact()
    {
        Debug.Log("Test");
    }
}

