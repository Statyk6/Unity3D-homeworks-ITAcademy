using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform pointC1; // Первая точка вращения
    public Transform pointC2; // Вторая точка вращения
    public float speed = 10.0f; // Скорость движения
    public float rotationSpeed = 100.0f; // Скорость вращения

    private float journeyLength;
    private float currentTime;

    void Start()
    {
        journeyLength = Vector3.Distance(pointC1.position, pointC2.position);
        currentTime = 0; // Инициализируем свой таймер
    }

    void Update()
    {
        currentTime += Time.deltaTime; // Увеличиваем свой таймер каждый кадр

        // Вычисляем долю пути на основе текущего времени
        float fractionOfJourney = Mathf.PingPong(currentTime * speed / journeyLength, 1);

        // Перемещение объекта
        transform.position = Vector3.Lerp(pointC1.position, pointC2.position, fractionOfJourney);

        // Вращение объекта вокруг оси Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}