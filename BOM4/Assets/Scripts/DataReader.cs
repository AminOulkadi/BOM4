using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class DataReader : MonoBehaviour
{
    public TMP_Text QuestionText;
    public TMP_Text AnswerText0;
    public TMP_Text AnswerText1;

    private DialogData dialogData;
    private int AtQuestion = 0;
    private bool canInteract = false;

    public float TimeToNextQuestion = 30f;
    public Slider delayBar;
    private float currentTime = 0f;
    private bool isDelaying = false;

    private void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "PcData.json");

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            dialogData = JsonUtility.FromJson<DialogData>(jsonContent);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
        SetText();
    }

    public virtual void SetText()
    {
        QuestionText.SetText(dialogData.Dialog[AtQuestion].Question);
        AnswerText0.SetText(dialogData.Dialog[AtQuestion].Answer0);
        AnswerText1.SetText(dialogData.Dialog[AtQuestion].Answer1);
        canInteract = true;
    }

    public virtual void ButtonInteract0()
    {
        if (canInteract)
        {
            AtQuestion = dialogData.Dialog[AtQuestion].If0GoTo;
            canInteract = false;
            isDelaying = true;
        }
    }

    public virtual void ButtonInteract1()
    {
        if (canInteract)
        {
            AtQuestion = dialogData.Dialog[AtQuestion].If1GoTo;
            canInteract = false;
            isDelaying = true;
        }
    }

    void Update()
    {
        if (isDelaying)
        {

            currentTime += Time.deltaTime;
            delayBar.value = currentTime / TimeToNextQuestion;

            if (currentTime >= TimeToNextQuestion)
            {
                currentTime = 0f;
                isDelaying = false;
                SetText();
            }
        }
    }
}

[System.Serializable]
public class DialogData
{
    public DialogItem[] Dialog;
}

[System.Serializable]
public class DialogItem
{
    public string Question;
    public string Answer0;
    public string Answer1;
    public int If0GoTo;
    public int If1GoTo;
}
