using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField]
    private GameObject[] powerups;
    public GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyContainer;
    // logic behind stopping the spawn method, introducing a switch
    private bool isSpawning = true;
    void Start()
    {
    }

    public void StartSpawning()
        {
        // spawn objects every 5 seconds
        // create a coroutine of type IEnumerator -- yield keyword to wait for seconds
        // then use a while loop and set it to true
        StartCoroutine(SpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
        }

    void Update()
    {
        }

    IEnumerator SpawnRoutine()
        {
        yield return new WaitForSeconds(3);
        // ALWAYS CREATE INFINITE LOOPS INSIDE OF COROUTINES
        while (isSpawning ==  true)
            {
            Vector3 posToSpawn = new Vector3(Random.Range(-6f, 6f), 8, 0);
            // storing a variable for instantiation of the enemy object
            GameObject newEnemy =  Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            // setting the instantiated enemy to the enemy container game object that can be used to manipulate the instantiated enemies
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
            }
        }

    IEnumerator PowerUpSpawnRoutine()
        {
        yield return new WaitForSeconds(3);
        while (isSpawning == true)
            {
            Vector3 posToSpawn = new Vector3(Random.Range(-6f, 6f), 8, 0);
            int _powerUpsIndex = Random.Range(0, 3);
            Instantiate(powerups[_powerUpsIndex], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5,10));


            if(this.gameObject.transform.position.y < -8)
                {
                Destroy(this.gameObject);
                }
            }
        }

    public void OnPlayerDeath()
        {
        isSpawning = false;
        }
}
