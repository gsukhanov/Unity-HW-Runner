using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    GameObject shade;

    [SerializeField] ObstacleStats stats;

    void Start()
    {
        shade = GameObject.FindGameObjectWithTag("Shade");
    }

    void Update()
    {
        if (Vector3.Distance(shade.transform.position, transform.position) > 20f)
        {
            Destroy(gameObject);
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     collision.gameObject.
    // }
}
