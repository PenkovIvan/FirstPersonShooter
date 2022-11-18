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

    private  CharacterController _characterController;//���������� ��� ������ �� ���������  CharacterController

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
