using UnityEngine;
using System.Collections;

public class CowSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int amount;
    private Vector3 spawnPoint;
    
    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        amount = enemies.Length;
        if (amount != 45)//#of spawn
        {
            InvokeRepeating("spawnEnemy", 1, 5f);
        }
    }
    //function for spawning enemies.
    void spawnEnemy()
    {
        float randomPointX = Random.insideUnitCircle.x * 50;
        float randomPointZ = Random.insideUnitCircle.y * 50;
        spawnPoint = new Vector3(randomPointX, 0, randomPointZ);

        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], spawnPoint, Quaternion.identity);
        CancelInvoke();
    }
}
