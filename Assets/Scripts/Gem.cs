using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")  //Проверка контакта с игроком
        {
            return;
        }

        GameManager.inst.IncrementGemScore();   //Добавление к счёту
        Destroy(gameObject);    //Удаление объекта
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, turnSpeed * Time.fixedDeltaTime, 0);
    }
}
