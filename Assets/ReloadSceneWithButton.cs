using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneWithButton : MonoBehaviour
{
    // Nome da cena que ser� carregada
    public string sceneToLoad = "Casa Fora"; // Substitua pelo nome da cena que voc� quer carregar

    void Update()
    {
        // Verifica se a tecla 'E' foi pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Carrega a cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}