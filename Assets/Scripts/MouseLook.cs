using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// MouseLook поворачивает преобразование на основе дельты мыши.
// Чтобы создать персонажа в стиле FPS:
// - Создайте капсулу.
// - Добавьте скрипт MouseLook в капсулу.
// -> Установите вид мыши, чтобы использовать mouseX. (Вы хотите только поворачивать персонажа, но не наклонять его)
// - // - Добавить скрипт ввода кадров в секунду в капсулу
// -> Компонент CharacterController будет добавлен автоматически.
//
// - Создайте камеру. Сделайте камеру дочерним элементом капсулы. Расположите в головке и сбросьте вращение.
// - Добавьте скрипт MouseLook в камеру.
// -> // -> Установите вид мыши на использование мыши. (Вы хотите, чтобы камера наклонялась вверх и вниз, как голова. Персонаж уже поворачивается.)
[AddComponentMenu("Control Script/Mouse Look")]
public class MouseLook : MonoBehaviour
{
 
    public enum RotationAxes
    {
        MouseXAndY=0,
        MouseX=1,
        MouseY=2,
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sencitivityHor = 9.0f;//чуствительность по горизонтали
    public float sencitivityVert = 9.0f;//чуствительность по вертикали
    public float minimumVert = -90.0f;
    public float maximumVert = 90.0F;

    private float _rotationX = 0;//переменная для угла поворота по вертикали


    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();//Rigidbody доп компонент, которым может обладать объект.
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //поворот в горизонтальной плоскости
            transform.Rotate(0, Input.GetAxis("Mouse X") * sencitivityHor,0);//GetAxis-получает данные , вводимые мышью; class Input-обладает множеством методов для обработки информации, поступ с устройств ввода
        }
        else if (axes == RotationAxes.MouseY)
        {
            //поворот в вертикальной плоскости
            _rotationX -= Input.GetAxis("Mouse Y") * sencitivityVert;//увеличиваем угол поворота по вертикали в соответсвии с перемещениями указателя мыши
            _rotationX=Mathf.Clamp(_rotationX, minimumVert, maximumVert);//метод Mathf.Clamp позволяет ограничить парметр максималльным и минимальным значениями
            float rotationY=transform.localEulerAngles.y;//сохраняем одинаковый угол поворота вокруг оси y(т.е. вращение  в горизонтальной плоскости отсутствует
            transform.localEulerAngles=new Vector3(_rotationX, rotationY, 0);//создаем новый вектор из сохраненных значений

        }
        else
        {
            //комбо поворот
            _rotationX -= Input.GetAxis("Mouse Y") * sencitivityVert;
            _rotationX= Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sencitivityHor;//значение delta-величина изменеия угла поворота
            float rotationY = transform.localEulerAngles.y + delta;//приращение угла поворота через значение delta
            transform.localEulerAngles=new Vector3(_rotationX, rotationY, 0);
        }
    }
}
