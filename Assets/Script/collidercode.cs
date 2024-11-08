using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidercode : MonoBehaviour
{
    // Referência ao objeto que exibirá o texto
    public TextMeshProUGUI textoMensagem;

    // Nome da cena que será carregada (atualizado para "Casa")
    public string sceneToLoad = "Casa";

    private bool playerInsideTrigger = false;

    private void Start()
    {
        // Verifica se o texto está configurado, se não, exibe uma mensagem de erro
        if (textoMensagem == null)
        {
            Debug.LogError("Referência para o TextMeshProUGUI não atribuída.");
        }
        else
        {
            textoMensagem.gameObject.SetActive(false); // Desativa o texto no início
        }
    }

    private void Update()
    {
        // Verifica se o jogador está dentro do trigger e se a tecla E foi pressionada
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene(); // Carrega a cena quando a tecla "E" for pressionada
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Quando colidir com um objeto que tem a tag Player (ou qualquer tag que você defina)
        if (other.CompareTag("Player"))
        {
            if (textoMensagem != null)
            {
                textoMensagem.gameObject.SetActive(true); // Exibe o texto
            }
            playerInsideTrigger = true; // Marca que o player está dentro da área
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Quando o objeto sai da área de colisão
        if (other.CompareTag("Player"))
        {
            if (textoMensagem != null)
            {
                textoMensagem.gameObject.SetActive(false); // Oculta o texto
            }
            playerInsideTrigger = false; // Marca que o player saiu da área
        }
    }

    private void LoadScene()
    {
        // Carrega a cena "Casa"
        SceneManager.LoadScene(sceneToLoad);
    }
}
