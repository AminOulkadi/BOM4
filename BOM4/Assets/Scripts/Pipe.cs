using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public string tagToFind = "Pipe";
    public List<bool> boolList = new List<bool>();
    public float minDelay = 1f;
    public float maxDelay = 3f;

    private GameObject[] taggedObjects;

    private void Start()
    {
        taggedObjects = GameObject.FindGameObjectsWithTag(tagToFind);

        foreach (GameObject obj in taggedObjects)
        {
            boolList.Add(false);
        }

        Invoke("RandomFunction", GetRandomDelay());
    }

    private void RandomFunction()
    {
        List<int> falseIndices = new List<int>();
        for (int i = 0; i < boolList.Count; i++)
        {
            if (!boolList[i])
            {
                falseIndices.Add(i);
            }
        }
        if(falseIndices.Count > 0)
        {
            System.Random random = new System.Random();
            int randomIndex = falseIndices[random.Next(0, falseIndices.Count)];
            boolList[randomIndex] = true;
            GameObject randompipe = taggedObjects[randomIndex];
            randompipe.GetComponent<ParticleSystem>().Play();
            InteractableObject interactableObject = randompipe.AddComponent<InteractableObject>();
            interactableObject.scriptname = "BrokenPipe";
            //Code here (randompipe)
            Vector3 pos = randompipe.transform.position;
        }

        //Debug.Log("Random function called!");

        float delay = GetRandomDelay();
        Invoke("RandomFunction", delay);
    }

    private float GetRandomDelay()
    {
        return Random.Range(minDelay, maxDelay);
    }
}