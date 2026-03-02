using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    [Tooltip("Player maximum health")]
    [SerializeField] public float playerMaxHealth = 100f;
    [Tooltip("Jump height. Unaffected by gravity")]
    [SerializeField] public float jumpHeight = 5f;
    [Tooltip("Gravity. Only affects the speed at which the player jumps and falls")]
    [SerializeField] public float gravity = 10f;
    [Tooltip("Starting speed of forward movement")]
    [SerializeField] public float startingSpeed = 1f;
    [Tooltip("Maximum speed of forward movement")]
    [SerializeField] public float maxSpeed = 10f;
    [Tooltip("Time to reach maximum speed in seconds")]
    [SerializeField] public float maxSpeedReachTime = 60f;
    [Tooltip("Average obstacle damage (real would fluctuate from 50% to 200% of that value)")]
    [SerializeField] public float mediumObstacleDamage = 10f;
    [Tooltip("Frequency of obstacle spawns per second")]
    [SerializeField] public float obstacleFrequency = 0.2f;

}
