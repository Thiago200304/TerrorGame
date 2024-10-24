using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float jumpHeight = 2f; // Altura do pulo
    public Transform cameraTransform;

    private CharacterController characterController;
    private float xRotation = 0f;
    private Vector3 velocity;
    private bool isGrounded;

    public float gravity = -9.81f; // Gravidade

    private bool canmove = false;

    public GameObject lanterna; // Referência ao prefab Lanterna
    public GameObject bateria;  // Referência ao prefab Bateria
    public GameObject menu;     // Referência ao Canvas (Menu)

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        if (lanterna != null)
        {
            lanterna.SetActive(false); // Garantir que a lanterna começa desativada
        }

        if (bateria != null)
        {
            bateria.SetActive(false); // Garantir que a bateria começa desativada
        }

        if (menu != null)
        {
            menu.SetActive(true); // Garantir que o menu começa ativado
        }
    }

    void Update()
    {
        if (canmove)
        {
            Move();
            LookAround();
        }

        // Ao clicar na tela, ativa o movimento, a lanterna e a bateria, e desativa o menu
        if (Input.GetMouseButtonDown(0))
        {
            canmove = true;

            if (lanterna != null)
            {
                lanterna.SetActive(true); // Ativa o prefab Lanterna
            }

            if (bateria != null)
            {
                bateria.SetActive(true); // Ativa o prefab Bateria
            }

            if (menu != null)
            {
                menu.SetActive(false); // Desativa o menu (Canvas)
            }
        }
    }

    private void Move()
    {
        // Verificar se está no chão
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Manter o personagem no chão
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Pular
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplicar gravidade
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
