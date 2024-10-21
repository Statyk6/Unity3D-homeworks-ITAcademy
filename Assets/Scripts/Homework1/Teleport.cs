using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public Transform pointB1; // Первая точка телепортации
    public Transform pointB2; // Вторая точка телепортации
    public Transform pointB3; // Третья точка телепортации
    public Transform pointB4; // Четвёртая точка телепортации
    public float teleportInterval = 1.0f; // Интервал телепортации

    private Transform[] teleportPoints; // Массив точек телепортации
    private System.Random random = new System.Random(); // Генератор случайных чисел
    private Coroutine teleportCoroutine; // Хранит ссылку на корутину для последующей остановки

    void OnEnable()
    {
        // Инициализируем массив точек телепортации
        teleportPoints = new Transform[] { pointB1, pointB2, pointB3, pointB4 };

        // Запускаем корутину, которая периодически телепортирует объект
        teleportCoroutine = StartCoroutine(TeleportRoutine());
    }

    void OnDisable()
    {
        // Останавливаем корутину при отключении скрипта, если она была запущена
        if (teleportCoroutine != null)
        {
            StopCoroutine(teleportCoroutine);
        }
    }

    // Корутин выполняет телепортацию с заданным интервалом
    IEnumerator TeleportRoutine()
    {
        while (true)
        {
            // Ждём указанный интервал перед телепортацией
            yield return new WaitForSeconds(teleportInterval);

            // Выбираем случайную точку, отличную от текущей позиции
            Transform targetPoint = GetRandomTeleportPoint();
            transform.position = targetPoint.position;
        }
    }

    // Метод для выбора случайной точки, отличной от текущей позиции объекта
    Transform GetRandomTeleportPoint()
    {
        Transform chosenPoint;
        int randomIndex;

        // Повторяем выбор, пока не выберем точку, отличную от текущей позиции
        do
        {
            randomIndex = random.Next(teleportPoints.Length);
            chosenPoint = teleportPoints[randomIndex];
        }
        while (chosenPoint.position == transform.position);

        return chosenPoint;
    }
}