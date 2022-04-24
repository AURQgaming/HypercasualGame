using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float force = 1000f;
    public float speed = 10f;
    public float maxX;
    public float minX;
    public bool isMovingLeft = false;
    public bool isMovingRight = false;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        transform.position = playerPos;

        if(isMovingRight)
        {
            transform.position = transform.position + new Vector3(speed* Time.deltaTime, 0, 0);
        }
        if(isMovingLeft)
        {
            transform.position = transform.position - new Vector3(speed* Time.deltaTime, 0, 0);
        }
    }
    public void TriggrLeft(bool canMove)
    {
        isMovingLeft = canMove;
    }
    public void TriggrRight(bool canMove)
    {
        isMovingRight = canMove;
    }


    
    public void MoveLeft()
    {
        transform.position = transform.position - new Vector3(speed* Time.deltaTime, 0, 0);
    }
    public void MoveRight()
    {
        transform.position = transform.position + new Vector3(speed* Time.deltaTime, 0, 0);
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(0, 0 ,400f* Time.deltaTime);
    }
}
