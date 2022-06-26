using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    public float lerpRate;
    public bool gameOver;

    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        gameOver = false;
        offset = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }
    void Follow()
    {

        //mycode: transform.position = ball.transform.position + offset;

        Vector3 pos =transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}