using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float moveAmount = 0.05f; // Distância da movimentação dos itens
    public float moveSpeed = 3f;     // Velocidade da movimentação (quanto maior, mais rápido)
    public Vector3 movementDirection = Vector3.forward; // Direção do movimento (para frente)

    private Transform[] childItems; // Armazena todos os filhos do GameObject
    private Vector3[] initialLocalPositions; // Posições iniciais dos itens filhos

    void Start()
    {
        // Obtenha todos os filhos do GameObject atual
        childItems = GetComponentsInChildren<Transform>();

        // Guardar as posições locais iniciais dos filhos
        initialLocalPositions = new Vector3[childItems.Length];
        for (int i = 0; i < childItems.Length; i++)
        {
            if (childItems[i] != transform) // Ignora o próprio GameObject
            {
                initialLocalPositions[i] = childItems[i].localPosition;
            }
        }
    }

    void Update()
    {
        // Aplique um efeito de leve movimentação nos itens de forma constante
        foreach (Transform child in childItems)
        {
            if (child != transform) // Ignora o próprio GameObject
            {
                // Aplique a movimentação usando uma função trigonométrica para criar um movimento natural
                float movement = Mathf.Sin(Time.time * moveSpeed) * moveAmount;

                // Mantenha a posição original e aplique o movimento no eixo de oscilação
                child.localPosition = new Vector3(initialLocalPositions[System.Array.IndexOf(childItems, child)].x,
                                                  initialLocalPositions[System.Array.IndexOf(childItems, child)].y,
                                                  initialLocalPositions[System.Array.IndexOf(childItems, child)].z + movement);
            }
        }
    }
}
