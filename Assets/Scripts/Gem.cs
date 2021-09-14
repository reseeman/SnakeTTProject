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

        if (other.gameObject.name != "Player")  //�������� �������� � �������
        {
            return;
        }

        GameManager.inst.IncrementGemScore();   //���������� � �����
        Destroy(gameObject);    //�������� �������
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, turnSpeed * Time.fixedDeltaTime, 0);
    }
}
