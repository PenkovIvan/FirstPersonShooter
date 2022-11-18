using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10F;
    public int damage = 1;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    //��� �-��� ���������� ����� � ��������� ������������ ������ ������
    void OnTriggerEnter(Collider collider)
    {
        PlayerCharacter player = collider.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);

    }
    //���������� ������ Is Trigger � ������� Sphere Collider
    //� �������� ��������� Rigidbody � ����� ������ use gravity
}
