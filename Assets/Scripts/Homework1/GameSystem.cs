using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    // Ссылки на машины с разными скриптами
    public GameObject carPingPong;
    public GameObject carTeleport;
    public GameObject carRotator;
    public GameObject carScaler;

    // Ссылки на кнопки TMP
    public Button buttonPingPong;
    public Button buttonTeleport;
    public Button buttonRotator;
    public Button buttonScaler;
    public Button buttonExit;

    // Флаги, которые отслеживают включение/выключение скриптов
    private bool isPingPongActive = false;
    private bool isTeleportActive = false;
    private bool isRotatorActive = false;
    private bool isScalerActive = false;

    void Start()
    {
        // Отключаем все скрипты при запуске игры
        carPingPong.GetComponent<PingPong>().enabled = false;
        carTeleport.GetComponent<Teleport>().enabled = false;
        carRotator.GetComponent<Rotator>().enabled = false;
        carScaler.GetComponent<Scaler>().enabled = false;

        // Привязка методов к событиям нажатий на кнопки
        buttonPingPong.onClick.AddListener(TogglePingPong);
        buttonTeleport.onClick.AddListener(ToggleTeleport);
        buttonRotator.onClick.AddListener(ToggleRotator);
        buttonScaler.onClick.AddListener(ToggleScaler);
        buttonExit.onClick.AddListener(ToggleExit);
    }

    // Включение/выключение PingPong.cs
    void TogglePingPong()
    {
        isPingPongActive = !isPingPongActive; // Переключаем состояние
        carPingPong.GetComponent<PingPong>().enabled = isPingPongActive; // Включаем/выключаем скрипт
    }

    // Включение/выключение Teleport.cs
    void ToggleTeleport()
    {
        isTeleportActive = !isTeleportActive;
        carTeleport.GetComponent<Teleport>().enabled = isTeleportActive;
    }

    // Включение/выключение Rotator.cs
    void ToggleRotator()
    {
        isRotatorActive = !isRotatorActive;
        carRotator.GetComponent<Rotator>().enabled = isRotatorActive;
    }

    // Включение/выключение Scaler.cs
    void ToggleScaler()
    {
        isScalerActive = !isScalerActive;
        carScaler.GetComponent<Scaler>().enabled = isScalerActive;
    }

    // Обработка клика выхода из игры
    void ToggleExit()
    {
        // Закрытие игры
        #if UNITY_EDITOR
        // Остановить игру в редакторе Unity
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // Закрыть приложение
        #endif
    }
}