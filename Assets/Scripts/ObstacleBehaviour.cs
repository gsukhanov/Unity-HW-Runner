using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    GameObject shade;

    private float damage;

    public float getDamage() {
        return damage;
    }

    public void setDamage(float value) {
        damage = value;
    }

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
}
