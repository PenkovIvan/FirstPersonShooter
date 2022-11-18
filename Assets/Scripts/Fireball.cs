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
    //эта ф-ция вызывается когда с триггером сталкивается другой объект
    void OnTriggerEnter(Collider collider)
    {
        PlayerCharacter player = collider.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);

    }
    //установите флажок Is Trigger в разделе Sphere Collider
    //и добавить компонент Rigidbody и снять флажок use gravity
}
