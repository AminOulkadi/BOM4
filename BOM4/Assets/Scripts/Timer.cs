using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float Timer2 = 15;
    float nextTime = 0;
    bool done = false;

    void Update()
    {
        if (Time.time >= nextTime && !done)
        {
            nextTime = Time.time + 1;
            Timer2 = Timer2 - 1;

            if (Timer2 < 1)
            {
                
                done = true;
                
            }
        }
        
    }
}

