using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;


    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField] float padding=1f;


    // Start is called before the first frame update
    void Start()
    {
        
        setPlayerBounds();
    }

 
    private void setPlayerBounds()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint (new Vector3(0f, 0f, 0f)).x+padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x-padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y+padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y-padding;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*playerSpeed;
        
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);



        transform.position = new Vector2(newXPos, newYPos);
    }
}
