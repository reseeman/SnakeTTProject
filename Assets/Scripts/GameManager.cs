using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gemScore;
    public int foodScore;
    public static GameManager inst;
    public TMP_Text gemScoreText;
    public TMP_Text foodScoreText;
    public TMP_Text feverText;
    public TMP_Text diedText;

    public float timer = 4f;

    public bool immortal;
    bool isFever;

    private void Awake()
    {
        inst = this;
        feverText.enabled = false;
        diedText.enabled = false;
    }

    public void IncrementGemScore()
    {
        gemScore++;
        gemScoreText.text = System.Convert.ToString(gemScore);
    }

    public void IncrementFoodScore()
    {
        foodScore++;
        foodScoreText.text = System.Convert.ToString(foodScore);
    }

    public void CheckFever()
    {
        if(gemScore == 3)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                isFever = false;
                immortal = false;
                GameObject.Find("Player").GetComponent<CapsuleCollider>().enabled = true;
                feverText.enabled = false;
                //gemScore = 0;
                //gemScoreText.text = "Gems: 0";
            }
            else {
                isFever = true;
                immortal = true;
                GameObject.Find("Player").GetComponent<CapsuleCollider>().enabled = false;
                feverText.enabled = true;
                feverText.text = "FEVER: " + System.Convert.ToString((int)timer);
            }
        }
    }
}
