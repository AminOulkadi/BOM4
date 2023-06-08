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

        foreach (bool value in boolList)
        {
            Debug.Log(value);
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
        System.Random random = new System.Random();
        int randomIndex = falseIndices[random.Next(0, falseIndices.Count)];
        boolList[randomIndex] = true;
        GameObject randompipe = taggedObjects[randomIndex];
        //Code here (randompipe)
        Vector3 pos = randompipe.transform.position;




        Debug.Log("Random function called!");

        float delay = GetRandomDelay();
        Invoke("RandomFunction", delay);
    }

    private float GetRandomDelay()
    {
        return Random.Range(minDelay, maxDelay);
    }
}