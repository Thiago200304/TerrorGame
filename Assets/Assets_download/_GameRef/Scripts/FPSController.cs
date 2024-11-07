using UnityEngine;
using TMPro; // Importar biblioteca TextMeshPro

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

    public GameObject lanterna; // Refer�ncia ao prefab Lanterna
    public GameObject bateria;  // Refer�ncia ao prefab Bateria
    public GameObject menu;     // Refer�ncia ao Canvas (Menu)
    public TextMeshProUGUI mensagem; // Refer�ncia ao componente TextMeshPro da mensagem

    private float mensagemTimer = 0f; // Temporizador da mensagem
    private bool mostrandoMensagem = false; // Controle da exibi��o da mensagem
    private bool mensagemMostrada = false; // Verifica se a mensagem j� foi mostrada

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        if (lanterna != null)
        {
            lanterna.SetActive(false); // Garantir que a lanterna come�a desativada
        }

        if (bateria != null)
        {
            bateria.SetActive(false); // Garantir que a bateria come�a desativada
        }

        if (menu != null)
        {
            menu.SetActive(true); // Garantir que o menu come�a ativado
        }

        if (mensagem != null)
        {
            mensagem.gameObject.SetActive(false); // Desativa a mensagem inicialmente
        }
    }

    void Update()
    {
        if (canmove)
        {
            Move();
            LookAround();
        }

        // Ao clicar na tela, ativa o movimento, a lanterna e a bateria, desativa o menu e mostra a mensagem
        if (Input.GetMouseButtonDown(0) && !mensagemMostrada)
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

            MostrarMensagem("ENCONTRE A FITA");
            mensagemMostrada = true; // Define que a mensagem j� foi mostrada
        }

        // Atualizar a exibi��o da mensagem se estiver ativa
        if (mostrandoMensagem)
        {
            mensagemTimer += Time.deltaTime;
            if (mensagemTimer >= 5f)
            {
                OcultarMensagem();
            }
        }
    }

    private void Move()
    {
        // Verificar se est� no ch�o
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Manter o personagem no ch�o
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

    // Fun��o para mostrar a mensagem
    private void MostrarMensagem(string texto)
    {
        if (mensagem != null)
        {
            mensagem.text = texto;
            mensagem.gameObject.SetActive(true);
            mostrandoMensagem = true;
            mensagemTimer = 0f; // Reinicia o temporizador
        }
    }

    // Fun��o para ocultar a mensagem
    private void OcultarMensagem()
    {
        if (mensagem != null)
        {
            mensagem.gameObject.SetActive(false);
            mostrandoMensagem = false;
        }
    }
}
