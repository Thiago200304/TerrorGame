using UnityEngine;
using System.Collections;

public class MoveCubeOnTrigger : MonoBehaviour
{
    public GameObject cubeToMove;    // O cubo que será movido
    public Transform newPosition;    // A nova posição para onde o cubo será movido
    public float moveDuration = 2f;  // Duração do movimento em segundos

    private bool isMoving = false;   // Controle para evitar iniciar o movimento múltiplas vezes

    // Este método é chamado quando outro objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            StartCoroutine(MoveCube());
        }
    }

    // Corrotina para mover o cubo suavemente até a nova posição
    private IEnumerator MoveCube()
    {
        isMoving = true;
        Vector3 startPosition = cubeToMove.transform.position;
        Vector3 targetPosition = newPosition.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            cubeToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera até o próximo frame
        }

        // Assegura que o cubo esteja exatamente na posição final ao término da animação
        cubeToMove.transform.position = targetPosition;
        isMoving = false;
    }
}
