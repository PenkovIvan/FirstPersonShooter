using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ������� ���������� ��������� � ����� WASD
// ������������������ ������ ������������� ��� ��������������.��������� ������ charController.����������� �� ����� ������� ����������� ������������

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public const float baseSpeed = 6.0f;

    private  CharacterController _characterController;//���������� ��� ������ �� ���������  CharacterController

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGE, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE,OnSpeedChanged);

    }

    private void OnSpeedChanged(float val)
    {
        speed = baseSpeed * val;
    }

    void Start()
    {
        _characterController=GetComponent<CharacterController>();//������ � ������ �����������, �������������� � ����� �� �������

    }

    
    void Update()
    {
        
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //transform.Translate(deltaX*Time.deltaTime, 0, deltaZ*Time.deltaTime);//����� Time �������� ������������ �����, ��-�� deltaTime-���������� �������� ��������� �������, � ������ ����� ����� �������,�������� , ��� ������� 30 ������ � �������, deltaTime ���������� 1/30 �������.�.� ��������� �������� �� ��� ���������� �������� � ��������������� ��������  �� ��������� ������
        Vector3 movement= new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);//������������� ��������  �� ��������� ��� �� ��������� ��� � �������� ���������� ����

       movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);//����������� ������ �������� �� ��������� � ���������� ������������
        _characterController.Move(movement);//���������� ���� ������ ���������� �������� �haracterController

    }
}
