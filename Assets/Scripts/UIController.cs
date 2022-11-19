using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreLabel;//объект сцены Reference Text дл€ создани€ св-ва Text
    [SerializeField] private SettingsPopup _settingsPopup;

    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);//ќбъ€вл€ем какой метод отвечает на событие ENEMY_HIT
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT,OnEnemyHit);//при уничтожении удал€ем подписчика, чтобы не было ошибок
    }

    private void OnEnemyHit()
    {
        _score += 1;//увеличиваем на 1  в ответ на данное событие
        scoreLabel.text=_score.ToString();

    }

    void Start()
    {
        _score = 0;
        scoreLabel.text=_score.ToString();//присваеиваем переменной score значение 0
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
