using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FOVSlider : MonoBehaviour
{
    [SerializeField] Slider fovSlider;
    [SerializeField] Camera mainCamera;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("FOV"))
        {
            PlayerPrefs.SetFloat("FOV", 60f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeFOV()
    {
        mainCamera.fieldOfView = fovSlider.value;
        Save();
    }

    public void Load()
    {
        fovSlider.value = PlayerPrefs.GetFloat("FOV");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("FOV", fovSlider.value);
    }
}
