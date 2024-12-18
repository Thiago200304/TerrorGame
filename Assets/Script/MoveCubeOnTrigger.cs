using UnityEngine;
using System.Collections;

public class MoveCubeOnTrigger : MonoBehaviour
{
    public GameObject cubeToMove;    // O cubo que ser� movido
    public Transform newPosition;    // A nova posi��o para onde o cubo ser� movido
    public float moveDuration = 2f;  // Dura��o do movimento em segundos
    public AudioSource audioSource;  // O componente de �udio que ser� ativado

    private bool isMoving = false;   // Controle para evitar iniciar o movimento m�ltiplas vezes

    // Este m�todo � chamado quando outro objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            StartCoroutine(MoveCube());
        }
    }

    // Corrotina para mover o cubo suavemente at� a nova posi��o
    private IEnumerator MoveCube()
    {
        isMoving = true;

        // Toca o �udio, caso n�o esteja tocando
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        Vector3 startPosition = cubeToMove.transform.position;
        Vector3 targetPosition = newPosition.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            cubeToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera at� o pr�ximo frame
        }

        // Assegura que o cubo esteja exatamente na posi��o final ao t�rmino da anima��o
        cubeToMove.transform.position = targetPosition;

        // Desativa o objeto atual para evitar que o som ou movimento aconte�a novamente
        gameObject.SetActive(false);

        isMoving = false;
    }
}
