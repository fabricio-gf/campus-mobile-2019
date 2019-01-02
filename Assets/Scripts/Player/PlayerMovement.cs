using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum Directions
    {
        UP,
        RIGHT,
        DOWN,
        LEFT,
        NONE
    }

    [Header("References")]
    [SerializeField] private FloatingJoystick joystick;
    
    [Header("Serialized Attributes")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float inputDeadZone;

    // Private Attibutes
    private Vector3 joystickDirection;
    private Vector3 nextPosition;
    private Directions currentDirection;
    private Directions nextDirection;
    private bool canMove;

    void Awake(){
        canMove = true;
        currentDirection = Directions.UP;
        nextPosition = transform.position;
    }

    // moves the player sprite in the game world
    void FixedUpdate(){
        if(Vector3.Distance(transform.position, nextPosition) >= 0.005){
            canMove = false;
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, movementSpeed*Time.deltaTime);
        }
        else{
            canMove = true;
        }
    }

    // checks the analog input and updates which direction the player must move
    void Update()
    {
        joystickDirection = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        if(Mathf.Abs(joystickDirection.x) > inputDeadZone){
            if(Mathf.Abs(joystickDirection.x) > Mathf.Abs(joystickDirection.y)){
                nextDirection = (Directions)(2-(int)Mathf.Sign(joystickDirection.x)*1);
                print(nextDirection);
            }
        }
        if(Mathf.Abs(joystickDirection.y) > inputDeadZone){
            if(Mathf.Abs(joystickDirection.y) > Mathf.Abs(joystickDirection.x)){
                nextDirection = (Directions)(1-(int)Mathf.Sign(joystickDirection.y)*1);
                print(nextDirection);
            }
        }
        if(Mathf.Abs(joystickDirection.x) <= inputDeadZone && Mathf.Abs(joystickDirection.y) <= inputDeadZone){
            nextDirection = Directions.NONE;
        }

        if(canMove && nextDirection != Directions.NONE){
            SetNextMovement(nextDirection);
        }
    }

    // updates the next position the player should move
    void SetNextMovement(Directions nextDirection){
        Vector3 movementVector;
        switch (nextDirection)
        {
            case Directions.UP:
                movementVector = new Vector3(0,1,0);
            break;
            case Directions.RIGHT:
                movementVector = new Vector3(1,0,0);
            break;
            case Directions.DOWN:
                movementVector = new Vector3(0,-1,0);
            break;
            case Directions.LEFT:
                movementVector = new Vector3(-1,0,0);
            break;
            default:
                movementVector = new Vector3(0,0,0);
            break;
        }
        nextPosition = transform.position + movementVector;
    }
}
