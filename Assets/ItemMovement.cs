using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float moveAmount = 0.05f; // Dist�ncia da movimenta��o dos itens
    public float moveSpeed = 3f;     // Velocidade da movimenta��o (quanto maior, mais r�pido)
    public Vector3 movementDirection = Vector3.forward; // Dire��o do movimento (para frente)

    private Transform[] childItems; // Armazena todos os filhos do GameObject
    private Vector3[] initialLocalPositions; // Posi��es iniciais dos itens filhos

    void Start()
    {
        // Obtenha todos os filhos do GameObject atual
        childItems = GetComponentsInChildren<Transform>();

        // Guardar as posi��es locais iniciais dos filhos
        initialLocalPositions = new Vector3[childItems.Length];
        for (int i = 0; i < childItems.Length; i++)
        {
            if (childItems[i] != transform) // Ignora o pr�prio GameObject
            {
                initialLocalPositions[i] = childItems[i].localPosition;
            }
        }
    }

    void Update()
    {
        // Aplique um efeito de leve movimenta��o nos itens de forma constante
        foreach (Transform child in childItems)
        {
            if (child != transform) // Ignora o pr�prio GameObject
            {
                // Aplique a movimenta��o usando uma fun��o trigonom�trica para criar um movimento natural
                float movement = Mathf.Sin(Time.time * moveSpeed) * moveAmount;

                // Mantenha a posi��o original e aplique o movimento no eixo de oscila��o
                child.localPosition = new Vector3(initialLocalPositions[System.Array.IndexOf(childItems, child)].x,
                                                  initialLocalPositions[System.Array.IndexOf(childItems, child)].y,
                                                  initialLocalPositions[System.Array.IndexOf(childItems, child)].z + movement);
            }
        }
    }
}
