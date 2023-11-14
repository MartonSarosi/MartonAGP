using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform target;
    public AnimationCurve curve;
    public float speed;
    public float cooldown = 5;
    private float timer;
    
    public void DoSlingshot(CharacterController controller)
    {
        if (timer <= 0)
        {
            StartCoroutine(UpdateSlingshot(controller));
            timer = cooldown;
        }
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    IEnumerator UpdateSlingshot(CharacterController controller)
    {
        Vector3 position = transform.position;
        Vector3 targetPosition = target.position;
        float time = 0.0f;
        while (time < 1.0f)
        {
            time += Time.deltaTime * speed;
            float curvePosition = curve.Evaluate(time);
            controller.Move(Vector3.Lerp(position, targetPosition, curvePosition) - transform.position);
            //transform.position = Vector3.Lerp(position, targetPosition, curvePosition);
            yield return null;
        }
    }
}
