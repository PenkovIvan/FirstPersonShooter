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
        gameObject.SetActive(true);//���������� ������, ����� ������� ����
    }

    public void Close()
    {
        gameObject.SetActive(false);//���������� ������, ����� ������� ����
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }
    //�������� ��������� ��������� SettingsPopup
    public void OnSpeedValue(float speed)
    {
        //Debug.Log($"Speed: {speed}");
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGE,speed);//�������� , �������� ���������� �������� � ��������, ����������� ��� ������� float
        PlayerPrefs.SetFloat("speed", speed);
    }
}
