using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    GameObject player;
    public TMP_Text healthText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (player) healthText.text = "Current Health: " + ((int)player.GetComponent<PlayerController>().getHealth()).ToString();
        else healthText.text = "Dead";
    }

}
