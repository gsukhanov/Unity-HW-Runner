using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [SerializeField] float frequency = 0.2f;
    [SerializeField] int counter = 0;
    [SerializeField] private List<GameObject> obstacles;
    void Start()
    {
    }
    void FixedUpdate()
    {
        counter++;
        if (counter > 50f * System.Math.Pow(frequency, -1))
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
        int obstacleChoice = Random.Range(0, obstacles.Count);
        float obstacleHeight = Random.Range(0.5f, 2.5f);
        GameObject prefab = obstacles[obstacleChoice];
        GameObject spawnedObstacle = Instantiate(prefab, location, Quaternion.identity);
        spawnedObstacle.transform.localScale = new Vector3(1.4f, obstacleHeight, 1f);
        spawnedObstacle.transform.Translate(0f, (obstacleHeight - transform.position.y) / 2, 0f);
        BoxCollider collider = spawnedObstacle.GetComponent<BoxCollider>();
        collider.size = spawnedObstacle.transform.localScale;
    }

}
