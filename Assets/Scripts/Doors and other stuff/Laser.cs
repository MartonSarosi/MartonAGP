using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform startPoint;

    public Animator doorAnim;
    //public GameObject DeadMenuUI;

    void Start()
    {
        lr= GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit))
        {

            lr.SetPosition(1, hit.point);
            doorAnim.SetBool("PlayerOn", false);
            //Time.timeScale = 1f;

            if (hit.transform.name == "LaserEnd")
            {
                lr.SetPosition(1, hit.point);
                doorAnim.SetBool("PlayerOn", true);
                //Time.timeScale = 1f;
            }

            //if (hit.transform.tag == "Player")
            //
                //Time.timeScale = 0f;
                //DeadMenuUI.SetActive(true);
            //}
        }
        else
        {
            lr.SetPosition(1, -transform.right * 5000);
            //Time.timeScale = 1f;
        }
    }
}
