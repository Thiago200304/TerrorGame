using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource audioSource;  // Referência ao AudioSource
    public AudioClip clip;          // O áudio a ser tocado

    private bool hasPlayed = false;  // Variável para verificar se o áudio já foi tocado

    // Quando o jogador entrar no trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
        if (other.CompareTag("Player") && !hasPlayed)
        {
            if (audioSource != null && clip != null)
            {
                audioSource.clip = clip;  // Atribui o áudio ao AudioSource
                audioSource.Play();       // Toca o áudio

                hasPlayed = true;         // Marca que o áudio foi tocado
                Destroy(gameObject, clip.length); // Destroi o objeto após a duração do áudio
            }
        }
    }
}
