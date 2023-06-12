using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject ComputerUI;
    public bool ScreenOpen = false;
    public Camera cam1;
    public Transform target;
    public float speed = 5f;

    private Vector3 startingPosition;
    private Quaternion startingRotation;

    public virtual void Interact()
    {
        if (!ScreenOpen)
        {
            ComputerUI.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            ScreenOpen = true;
            StartCoroutine(LerpToTarget());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ScreenOpen)
        {
            ComputerUI.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            StartCoroutine(ReturnToOriginalPosition());
            Invoke("DelayedAction", 0.1f);
        }

    }

    private void DelayedAction()
    {
        ScreenOpen = false;
    }

    private IEnumerator LerpToTarget()
    {
        float elapsedTime = 0f;
        startingPosition = cam1.transform.position;
        startingRotation = cam1.transform.rotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * speed;
            cam1.transform.position = Vector3.Lerp(startingPosition, target.position, elapsedTime);
            cam1.transform.rotation = Quaternion.Lerp(startingRotation, target.rotation, elapsedTime);

            yield return null;
        }
    }

    private IEnumerator ReturnToOriginalPosition()
    {
        float elapsedTime = 0f;
        Vector3 currentPosition = cam1.transform.position;
        Quaternion currentRotation = cam1.transform.rotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * speed;
            cam1.transform.position = Vector3.Lerp(currentPosition, startingPosition, elapsedTime);
            cam1.transform.rotation = Quaternion.Lerp(currentRotation, startingRotation, elapsedTime);

            yield return null;
        }
    }
}