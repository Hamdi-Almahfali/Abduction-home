using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    [SerializeField] float groundDrag;
    [SerializeField] float airDrag;
    [SerializeField] float gravity;

    [SerializeField] GameObject stepRayUpper ;
    [SerializeField] GameObject stepRayLower ;

    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth;
    [SerializeField] float checkDist;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Physics.gravity = new Vector3(0f, gravity, 0f);

        //stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();

        //Drag
        rb.drag = grounded ? groundDrag : airDrag;
    }
    private void FixedUpdate()
    {
        MovePlayer();
        StepClimb();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        Vector3 forward = new Vector3(orientation.forward.x, 0, orientation.forward.z).normalized;
        Vector3 right = new Vector3(orientation.right.x, 0, orientation.right.z).normalized;

        // Create movement direction
        moveDirection = forward * verticalInput + right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    void StepClimb()
    {
        RaycastHit hitLower;

        // Cast the lower ray
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, checkDist))
        {
            //Debug.Log("Lower hit");

            // Cast the upper ray
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, checkDist))
            {
                //Debug.Log("Upper not hit");

                // Smoothly adjust the position upwards
                rb.position += new Vector3(0f, stepSmooth, 0f);
            }
        }
    }
}
