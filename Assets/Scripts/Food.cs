using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float turnSpeed = 90f;

    PlayerMovement playerMovement;

    public bool canEat = false;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        //Проверка контакта с игроком
        if (other.gameObject.name != "Player")
        {
            return;
        }

        if(playerMovement.playerColor == 0)
        {
            if(tag == "cyan")
            {
                GameManager.inst.IncrementFoodScore();
                Destroy(gameObject);
            }
            else
            {
                playerMovement.Die();
            }
            
        } else if (playerMovement.playerColor == 1)
        {
            if (tag == "darkblue")
            {
                GameManager.inst.IncrementFoodScore();
                Destroy(gameObject);
            }
            else
            {
                playerMovement.Die();
            }
        }
        else if (playerMovement.playerColor == 2)
        {
            if (tag == "green")
            {
                GameManager.inst.IncrementFoodScore();
                Destroy(gameObject);
            }
            else
            {
                playerMovement.Die();
            }
        }
        else if (playerMovement.playerColor == 3)
        {
            if (tag == "yellow")
            {
                GameManager.inst.IncrementFoodScore();
                Destroy(gameObject);
            }
            else
            {
                playerMovement.Die();
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, turnSpeed * Time.fixedDeltaTime, 0);
    }
}
