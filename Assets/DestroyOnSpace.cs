using UnityEngine;

public class DestroyOnSpace : MonoBehaviour
{
    void Update()
    {
        // Verifica se a tecla espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Destroi o GameObject ao qual o script está anexado
            Destroy(gameObject);
        }
    }
}
