
using UnityEngine;


public class FPSControllerVR : MonoBehaviour
{

    public bool canLook;

    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public Transform cameraTransform;

    private CharacterController characterController;
    private float xRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            canLook = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            canLook = false;
        }


        if (canLook == false)
        {
            Move();
        }

        else if (canLook == true)
        {
            LookAround();
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Horizontal") * lookSpeed;
        float mouseY = Input.GetAxis("Vertical") * lookSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
