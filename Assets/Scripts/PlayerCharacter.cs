using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;


    void Start()
    {
        _health = 5;//инициализация переменной _health
    }

    public void Hurt(int damage)
    {
        _health -= damage;//уменьшение здоровья игрока
        Debug.Log($"Health:{_health}");
    }
  
}
