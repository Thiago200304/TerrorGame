using TMPro; // Para usar TextMeshPro
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
    public TextMeshProUGUI mensagem; // Referência ao componente TextMeshPro da mensagem
    public TextMeshProUGUI timerTexto; // Referência ao TextMeshPro para mostrar o timer

    private float mensagemTimer = 0f; // Temporizador da mensagem
    private bool mostrandoMensagem = false; // Controle da exibição da mensagem
    private bool mensagemMostrada = false; // Verifica se a mensagem já foi mostrada

    public float timer = 60f; // Timer de 1 minuto
    public GameObject canvasDerrota; // Referência ao Canvas de Derrota

    public float duracaoMensagem = 5f; // Duração da mensagem em segundos

    // Variáveis para o áudio
    public AudioSource audioSource; // Referência ao AudioSource
    public AudioClip audioAndar;    // Áudio para andar

    private Color corOriginal; // Cor original do timer

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.None; // Libera o cursor no início
        Cursor.visible = true;

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

        if (mensagem != null)
        {
            mensagem.gameObject.SetActive(false); // Desativa a mensagem inicialmente
        }

        if (timerTexto != null)
        {
            timerTexto.gameObject.SetActive(true); // Certifique-se de que o texto do timer está ativo
            timerTexto.text = "Tempo: " + Mathf.Ceil(timer).ToString() + "s"; // Exibe o timer inicial

            // Armazena a cor original do texto
            corOriginal = timerTexto.color;
        }

        if (canvasDerrota != null)
        {
            canvasDerrota.SetActive(false); // Certifique-se de que o canvas de derrota está inicialmente oculto
        }

        if (audioSource != null && audioAndar != null)
        {
            audioSource.clip = audioAndar; // Define o áudio que será tocado ao andar
        }
    }

    void Update()
    {
        if (canmove)
        {
            Move();
            LookAround();
        }

        if (Input.GetMouseButtonDown(0) && !mensagemMostrada)
        {
            canmove = true;

            if (lanterna != null)
            {
                lanterna.SetActive(true); // Ativa a lanterna
            }

            if (bateria != null)
            {
                bateria.SetActive(true); // Ativa a bateria
            }

            if (menu != null)
            {
                menu.SetActive(false); // Desativa o menu
            }

            Cursor.lockState = CursorLockMode.Locked; // Trava o cursor novamente
            Cursor.visible = false; // Torna o cursor invisível

            MostrarMensagem("ENCONTRE A FITA");
            mensagemMostrada = true; // Define que a mensagem foi mostrada
        }

        // Atualizar o timer
        if (canmove && timer > 0)
        {
            timer -= Time.deltaTime; // Diminui o timer a cada frame
            if (timerTexto != null)
            {
                timerTexto.text = "Tempo: " + Mathf.Ceil(timer).ToString() + "s";

                // Verifica se o timer chegou a 10 segundos e altera a cor
                if (timer <= 10f)
                {
                    timerTexto.color = new Color32(67, 0, 0, 255); // Cor #430000
                }
                else
                {
                    timerTexto.color = corOriginal; // Restaura a cor original
                }
            }
        }
        else if (timer <= 0)
        {
            EndGame();
        }

        // Atualizar a exibição da mensagem, se estiver visível
        if (mensagemMostrada)
        {
            mensagemTimer += Time.deltaTime;
            if (mensagemTimer >= duracaoMensagem)
            {
                OcultarMensagem();
            }
        }
    }

    private void Move()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Manter o personagem no chão
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Tocar o áudio enquanto anda
        if (moveX != 0f || moveZ != 0f) // Se houver movimento
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Reproduz o áudio ao andar
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Para o áudio quando o movimento parar
            }
        }

        // Pular
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

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

    private void OcultarMensagem()
    {
        if (mensagem != null)
        {
            mensagem.gameObject.SetActive(false);
            mensagemMostrada = false;
        }
    }

    public void ReiniciarTimer()
    {
        timer = 60f; // Reinicia o timer para 60 segundos
        if (timerTexto != null)
        {
            timerTexto.text = "Tempo: " + Mathf.Ceil(timer).ToString() + "s";
        }
        timerTexto.color = corOriginal; // Restaura a cor original quando o timer é reiniciado
    }

    private void EndGame()
    {
        if (canvasDerrota != null)
        {
            canvasDerrota.SetActive(true); // Mostra o Canvas de derrota
        }

        Cursor.lockState = CursorLockMode.None; // Libera o cursor
        Cursor.visible = true; // Torna o cursor visível
    }
}
