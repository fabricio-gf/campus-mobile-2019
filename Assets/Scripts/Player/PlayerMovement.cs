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
    [SerializeField] private FloatingJoystick Joystick = null;
    
    [Header("Serialized Attributes")]
    [SerializeField] private float MovementSpeed = 0;
    [SerializeField] private float InputDeadZone = 0;

    // PRIVATE ATTRIBUTES
    private Vector3 JoystickDirection;
    private Vector3 NextPosition;
    private Vector3 TargetPosition;
    private Directions NextDirection;
    private bool CanMove;
    private int ImpassableLayerIndex;

    void Awake()
    {
        CanMove = true;
        //currentDirection = Directions.UP;
        TargetPosition = transform.position;
        NextPosition = transform.position;

        ImpassableLayerIndex = LayerMask.NameToLayer("Impassable");
    }

    // moves the player sprite in the game world
    void FixedUpdate(){
        if(Vector3.Distance(transform.position, TargetPosition) >= 0.005){
            CanMove = false;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, MovementSpeed*Time.deltaTime);
        }
        else{
            CanMove = true;
        }
    }

    // checks the analog input and updates which direction the player must move
    void Update()
    {
        JoystickDirection = (Vector3.right * Joystick.Horizontal + Vector3.up * Joystick.Vertical);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, ImpassableLayerIndex);
        print(hit.point);
        if (hit)
        {
            print("hit");
        }
        else
        {
            if (Mathf.Abs(JoystickDirection.x) > InputDeadZone)
            {
                if (Mathf.Abs(JoystickDirection.x) > Mathf.Abs(JoystickDirection.y))
                {
                    NextDirection = (Directions)(2 - (int)Mathf.Sign(JoystickDirection.x) * 1);
                }
            }
            if (Mathf.Abs(JoystickDirection.y) > InputDeadZone)
            {
                if (Mathf.Abs(JoystickDirection.y) > Mathf.Abs(JoystickDirection.x))
                {
                    NextDirection = (Directions)(1 - (int)Mathf.Sign(JoystickDirection.y) * 1);
                }
            }
            if (Mathf.Abs(JoystickDirection.x) <= InputDeadZone && Mathf.Abs(JoystickDirection.y) <= InputDeadZone)
            {
                NextDirection = Directions.NONE;
            }

        if (CanMove && NextDirection != Directions.NONE)
        {

        }
        SetNextMovement(NextDirection);
        
        }
    }

    // updates the next position the player should move
    void SetNextMovement(Directions nextDirection)
    {

        Vector3 movementVector;
        switch (nextDirection)
        {
            case Directions.UP:
                movementVector = new Vector3(0, 1, 0);
                break;
            case Directions.RIGHT:
                movementVector = new Vector3(1, 0, 0);
                break;
            case Directions.DOWN:
                movementVector = new Vector3(0, -1, 0);
                break;
            case Directions.LEFT:
                movementVector = new Vector3(-1, 0, 0);
                break;
            default:
                movementVector = new Vector3(0, 0, 0);
                break;
        }
        NextPosition = transform.position + movementVector;
        if (CanMove)
        {
            TargetPosition = NextPosition;
        }
    }
}
