using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreLabel;//объект сцены Reference Text для создания св-ва Text
    [SerializeField] private SettingsPopup _settingsPopup;

    void Start()
    {
        _settingsPopup.Close();
    }
   
    void Update()
    {
        scoreLabel.text=Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        _settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
