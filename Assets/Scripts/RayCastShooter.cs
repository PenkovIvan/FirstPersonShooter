using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//подключаем библиотеку для UI-системы

// Fade Duration в свитке Button отвечает за скорость возвращения кнопки к обычному цвету
public class RayCastShooter : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera=GetComponent<Camera>();//доступ к компонентам, присоединенным к этому же объекту
        //Cursor.lockState = CursorLockMode.Locked;//Скрываем указатель мыши в центре экрана
        //Cursor.visible=false;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX,posY,size,size),"*");//отображаем на экране *
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//реакция на нажатие кнопки  и проверка на то что UI не используется
        {
            Vector3 point=new Vector3(_camera.pixelWidth/2,_camera.pixelHeight/2,0);//середина экрана-это половина его высоты и ширины

            //создаем луч в точке point, т.е. в середине экрана
            Ray ray = _camera.ScreenPointToRay(point);//создали луч с пом-ю метода ScreenPointToRay

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//испущенны луч заполняет информацией переменную, на котрую имеется ссылка
            {
                //Debug.Log("Hit " + hit.point);//загружаем координаты точки в которую попал луч
                GameObject hitGameObject=hit.transform.gameObject;//получаем объект в кот попал луч
                ReactiveTarget target=hitGameObject.GetComponent<ReactiveTarget>();
                if (target != null)//проверяем наличие у этого объекта компонента ReactiveTarget
                {
                   // Debug.Log("Target hit");
                   target.ReactToHit();//вызываем метод для мишени вместо генерации отладочного сообщения
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));//запуск программы в ответ на попадание
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 hitPoint)//сопрограммы(coroutines) используются функциями IEnumerator
    {
       GameObject sphere=GameObject.CreatePrimitive(PrimitiveType.Sphere);
       sphere.transform.position=hitPoint;
       yield return new WaitForSeconds(1);//ключевое слово yield указывает сопрограмме, когда следует остановиться
       Destroy(sphere);//удаляем объект  GameObject sphere и освобождаем память
    }
}
