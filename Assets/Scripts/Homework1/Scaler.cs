using UnityEngine;

public class Scaler : MonoBehaviour
{
    public Transform pointD1; // Первая точка
    public Transform pointD2; // Вторая точка
    public float speed = 10.0f; // Скорость движения
    public float scaleAmplitude = 0.25f; // Амплитуда изменения размера (от 0.75 до 1.0)

    private float journeyLength;
    private float currentTime;

    void Start()
    {
        journeyLength = Vector3.Distance(pointD1.position, pointD2.position);
        currentTime = 0; // Инициализируем свой таймер
    }

    void Update()
    {
        currentTime += Time.deltaTime; // Увеличиваем свой таймер каждый кадр

        // Вычисляем долю пути на основе текущего времени
        float fractionOfJourney = Mathf.PingPong(currentTime * speed / journeyLength, 1);

        // Линейная интерполяция между точками
        transform.position = Vector3.Lerp(pointD1.position, pointD2.position, fractionOfJourney);

        // Изменяем размер с помощью PingPong для колебаний
        float scale = Mathf.PingPong(currentTime * speed / journeyLength * 2, 1) * scaleAmplitude + 0.75f;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}