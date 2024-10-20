using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform pointC1; // Первая точка вращения
    public Transform pointC2; // Вторая точка вращения
    public float speed = 10.0f; // Скорость движения
    public float rotationSpeed = 100.0f; // Скорость вращения

    private float journeyLength; // Длина пути

    void Start()
    {
        // Вычисляем длину пути между двумя точками
        journeyLength = Vector3.Distance(pointC1.position, pointC2.position);
    }

    void Update()
    {
        // Вычисляем долю пути с учётом скорости и времени
        float fractionOfJourney = Mathf.PingPong(Time.time * speed / journeyLength, 1);

        // Перемещаем объект между точками
        transform.position = Vector3.Lerp(pointC1.position, pointC2.position, fractionOfJourney);

        // Вращаем объект вокруг оси Y с учётом времени, прошедшего с предыдущего кадра
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}