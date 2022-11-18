using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// базовое управление движением в стиле WASD
// закомментированная строка демонстрирует это преобразование.Перевести вместо charController.Перемещение не имеет функции обнаружения столкновений

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private  CharacterController _characterController;//переменная для ссылки на компонент  CharacterController

    void Start()
    {
        _characterController=GetComponent<CharacterController>();//Доступ к другим компонентам, присоединенным к этому же объекту

    }

    
    void Update()
    {
        
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //transform.Translate(deltaX*Time.deltaTime, 0, deltaZ*Time.deltaTime);//класс Time помогает регулировать время, св-во deltaTime-показывает величину изменения времени, а точнее время между кадрами,например , при частоте 30 кадров в секунду, deltaTime составляет 1/30 секунды.Т.е умножение скорости на эту переменную приведет к масштабированию скорости  на различных компах
        Vector3 movement= new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);//ограничивваем движение  по диагонали той же скоростью что и движение паралельно осям

       movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);//преобразуем вектор движения от локальных к глобальным кооординатам
        _characterController.Move(movement);//заставляем этот вектор перемещать компонет СharacterController

    }
}
