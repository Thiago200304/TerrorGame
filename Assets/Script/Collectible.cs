using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public float timer = 60f; // Timer inicial de 1 minuto
    public Vector3 spawnAreaMin; // Ponto mínimo para o spawn aleatório
    public Vector3 spawnAreaMax; // Ponto máximo para o spawn aleatório
    public Text timerText; // UI para exibir o timer
    public GameObject player; // O jogador que irá coletar o objeto

    private void Start()
    {
        UpdateTimerUI();
        StartCoroutine(TimerCountdown());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) // Verifica se o jogador entrou no Collider
        {
            timer += 30f; // Adiciona 30 segundos ao timer
            UpdateTimerUI();
            RespawnObject(); // Reposiciona o objeto em uma posição aleatória
        }
    }

    private void RespawnObject()
    {
        // Gera uma nova posição aleatória dentro dos limites definidos
        Vector3 newPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        transform.position = newPosition; // Reposiciona o objeto
    }

    private IEnumerator TimerCountdown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
            UpdateTimerUI();
        }

        // Se o timer acabar, exibe a mensagem de "Game Over"
        GameOver();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = "Tempo: " + timer.ToString("F0") + "s";
    }

    private void GameOver()
    {
        // Exemplo de ação ao perder o jogo: Desativa o jogador
        Debug.Log("Game Over! O tempo acabou.");
        player.SetActive(false);
    }
}
