using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider _speedSlider;

    void Start()
    {
        _speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }
    public void Open()
    {
        gameObject.SetActive(true);//активируем объект, чтобы открыть окно
    }

    public void Close()
    {
        gameObject.SetActive(false);//активируем объект, чтобы закрыть окно
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    public void OnSpeedValue(float speed)
    {
        Debug.Log($"Speed: {speed}");
    }
}
