using UnityEngine;

public class MenuDePausa : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // O Canvas do menu de pausa
    public MonoBehaviour cameraController; // Refer�ncia ao script de controle de c�mera
    public FPSController playerController; // Refer�ncia ao script do player
    private bool isPaused = false; // Controle para verificar se o jogo est� pausado

    void Start()
    {
        pauseMenuCanvas.SetActive(false); // Inicialmente, o menu est� desativado
    }

    void Update()
    {
        // Verifica se o jogador pressionou a tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Fun��o para pausar o jogo e exibir o menu
    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true); // Ativa o Canvas do menu de pausa
        Time.timeScale = 0f; // Pausa o jogo
        Cursor.lockState = CursorLockMode.None; // Libera o cursor
        Cursor.visible = true; // Torna o cursor vis�vel
        cameraController.enabled = false; // Desativa o controle da c�mera
        isPaused = true;
    }

    // Fun��o para retomar o jogo
    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); // Desativa o Canvas do menu de pausa
        Time.timeScale = 1f; // Retoma o jogo
        Cursor.lockState = CursorLockMode.Locked; // Tranca o cursor
        Cursor.visible = false; // Torna o cursor invis�vel
        cameraController.enabled = true; // Reativa o controle da c�mera
        isPaused = false;
    }

    // Fun��o para sair do jogo (ou sair da aplica��o)
    public void QuitGame()
    {
        // Se estiver no editor do Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Se estiver no build final
        Application.Quit();
#endif
    }
}
