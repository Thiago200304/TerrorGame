using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;  // O componente de �udio que ser� ativado

    // Este m�todo � chamado quando outro objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Toca o �udio, caso n�o esteja tocando
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Desativa o objeto atual para evitar que o som seja tocado novamente
            gameObject.SetActive(false);
        }
    }
}
