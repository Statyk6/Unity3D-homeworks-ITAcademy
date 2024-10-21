using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Transform pointA1; // Первая точка
    public Transform pointA2; // Вторая точка
    public float speed = 10.0f; // Скорость движения

    private float journeyLength;
    private float currentTime;

    void Start()
    {
        journeyLength = Vector3.Distance(pointA1.position, pointA2.position);
        currentTime = 0; // Инициализируем свой таймер
    }

    void Update()
    {
        currentTime += Time.deltaTime; // Увеличиваем свой таймер каждый кадр

        // Вычисляем долю пути на основе текущего времени
        float fractionOfJourney = Mathf.PingPong(currentTime * speed / journeyLength, 1);

        // Линейная интерполяция между двумя точками
        transform.position = Vector3.Lerp(pointA1.position, pointA2.position, fractionOfJourney);
    }
}