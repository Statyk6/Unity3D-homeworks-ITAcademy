using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform pointB1; // Первая точка телепортации
    public Transform pointB2; // Вторая точка телепортации
    public Transform pointB3; // Третья точка телепортации
    public Transform pointB4; // Четвертая точка телепортации
    public float teleportInterval = 1.0f; // Интервал телепортации

    private Transform[] teleportPoints; // Массив точек телепортации
    private System.Random random = new System.Random(); // Генератор случайных чисел

    void OnEnable()
    {
        // Инициализируем массив точек телепортации
        teleportPoints = new Transform[] { pointB1, pointB2, pointB3, pointB4 };

        // Запускаем телепортацию при включении скрипта
        InvokeRepeating(nameof(TeleportToRandomPoint), 0, teleportInterval);
    }

    void OnDisable()
    {
        // Останавливаем телепортацию при отключении скрипта
        CancelInvoke(nameof(TeleportToRandomPoint));
    }

    void TeleportToRandomPoint()
    {
        // Выбираем случайную точку из массива точек
        int randomIndex = random.Next(teleportPoints.Length);
        transform.position = teleportPoints[randomIndex].position;
    }
}