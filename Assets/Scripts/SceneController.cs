using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;//серриализованна€ переменна€ дл€ св€зи с объектом-шаблоном
    private GameObject _enemy;//переменна€ дл€ отслеживани€ за экземпл€ром врага на сцене

    public const float baseSpeed = 3.0f;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGE,OnEnemySpeedChange);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE, OnEnemySpeedChange);
    }

    private void OnEnemySpeedChange(float val)
    {
        float speedEnemy = 3.0f;
        speedEnemy = baseSpeed * val;
    }

    


    void Update()
    {
        if (_enemy == null)//пораждаем нового врага, только если враги отсутствуют
        {
            _enemy=Instantiate(enemyPrefab) as GameObject;//метод копирующий шаблон
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0,angle,0);
           

        }
    }
}
