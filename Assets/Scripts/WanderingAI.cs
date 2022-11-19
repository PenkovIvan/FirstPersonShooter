using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Wandering - блуждающий
//Artificial Intelligence (AI)-искусственный интеллект
public class WanderingAI : MonoBehaviour
{
    private bool _alive;//переменная для отслеживания состояния здоровья персонажа
    //obstacle Range-диапазон препятствий
    // значения  для скорости движения и расстояние, с которого начинапется реакция на препятствие
    public float speed = 3.0f;//скорости движения врага
    public float obstacleRange=5.0f;//расстояния, на котором враг начинает реагировать на препятствие

    public const float baseSpeed = 3.0f;//базовая скорость. которая регулируется  положением ползунка слайдера

    [SerializeField] private GameObject fireBallPrefab;
    private GameObject _fireBall;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGE, OnSpeedChanged);
    }

    void Destroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE, OnSpeedChanged);
    }

    //метод, объявленный в подписчике для события SPEED_CHANGE
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    void Start()
    {
        _alive=true;//инициализация переменной
    }
    void Update()
    {
        if (_alive)//движение начинается в случае живого персонажа
        {
            transform.Translate(0, 0, speed * Time.deltaTime);//Translate - обеспечивает неперрывное дивжение вперед в каждом кадре, несмотря на повороты

            Ray ray = new Ray(transform.position, transform.forward);//луч нацеливается в том же положении и нацеливается в том же направлении, что и персонаж
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))//бросаем луч с описанной вокруг него окружностью
            {
                GameObject hitGameObject = hit.transform.gameObject;
                if (hitGameObject.GetComponent<PlayerCharacter>())//Игрок распознается также как и мишень в RayCastShooter. Проверка попадания в объект PlayerCharacter, аналогично тому, как код стрельбы проверял наличие у пораженного объекта компонента ReactiveTarget
                {
                    if (_fireBall == null)//пораждаем новый огненный шар (см.SceneController)
                    {
                        _fireBall = Instantiate(fireBallPrefab) as GameObject;
                        _fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);//направляем огненный шар в направление движения врага
                        _fireBall.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);//повопрот с наполовину случайным выбором нового направления
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)//метод позволяющий внешнему коду воздействовать на "живое" состояние
    {
        _alive=alive;
    }
}
