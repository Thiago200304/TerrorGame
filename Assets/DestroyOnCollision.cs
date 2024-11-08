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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorDentroDoCollider = true; // Jogador entrou no collider

            if (primeirafita)
            {
                porta.SetActive(true);
                GameData.numerodefitas++;

                // Exibe a mensagem "PRESSIONE 'E' PARA PEGAR A FITA"
                mensagemTexto.text = "PRESSIONE 'E'";
            }
            else
            {
                proxfita.SetActive(true);
                GameData.numerodefitas++;

                // Exibe a mensagem com base no ID da fita
                mensagemTexto.text = (ID == 1) ? texto1 : texto2;
            }

            mensagemTexto.gameObject.SetActive(true); // Exibe o texto
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
        // Verifica se o jogador está dentro do collider e pressionou "E"
        if (jogadorDentroDoCollider && Input.GetKeyDown(KeyCode.E))
        {
            // Destroi o objeto após a coleta da fita
            mensagemTexto.gameObject.SetActive(false); // Esconde a mensagem de coleta
            Destroy(gameObject);

            // Exibe a mensagem "ENTRE NA CASA" após a coleta
            mensagemTexto.text = "ENTRE NA CASA";
            mensagemTexto.gameObject.SetActive(true);

            // Inicia a corrotina para ocultar a mensagem após 5 segundos
            StartCoroutine(OcultarMensagem());
        }
    }

    private IEnumerator OcultarMensagem()
    {
        yield return new WaitForSeconds(duracaoMensagem);
        mensagemTexto.gameObject.SetActive(false);
    }
}
