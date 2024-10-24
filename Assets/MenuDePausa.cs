using UnityEngine;

public class MenuDePausa : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // O Canvas do menu de pausa
    public FPSController playerController; // Referência ao script do player
    private bool isPaused = false; // Controle para verificar se o jogo está pausado

    void Start()
    {
        pauseMenuCanvas.SetActive(false); // Inicialmente, o menu está desativado
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

    // Função para pausar o jogo e exibir o menu
    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true); // Ativa o Canvas do menu de pausa
        Time.timeScale = 0f; // Pausa o jogo
        Cursor.lockState = CursorLockMode.None; // Libera o cursor
        Cursor.visible = true; // Torna o cursor visível
        isPaused = true;
    }

    // Função para retomar o jogo
    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); // Desativa o Canvas do menu de pausa
        Time.timeScale = 1f; // Retoma o jogo
        Cursor.lockState = CursorLockMode.Locked; // Tranca o cursor
        Cursor.visible = false; // Torna o cursor invisível
        isPaused = false;
    }

    // Função para sair do jogo (ou sair da aplicação)
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
