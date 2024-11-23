using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource audioSource;  // Refer�ncia ao AudioSource
    public AudioClip clip;          // O �udio a ser tocado

    private bool hasPlayed = false;  // Vari�vel para verificar se o �udio j� foi tocado

    // Quando o jogador entrar no trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger � o jogador
        if (other.CompareTag("Player") && !hasPlayed)
        {
            if (audioSource != null && clip != null)
            {
                audioSource.clip = clip;  // Atribui o �udio ao AudioSource
                audioSource.Play();       // Toca o �udio

                hasPlayed = true;         // Marca que o �udio foi tocado
                Destroy(gameObject, clip.length); // Destroi o objeto ap�s a dura��o do �udio
            }
        }
    }
}
