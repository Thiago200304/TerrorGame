using UnityEngine;

public class DestroyOnSpace : MonoBehaviour
{
    void Update()
    {
        // Verifica se a tecla espa�o foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Destroi o GameObject ao qual o script est� anexado
            Destroy(gameObject);
        }
    }
}
