using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform pointC1; // Первая точка вращения
    public Transform pointC2; // Вторая точка вращения
    public float speed = 10.0f; // Скорость движения
    public float rotationSpeed = 100.0f; // Скорость вращения

    private float journeyLength;
    private float startTime;

    void Start()
    {
        journeyLength = Vector3.Distance(pointC1.position, pointC2.position);
        startTime = Time.time; // Запоминаем начальное время
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed; // Пройденное расстояние
        float fractionOfJourney = distCovered / journeyLength; // Доля пути

        transform.position = Vector3.Lerp(pointC1.position, pointC2.position, Mathf.PingPong(fractionOfJourney, 1)); // Линейная интерполяция
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Вращение объекта
    }
}