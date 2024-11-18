using JetBrains.Annotations;
using TMPro; // Para usar TextMeshPro
using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject proxfita;
    public GameObject porta;
    public bool primeirafita;
    public TextMeshProUGUI mensagemTexto; // Referência para o objeto de texto
    public float duracaoMensagem = 5f; // Duração que a mensagem ficará visível, configurada para 5 segundos

    public string texto1;
    public string texto2;

    public int ID;
    public bool fitacoletada;
    private bool jogadorDentroDoCollider = false; // Variável para rastrear se o jogador está no collider

    public FPSController fpsController; // Referência ao script FPSController para reiniciar o timer

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorDentroDoCollider = true; // Jogador entrou no collider

            if (primeirafita)
            {
                porta.SetActive(true); // Ativa a porta ao pegar a primeira fita
                GameData.numerodefitas++;

                // Exibe a mensagem "PRESSIONE E" para pegar a fita
                mensagemTexto.text = "PRESSIONE E";
            }
            else
            {
                proxfita.SetActive(true); // Ativa o próximo objeto de fita
                GameData.numerodefitas++;

                // Exibe a mensagem com base no ID da fita
                mensagemTexto.text = (ID == 1) ? texto1 : texto2;
            }

            mensagemTexto.gameObject.SetActive(true); // Exibe o texto de interação
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorDentroDoCollider = false; // Jogador saiu do collider
            mensagemTexto.gameObject.SetActive(false); // Esconde a mensagem ao sair
        }
    }

    private void Update()
    {
        // Verifica se o jogador está dentro do collider e pressionou "E" para coletar a fita
        if (jogadorDentroDoCollider && Input.GetKeyDown(KeyCode.E))
        {
            // Destroi o objeto da fita após a coleta
            mensagemTexto.gameObject.SetActive(false); // Esconde a mensagem de interação
            Destroy(gameObject); // Destroi a fita coletada

            // Exibe a mensagem "ENTRE NA CASA" após a coleta
            mensagemTexto.text = "ENTRE NA CASA";
            mensagemTexto.gameObject.SetActive(true);

            // Reinicia o timer do jogo
            fpsController.ReiniciarTimer();

            // Inicia a corrotina para ocultar a mensagem após 5 segundos
            StartCoroutine(OcultarMensagem());
        }
    }

    private IEnumerator OcultarMensagem()
    {
        yield return new WaitForSeconds(duracaoMensagem);
        mensagemTexto.gameObject.SetActive(false); // Esconde a mensagem após a duração
    }
}
