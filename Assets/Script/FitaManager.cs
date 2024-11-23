using TMPro;
using UnityEngine;
using System.Collections;

public class FitaManager : MonoBehaviour
{
    public GameObject proximaFita; // Refer�ncia � pr�xima fita a ser ativada
    public TextMeshProUGUI mensagemTexto; // Refer�ncia ao texto da mensagem
    public FPSController fpsController; // Refer�ncia ao script do controle do jogador
    public AudioSource audioSource; // Refer�ncia ao componente de �udio
    public AudioClip somColeta; // Clip de �udio a ser tocado ao coletar a fita

    public bool isUltimaFita = false; // Indica se essa � a �ltima fita
    public GameObject canvasDeFimDeJogo; // Canvas que aparece no fim do jogo
    private bool jogadorDentroDoTrigger = false; // Verifica se o jogador est� no trigger

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
            // Se for a �ltima fita, ativa o canvas de fim de jogo
            if (canvasDeFimDeJogo != null)
            {
                canvasDeFimDeJogo.SetActive(true);
            }
        }
        else
        {
            // Ativa a pr�xima fita, se houver
            if (proximaFita != null)
            {
                proximaFita.SetActive(true);
            }
        }

        // Destroi a fita atual
        Destroy(gameObject);
    }
}
