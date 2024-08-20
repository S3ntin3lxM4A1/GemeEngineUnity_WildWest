using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("- - Random Range Number - -")]

    public int animalMaxCount, animalCount;
    public float randomZahl;
    private float randomx, randomz;
    public float timeForDeer, timeForBunny;
    private float currentDeerTime, currentBunnyTime;
    public GameObject deerPref, bunnyPref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (animalCount < animalMaxCount)
        {
            if (currentDeerTime >= 0)
                 currentDeerTime -= Time.deltaTime;
            else
            {
                randomx = UnityEngine.Random.Range(-randomZahl, randomZahl);
                randomz = UnityEngine.Random.Range(-randomZahl, randomZahl);
                SpawnDeer();
            }

            if (currentBunnyTime >= 0)
                currentBunnyTime -= Time.deltaTime;
            else
            {
                randomx = UnityEngine.Random.Range(-randomZahl, randomZahl);
                randomz = UnityEngine.Random.Range(-randomZahl, randomZahl);
                SpawnBunny();
            }
        }
    }

    public void SpawnDeer()
    {
        currentDeerTime = timeForDeer;
        Instantiate(deerPref, new Vector3(randomx, 0, randomz), Quaternion.identity);
        animalCount++;
    }
    public void SpawnBunny()
    {
        currentBunnyTime = timeForBunny;
        Instantiate(bunnyPref, new Vector3(randomx, 0, randomz), Quaternion.identity);
        animalCount++;
    }
    public void AnimalCountDown()
    {
        animalCount--;
    }
}
