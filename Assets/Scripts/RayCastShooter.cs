using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//���������� ���������� ��� UI-�������

// Fade Duration � ������ Button �������� �� �������� ����������� ������ � �������� �����
public class RayCastShooter : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera=GetComponent<Camera>();//������ � �����������, �������������� � ����� �� �������
        //Cursor.lockState = CursorLockMode.Locked;//�������� ��������� ���� � ������ ������
        //Cursor.visible=false;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX,posY,size,size),"*");//���������� �� ������ *
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())//������� �� ������� ������  � �������� �� �� ��� UI �� ������������
        {
            Vector3 point=new Vector3(_camera.pixelWidth/2,_camera.pixelHeight/2,0);//�������� ������-��� �������� ��� ������ � ������

            //������� ��� � ����� point, �.�. � �������� ������
            Ray ray = _camera.ScreenPointToRay(point);//������� ��� � ���-� ������ ScreenPointToRay

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//��������� ��� ��������� ����������� ����������, �� ������ ������� ������
            {
                //Debug.Log("Hit " + hit.point);//��������� ���������� ����� � ������� ����� ���
                GameObject hitGameObject=hit.transform.gameObject;//�������� ������ � ��� ����� ���
                ReactiveTarget target=hitGameObject.GetComponent<ReactiveTarget>();
                if (target != null)//��������� ������� � ����� ������� ���������� ReactiveTarget
                {
                   // Debug.Log("Target hit");
                   target.ReactToHit();//�������� ����� ��� ������ ������ ��������� ����������� ���������
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));//������ ��������� � ����� �� ���������
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 hitPoint)//�����������(coroutines) ������������ ��������� IEnumerator
    {
       GameObject sphere=GameObject.CreatePrimitive(PrimitiveType.Sphere);
       sphere.transform.position=hitPoint;
       yield return new WaitForSeconds(1);//�������� ����� yield ��������� �����������, ����� ������� ������������
       Destroy(sphere);//������� ������  GameObject sphere � ����������� ������
    }
}
