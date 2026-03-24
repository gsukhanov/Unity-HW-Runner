using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    [Tooltip("Максимальное здоровье игрока")]
    [SerializeField] public float playerMaxHealth = 100f;
    [Tooltip("Высота прыжка (без учёта гравитации)")]
    [SerializeField] public float jumpHeight = 3f;
    [Tooltip("Гравитация (насколько быстро взлетает и падает игрок)")]
    [SerializeField] public float gravity = 10f;
    [Tooltip("Стартовая скорость движения вперёд")]
    [SerializeField] public float startingSpeed = 1f;
    [Tooltip("Максимальная скорость движения вперёд")]
    [SerializeField] public float maxSpeed = 50f;
    [Tooltip("Время достижения максимальной скорости")]
    [SerializeField] public float maxSpeedReachTime = 20f;
    [Tooltip("Средний урон препятствия (конкретный урон будет отличаться до 50% от этого числа)")]
    [SerializeField] public float mediumObstacleDamage = 10f;
    [Tooltip("Частота появления препятствий и усилений")]
    [SerializeField] public float obstacleFrequency = 0.2f;
    [Tooltip("Максимальная высота препятствия")]
    [SerializeField] public float maxObstacleHeight = 2.5f;
    [Tooltip("Вероятность появления усиления вместо препятствия")]
    [SerializeField] public float powerupChance = 0.1f;
    [Tooltip("Сколько длятся усиления")]
    [SerializeField] public float powerupDuration = 15f;
    [Tooltip("Во сколько раз ускоряет усиление скорости")]
    [SerializeField] public float speedBuffScale = 2f;
    [Tooltip("Сколько здоровья добавляет усиление здоровья")]
    [SerializeField] public float healthBuffSize = 25f;
    [Tooltip("Во сколько раз выше становятся прыжки от усиления прыжков")]
    [SerializeField] public float jumpBuffHeight = 2f;


}
