using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oxygen : MonoBehaviour
{
    public float oxygenLevel = 15;
    float nextTime = 0;
    bool done = false;
    public Image overlayImage;
    private float targetAlpha = 0f;
    public GameObject DeathScreen;

    private void Start()
    {
        overlayImage.color = Color.clear;
        DeathScreen.SetActive(false);

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

                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerInteraction>().enabled = false;
                GameObject.Find("MenuManager").GetComponent<PauseMenu>().enabled = false;

                DeathScreen.SetActive(true);
                Invoke("DelayedAction", 5f);

            }
            targetAlpha = (10 - oxygenLevel) / 10;
            targetAlpha = Mathf.Clamp01(targetAlpha);
            Debug.Log(targetAlpha);
        }

        Color currentColor = overlayImage.color;
        float alpha = Mathf.MoveTowards(currentColor.a, targetAlpha, 0.13f * Time.deltaTime);
        overlayImage.color = new Color(0f, 0f, 0f, alpha);
        
    }

    private void DelayedAction()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public virtual void Interact()
    {
        Debug.Log("Test");
    }
}

