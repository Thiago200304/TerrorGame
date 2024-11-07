using JetBrains.Annotations;
using TMPro; // Para usar TextMeshPro
using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject proxfita;
    public GameObject porta;
    public bool primeirafita;
    public TextMeshProUGUI mensagemTexto; // Refer�ncia para o objeto de texto
    public float duracaoMensagem = 5f; // Dura��o que a mensagem ficar� vis�vel

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (primeirafita)
            {
                porta.SetActive(true);
                GameData.numerodefitas++;

                // Exibe a mensagem "entre na casa"
                mensagemTexto.text = "ENTRE NA CASA";
                mensagemTexto.gameObject.SetActive(true);

                // Inicia a corrotina para ocultar a mensagem ap�s a dura��o configurada
                StartCoroutine(OcultarMensagem());

                Destroy(gameObject);
            }
            else
            {
                proxfita.SetActive(true);
                GameData.numerodefitas++;
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator OcultarMensagem()
    {
        yield return new WaitForSeconds(duracaoMensagem);
        mensagemTexto.gameObject.SetActive(false);
    }
}
