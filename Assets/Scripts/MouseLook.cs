using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// MouseLook ������������ �������������� �� ������ ������ ����.
// ����� ������� ��������� � ����� FPS:
// - �������� �������.
// - �������� ������ MouseLook � �������.
// -> ���������� ��� ����, ����� ������������ mouseX. (�� ������ ������ ������������ ���������, �� �� ��������� ���)
// - // - �������� ������ ����� ������ � ������� � �������
// -> ��������� CharacterController ����� �������� �������������.
//
// - �������� ������. �������� ������ �������� ��������� �������. ����������� � ������� � �������� ��������.
// - �������� ������ MouseLook � ������.
// -> // -> ���������� ��� ���� �� ������������� ����. (�� ������, ����� ������ ����������� ����� � ����, ��� ������. �������� ��� ��������������.)
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

    public float sencitivityHor = 9.0f;//��������������� �� �����������
    public float sencitivityVert = 9.0f;//��������������� �� ���������
    public float minimumVert = -90.0f;
    public float maximumVert = 90.0F;

    private float _rotationX = 0;//���������� ��� ���� �������� �� ���������


    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();//Rigidbody ��� ���������, ������� ����� �������� ������.
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //������� � �������������� ���������
            transform.Rotate(0, Input.GetAxis("Mouse X") * sencitivityHor,0);//GetAxis-�������� ������ , �������� �����; class Input-�������� ���������� ������� ��� ��������� ����������, ������ � ��������� �����
        }
        else if (axes == RotationAxes.MouseY)
        {
            //������� � ������������ ���������
            _rotationX -= Input.GetAxis("Mouse Y") * sencitivityVert;//����������� ���� �������� �� ��������� � ����������� � ������������� ��������� ����
            _rotationX=Mathf.Clamp(_rotationX, minimumVert, maximumVert);//����� Mathf.Clamp ��������� ���������� ������� ������������� � ����������� ����������
            float rotationY=transform.localEulerAngles.y;//��������� ���������� ���� �������� ������ ��� y(�.�. ��������  � �������������� ��������� �����������
            transform.localEulerAngles=new Vector3(_rotationX, rotationY, 0);//������� ����� ������ �� ����������� ��������

        }
        else
        {
            //����� �������
            _rotationX -= Input.GetAxis("Mouse Y") * sencitivityVert;
            _rotationX= Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sencitivityHor;//�������� delta-�������� �������� ���� ��������
            float rotationY = transform.localEulerAngles.y + delta;//���������� ���� �������� ����� �������� delta
            transform.localEulerAngles=new Vector3(_rotationX, rotationY, 0);
        }
    }
}
