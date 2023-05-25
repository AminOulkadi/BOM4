using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxygen : MonoBehaviour
{
    float oxygenLevel = 15;
    float nextTime = 0;
    bool done = false;

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
        }
        
    }
}

