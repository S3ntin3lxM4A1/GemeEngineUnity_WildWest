using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("- - Random Range Number - -")]

    public int animalMaxCount, animalCount;
    public float min, max;
    private float randomx, randomz;
    public float timeForDeer, timeForBunny;
    public GameObject deerPref, bunnyPref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomx = UnityEngine.Random.Range(min, max);
        randomz = UnityEngine.Random.Range(min, max);

        if (animalCount < animalMaxCount)
        {
            if (timeForDeer >= 0)
                timeForDeer -= Time.deltaTime;
            else
                SpawnDeer();

            if (timeForBunny >= 0)
                timeForBunny -= Time.deltaTime;
            else
                SpawnBunny(); 
        }
    }

    public void SpawnDeer()
    {
        Instantiate(deerPref, new Vector3(randomx, 0, randomz), Quaternion.identity);
        animalCount++;
    }
    public void SpawnBunny()
    {
        Instantiate(bunnyPref, new Vector3(randomx, 0, randomz), Quaternion.identity);
        animalCount++;
    }
    public void AnimalCountDown()
    {
        animalCount--;
    }
}
