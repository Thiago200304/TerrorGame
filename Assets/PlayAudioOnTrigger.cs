using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;  // O componente de áudio que será ativado

    // Este método é chamado quando outro objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Toca o áudio, caso não esteja tocando
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Desativa o objeto atual para evitar que o som seja tocado novamente
            gameObject.SetActive(false);
        }
    }
}
