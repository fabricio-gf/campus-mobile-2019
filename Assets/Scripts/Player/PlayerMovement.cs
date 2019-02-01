using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum Directions
    {
        UP,
        RIGHT,
        DOWN,
        LEFT,
        NONE
    }

    [HideInInspector] public Directions FacingDirection;

    [Header("References")]
    //[SerializeField]
    private FloatingJoystick Joystick = null;
    
    [Header("Serialized Attributes")]
    [SerializeField] private float MovementSpeed = 0;
    [SerializeField] private float InputDeadZone = 0;
    [SerializeField] private float InitialInputDelay = 0;

    // PRIVATE ATTRIBUTES
    private Vector3 JoystickDirection;
    private Vector3 NextPosition;
    private Vector3 TargetPosition;
    private Directions NextDirection;
    private bool CanMove;
    private int ImpassableLayerIndex;
    private Animator animator;

    void Awake()
    {
        CanMove = true;

        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();

        FacingDirection = Directions.UP;
        TargetPosition = transform.position;
        NextPosition = transform.position;

        ImpassableLayerIndex = LayerMask.GetMask("Impassable") | LayerMask.GetMask("Interactable");

        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(WaitForInputDelay(InitialInputDelay));
    }

    // moves the player sprite in the game world
    void FixedUpdate(){
        if (Vector3.Distance(transform.position, TargetPosition) >= 0.005)
        {
            CanMove = false;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, MovementSpeed * Time.deltaTime);
            Rotate();
            animator.SetBool("IsWalking", true);
        }
        else
        {
            CanMove = true;
            //check analog
            Vector2 analog = (Vector3.right * Joystick.Horizontal + Vector3.up * Joystick.Vertical);
            if (Mathf.Abs(analog.x) <= InputDeadZone && Mathf.Abs(analog.y) <= InputDeadZone) { 
                animator.SetBool("IsWalking", false);
            }
        }
    }

    // checks the analog input and updates which direction the player must move
    void Update()
    {
        JoystickDirection = (Vector3.right * Joystick.Horizontal + Vector3.up * Joystick.Vertical);
        Debug.DrawRay(transform.position, JoystickDirection, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, JoystickDirection, 1f, ImpassableLayerIndex);
        if (hit)
        {
            NextDirection = Directions.NONE;

            if (Mathf.Abs(JoystickDirection.x) > InputDeadZone)
            {
                if (Mathf.Abs(JoystickDirection.x) > Mathf.Abs(JoystickDirection.y))
                {
                    FacingDirection = (Directions)(2 - (int)Mathf.Sign(JoystickDirection.x) * 1);
                }
            }
            if (Mathf.Abs(JoystickDirection.y) > InputDeadZone)
            {
                if (Mathf.Abs(JoystickDirection.y) > Mathf.Abs(JoystickDirection.x))
                {
                    FacingDirection = (Directions)(1 - (int)Mathf.Sign(JoystickDirection.y) * 1);
                }
            }
            Rotate();
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
            if(nextDirection != Directions.NONE) FacingDirection = nextDirection;
        }
    }

    void Rotate()
    {
        switch (FacingDirection)
        {
            case PlayerMovement.Directions.UP:
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 1);
                animator.SetFloat("Facing", 1);
                break;
            case PlayerMovement.Directions.RIGHT:
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Facing", 0.7f);
                break;
            case PlayerMovement.Directions.DOWN:
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", -1);
                animator.SetFloat("Facing", 0);
                break;
            case PlayerMovement.Directions.LEFT:
                animator.SetFloat("Horizontal", -1);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Facing", 0.3f);
                break;
            default:
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                break;
        }
    }

    IEnumerator WaitForInputDelay(float delay)
    {
        Joystick.BlockMovement();
        yield return new WaitForSeconds(delay);
        Joystick.ResumeMovement();
    }
}
