using TMPro;
using UnityEngine;
using System.Collections;

public class FitaManager : MonoBehaviour
{
    public GameObject proximaFita; // Referência à próxima fita a ser ativada
    public TextMeshProUGUI mensagemTexto; // Referência ao texto da mensagem
    public FPSController fpsController; // Referência ao script do controle do jogador
    public AudioSource audioSource; // Referência ao componente de áudio
    public AudioClip somColeta; // Clip de áudio a ser tocado ao coletar a fita

    public bool isUltimaFita = false; // Indica se essa é a última fita
    public GameObject canvasDeFimDeJogo; // Canvas que aparece no fim do jogo
    private bool jogadorDentroDoTrigger = false; // Verifica se o jogador está no trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorDentroDoTrigger = true; // Jogador entrou no trigger
            mensagemTexto.text = "PRESSIONE E";
            mensagemTexto.gameObject.SetActive(true); // Exibe a mensagem
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorDentroDoTrigger = false; // Jogador saiu do trigger
            mensagemTexto.gameObject.SetActive(false); // Esconde a mensagem
        }
    }

    private void Update()
    {
        if (jogadorDentroDoTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ColetarFita();
        }
    }

    private void ColetarFita()
    {
        // Toca o som da coleta
        if (audioSource != null && somColeta != null)
        {
            audioSource.PlayOneShot(somColeta);
        }

        // Reinicia o timer do jogador
        if (fpsController != null)
        {
            fpsController.ReiniciarTimer();
        }

        // Esconde a mensagem
        mensagemTexto.gameObject.SetActive(false);

        if (isUltimaFita)
        {
            // Se for a última fita, ativa o canvas de fim de jogo
            if (canvasDeFimDeJogo != null)
            {
                canvasDeFimDeJogo.SetActive(true);
            }
        }
        else
        {
            // Ativa a próxima fita, se houver
            if (proximaFita != null)
            {
                proximaFita.SetActive(true);
            }
        }

        // Destroi a fita atual
        Destroy(gameObject);
    }
}
