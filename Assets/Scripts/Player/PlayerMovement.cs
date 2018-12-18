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
    [SerializeField] private float movementSpeed;
    private Vector3 nextPosition;

    private Vector3 joystickDirection;

    [SerializeField] private FloatingJoystick joystick;

    private Directions currentDirection;
    private Directions nextDirection;

    [SerializeField] private float inputDeadZone;

    private bool canMove;

    void Awake(){
        canMove = true;
        currentDirection = Directions.UP;
        nextPosition = transform.position;
    }

    void FixedUpdate(){
        if(Vector3.Distance(transform.position, nextPosition) >= 0.005){
            canMove = false;
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, movementSpeed*Time.deltaTime);
        }
        else{
            canMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        joystickDirection = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        if(Mathf.Abs(joystickDirection.x) > inputDeadZone){
            if(Mathf.Abs(joystickDirection.x) > Mathf.Abs(joystickDirection.y)){
                nextDirection = (Directions)(2-(int)Mathf.Sign(joystickDirection.x)*1);
                print("entrou1");
                print(nextDirection);
            }
        }
        if(Mathf.Abs(joystickDirection.y) > inputDeadZone){
            if(Mathf.Abs(joystickDirection.y) > Mathf.Abs(joystickDirection.x)){
                nextDirection = (Directions)(1-(int)Mathf.Sign(joystickDirection.y)*1);
                print("entrou2");
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
