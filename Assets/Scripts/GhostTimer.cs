using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GhostTimer : MonoBehaviour
{
    public float timeLeft;
    public bool TimerOn = false;
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn= true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (TimerOn)
        //{
            //if (timeLeft > 0)
            //{
                //timeLeft -= Time.deltaTime;
                //updateTimer(timeLeft);
            //}
            //else
            //{
                //Debug.Log("Time is up!");
                //timeLeft = 0;
                //TimerOn = false;
            //}
        //}
    }

    public void GhostTimerOn (CharacterController controller)
    {
        if (TimerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is up!");
                timeLeft = 0;
                TimerOn = false;
                timerText.gameObject.SetActive(false);
            }
        }
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
