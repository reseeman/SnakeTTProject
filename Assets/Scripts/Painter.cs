using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    PlayerMovement playerMovement;

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

        if(tag == "cyan")
        {
            playerMovement.GetComponent<MeshRenderer>().material.color = Color.cyan;
            playerMovement.playerColor = 0;
        } else if (tag == "darkblue")
        {
            playerMovement.GetComponent<MeshRenderer>().material.color = Color.blue;
            playerMovement.playerColor = 1;
        } else if (tag == "green")
        {
            playerMovement.GetComponent<MeshRenderer>().material.color = Color.green;
            playerMovement.playerColor = 2;
        } else if (tag == "yellow")
        {
            playerMovement.GetComponent<MeshRenderer>().material.color = Color.yellow;
            playerMovement.playerColor = 3;
        }
    }

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
}
