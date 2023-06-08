using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject ComputerUI;
    public bool ScreenOpen = false;


    public virtual void Interact()
    {
        if(!ScreenOpen)
        {
            ComputerUI.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            ScreenOpen = true;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & ScreenOpen)
        {
            Debug.Log("comp ");
            ComputerUI.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Invoke("DelayedAction", 0.1f);
            
        }
    }
    private void DelayedAction()
    {
        ScreenOpen = false;
    }
}
