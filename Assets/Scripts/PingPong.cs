using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Transform pointA1; // Первая точка
    public Transform pointA2; // Вторая точка
    public float speed = 10.0f; // Скорость движения

    private float journeyLength;
    private float startTime;

    void Start()
    {
        journeyLength = Vector3.Distance(pointA1.position, pointA2.position);
        startTime = Time.time; // Запоминаем начальное время
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed; // Пройденное расстояние
        float fractionOfJourney = distCovered / journeyLength; // Доля пути
        transform.position = Vector3.Lerp(pointA1.position, pointA2.position, Mathf.PingPong(fractionOfJourney, 1)); // Линейная интерполяция
    }
}