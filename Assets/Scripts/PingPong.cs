using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Transform pointA1; // Первая точка
    public Transform pointA2; // Вторая точка
    public float speed = 10.0f; // Скорость движения

    private float journeyLength; // Длина пути

    void Start()
    {
        // Вычисляем длину пути между двумя точками
        journeyLength = Vector3.Distance(pointA1.position, pointA2.position);
    }

    void Update()
    {
        // Вычисляем пройденное расстояние, умножая скорость на время, прошедшее с предыдущего кадра
        float distCovered = speed * Time.deltaTime;

        // Используем PingPong для создания колебательного движения между точками
        float fractionOfJourney = Mathf.PingPong(Time.time * speed / journeyLength, 1);

        // Линейная интерполяция между двумя точками в зависимости от доли пройденного пути
        transform.position = Vector3.Lerp(pointA1.position, pointA2.position, fractionOfJourney);
    }
}