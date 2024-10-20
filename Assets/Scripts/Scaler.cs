using UnityEngine;

public class Scaler : MonoBehaviour
{
    public Transform pointD1; // Первая точка масштабирования
    public Transform pointD2; // Вторая точка масштабирования
    public float speed = 10.0f; // Скорость движения
    public float scaleAmplitude = 0.25f; // Амплитуда изменения размера (от 0.75 до 1.0)

    private float journeyLength; // Длина пути

    void Start()
    {
        // Вычисляем длину пути между двумя точками
        journeyLength = Vector3.Distance(pointD1.position, pointD2.position);
    }

    void Update()
    {
        // Вычисляем долю пути, пройденного объектом, с учётом скорости и времени
        float fractionOfJourney = Mathf.PingPong(Time.time * speed / journeyLength, 1);

        // Перемещаем объект между двумя точками с учётом времени
        transform.position = Vector3.Lerp(pointD1.position, pointD2.position, fractionOfJourney);

        // Масштабируем объект в пределах от 0.75 до 1.0
        float scale = Mathf.PingPong(Time.time * speed / journeyLength * 2, 1) * scaleAmplitude + 0.75f;

        // Применяем рассчитанный масштаб к объекту
        transform.localScale = new Vector3(scale, scale, scale);
    }
}