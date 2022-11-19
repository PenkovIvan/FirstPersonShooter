using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreLabel;//������ ����� Reference Text ��� �������� ��-�� Text
    [SerializeField] private SettingsPopup _settingsPopup;

    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);//��������� ����� ����� �������� �� ������� ENEMY_HIT
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT,OnEnemyHit);//��� ����������� ������� ����������, ����� �� ���� ������
    }

    private void OnEnemyHit()
    {
        _score += 1;//����������� �� 1  � ����� �� ������ �������
        scoreLabel.text=_score.ToString();

    }

    void Start()
    {
        _score = 0;
        scoreLabel.text=_score.ToString();//������������ ���������� score �������� 0
        _settingsPopup.Close();
    }
   
    //void Update()
    //{
    //    scoreLabel.text=Time.realtimeSinceStartup.ToString();
    //}

    public void OnOpenSettings()
    {
        _settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
