using UnityEngine;

public class Scaler : MonoBehaviour
{
    public Transform pointD1; // Первая точка масштабирования
    public Transform pointD2; // Вторая точка масштабирования
    public float speed = 10.0f; // Скорость движения
    public float scaleAmplitude = 0.25f; // Амплитуда изменения размера (от 0.75 до 1.0)

    private float journeyLength;
    private float startTime;

    void Start()
    {
        journeyLength = Vector3.Distance(pointD1.position, pointD2.position);
        startTime = Time.time; // Запоминаем начальное время
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed; // Пройденное расстояние
        float fractionOfJourney = distCovered / journeyLength; // Доля пути

        // Рассчитываем позицию между точками
        transform.position = Vector3.Lerp(pointD1.position, pointD2.position, Mathf.PingPong(fractionOfJourney, 1));

        // Масштабируем объект с меньшей амплитудой
        float scale = Mathf.PingPong(fractionOfJourney * 2, 1) * scaleAmplitude + 0.75f; // Изменяем размер от 0.75 до 1.0
        transform.localScale = new Vector3(scale, scale, scale); // Применяем масштаб
    }
}