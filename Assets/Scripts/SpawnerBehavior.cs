using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [SerializeField] int counter = 0;
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<GameObject> powerups;
    [SerializeField] GameSettings gameSettings;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().onDeath.AddListener(Deactivate);
    }

    void FixedUpdate()
    {
        counter++;
        if (counter > 50f * System.Math.Pow(gameSettings.obstacleFrequency, -1))
        {
            counter = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        int pos = Random.Range(-1, 2);
        Vector3 location = transform.position;
        location.x += 4f * pos;
        bool spawnPowerup = Random.Range(0f, 1f / gameSettings.powerupChance) > 1f / gameSettings.powerupChance - 1;
        if (spawnPowerup)
        {
            int powerupChoice = Random.Range(0, powerups.Count);
            GameObject prefab = powerups[powerupChoice];
            GameObject spawnedPowerup = Instantiate(prefab, location, Quaternion.identity);
            spawnedPowerup.transform.Translate(0f, 2, 0f);
        }
        else 
        {
            int obstacleChoice = Random.Range(0, obstacles.Count);
            float obstacleHeight = Random.Range(0.5f, gameSettings.maxObstacleHeight);
            GameObject prefab = obstacles[obstacleChoice];
            GameObject spawnedObstacle = Instantiate(prefab, location, Quaternion.identity);
            spawnedObstacle.transform.localScale = new Vector3(1.4f, obstacleHeight, 1f);
            spawnedObstacle.transform.Translate(0f, (obstacleHeight - transform.position.y) / 2, 0f);
            float damageScale = Random.Range(0.5f, 2f);
            spawnedObstacle.GetComponent<ObstacleBehaviour>().setDamage(gameSettings.mediumObstacleDamage * damageScale);
            BoxCollider collider = spawnedObstacle.GetComponent<BoxCollider>();
            collider.size = spawnedObstacle.transform.localScale;
        }
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
