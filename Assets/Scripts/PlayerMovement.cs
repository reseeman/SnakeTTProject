using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public int playerColor;
    //0 - cyan
    //1 - darkblue
    //2 - green
    //3 - yellow

    public float speed = 2f;
    public int horizontalMultuplier = 5;
    public int speedMultiplier = 10;
    private Rigidbody _rb;
    public float horSpeed = 2f;

    public int max_x;
    public int min_x;

    bool walkRight = false;
    bool walkLeft = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerColor = Random.Range(0, 3);
    }

    void FixedUpdate()
    {
        if (!alive) return;

        Movement();
        //MoveLeft();
        //MoveRight();

        CurrentColor();

        //Границы передвижения
        if (this.transform.position.x > max_x)
            this.transform.position = new Vector3(max_x, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x < min_x)
            this.transform.position = new Vector3(min_x, this.transform.position.y, this.transform.position.z);

        //if (GameManager.inst.gemScore == 3)
        //{
        GameManager.inst.CheckFever();
        //}

        if(walkRight != false)
        {
            Vector3 movement = new Vector3(horSpeed * horizontalMultuplier, 0.0f, 0.0f);
            transform.Translate(movement * Time.fixedDeltaTime);
        } else if (walkLeft != false)
        {
            Vector3 movement = new Vector3(-horSpeed * horizontalMultuplier, 0.0f, 0.0f);
            transform.Translate(movement * Time.fixedDeltaTime);
        } else
        {
            return;
        }
    }

    public void Movement()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(moveHorizontal * horizontalMultuplier, 0.0f, speed * speedMultiplier);
        Vector3 movement = new Vector3(0.0f, 0.0f, speed * speedMultiplier);
        transform.Translate(movement * Time.fixedDeltaTime);
    }

    public void MoveRight()
    {
        walkRight = true;
    }

    public void MoveLeft()
    {
        walkLeft = true;
    }

    public void MoveStop()
    {
        walkRight = false;
        walkLeft = false;
    }

    public void Die()
    {
        if (GameManager.inst.immortal != true)
        {
            alive = false;
            GameManager.inst.diedText.enabled = true;
            GameManager.inst.diedText.text = "You died";
            Invoke("Restart", 2);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CurrentColor()
    {
        if (playerColor == 0)
            GetComponent<MeshRenderer>().material.color = Color.cyan;
        else if (playerColor == 1)
            GetComponent<MeshRenderer>().material.color = Color.blue;
        else if (playerColor == 2)
            GetComponent<MeshRenderer>().material.color = Color.green;
        else if (playerColor == 3)
            GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}
