using UnityEngine;

public class MenuDePausa : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // O Canvas do menu de pausa
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
        isPaused = true;
    }

    // Fun��o para retomar o jogo
    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); // Desativa o Canvas do menu de pausa
        Time.timeScale = 1f; // Retoma o jogo
        Cursor.lockState = CursorLockMode.Locked; // Tranca o cursor
        Cursor.visible = false; // Torna o cursor invis�vel
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
