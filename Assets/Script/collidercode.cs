using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidercode : MonoBehaviour
{
    // Referência ao objeto que terá o MeshRenderer ativado/desativado
    private MeshRenderer targetMeshRenderer;

    // Tag do objeto que queremos controlar o MeshRenderer
    public string targetTag = "Alvo";

    // Nome da cena que será carregada (atualizado para "Casa")
    public string sceneToLoad = "Casa";

    private bool playerInsideTrigger = false;

    private void Start()
    {
        // Procurando o objeto pela tag e pegando seu MeshRenderer
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        if (targetObject != null)
        {
            targetMeshRenderer = targetObject.GetComponent<MeshRenderer>();
        }
        else
        {
            Debug.LogError("Nenhum objeto encontrado com a tag: " + targetTag);
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
            if (targetMeshRenderer != null)
            {
                targetMeshRenderer.enabled = true; // Liga o MeshRenderer
            }
            playerInsideTrigger = true; // Marca que o player está dentro da área
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Quando o objeto sai da área de colisão
        if (other.CompareTag("Player"))
        {
            if (targetMeshRenderer != null)
            {
                targetMeshRenderer.enabled = false; // Desliga o MeshRenderer
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
