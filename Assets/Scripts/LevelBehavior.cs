using UnityEditor;
using UnityEngine;

public class LevelBehavior : MonoBehaviour
{
    GameObject shade;
    [SerializeField] GameObject levelPrefab;
    [SerializeField] float levelLength = 1000f;
    bool halfLifetime = false;
    bool aboutToDie = false;
    void Start()
    {
        shade = GameObject.FindGameObjectWithTag("Shade");
    }

    // Update is called once per frame
    void Update()
    {
        if (!halfLifetime && !aboutToDie) {
            if (Vector3.Distance(shade.transform.position, transform.position) < 10f)
            {
                halfLifetime = true;
            }
        }
        else if (halfLifetime && !aboutToDie)
        {
            if (Vector3.Distance(shade.transform.position, transform.position) > 400f)
            {
                aboutToDie = true;
                halfLifetime = false;
                Vector3 location = transform.position;
                location.z += levelLength;
                Instantiate(levelPrefab, location, Quaternion.identity);
            }
        }
        else if (aboutToDie)
        {
            if (Vector3.Distance(shade.transform.position, transform.position) > 700f)
            {
                Destroy(gameObject);
            }
        }
    }
}
