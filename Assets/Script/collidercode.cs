using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidercode : MonoBehaviour
{
    // Refer�ncia ao objeto que exibir� o texto
    public TextMeshProUGUI textoMensagem;

    // Nome da cena que ser� carregada (atualizado para "Casa")
    public string sceneToLoad = "Casa";

    private bool playerInsideTrigger = false;

    private void Start()
    {
        // Verifica se o texto est� configurado, se n�o, exibe uma mensagem de erro
        if (textoMensagem == null)
        {
            Debug.LogError("Refer�ncia para o TextMeshProUGUI n�o atribu�da.");
        }
        else
        {
            textoMensagem.gameObject.SetActive(false); // Desativa o texto no in�cio
        }
    }

    private void Update()
    {
        // Verifica se o jogador est� dentro do trigger e se a tecla E foi pressionada
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene(); // Carrega a cena quando a tecla "E" for pressionada
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Quando colidir com um objeto que tem a tag Player (ou qualquer tag que voc� defina)
        if (other.CompareTag("Player"))
        {
            if (textoMensagem != null)
            {
                textoMensagem.gameObject.SetActive(true); // Exibe o texto
            }
            playerInsideTrigger = true; // Marca que o player est� dentro da �rea
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Quando o objeto sai da �rea de colis�o
        if (other.CompareTag("Player"))
        {
            if (textoMensagem != null)
            {
                textoMensagem.gameObject.SetActive(false); // Oculta o texto
            }
            playerInsideTrigger = false; // Marca que o player saiu da �rea
        }
    }

    private void LoadScene()
    {
        // Carrega a cena "Casa"
        SceneManager.LoadScene(sceneToLoad);
    }
}
