using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;
    public Image Crosshair;
    public Color Interaction = Color.green;
    public Color NotInteraction = Color.black;
    public GameObject MenuManager;

    private void Update()
    {

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                //Debug.Log("Looking at " + interactableObject.objectName);
                //Debug.Log(interactableObject.interactionPrompt);
                Crosshair.color = Interaction;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!MenuManager.GetComponent<PauseMenu>().Paused)
                    {
                        interactableObject.Interact();
                    }
                }
            }
            else
            {
                Crosshair.color = NotInteraction;
            }
        }
        else
        {
            Crosshair.color = NotInteraction;
        }
    }
}
