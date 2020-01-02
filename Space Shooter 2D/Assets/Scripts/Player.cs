using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 20f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
        setPlayerBounds();
    }

 
   

    // Update is called once per frame
    void Update()
    {
        move();
        Fire();
        
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")==true)
        {
            //my instinct would have been to have a laser script in order to manipulate the laser
            // would be interested in the pros and cons vs this way of controlling the laser through this script
            GameObject laser = 
                Instantiate(laserPrefab, transform.position, Quaternion.identity)
                as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);


        }
    }

    private void move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*playerSpeed;
        
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }
    private void setPlayerBounds()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y - padding;
    }

    
    
    IEnumerator test() 
    {
        print("test1");
        yield return new WaitForSeconds(3f);
        print("test dos");
    }
    
}
