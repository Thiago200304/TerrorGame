using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAcelerometer : MonoBehaviour
{


    public float rotationSpeed = 2.0f; // Velocidade da rotação
    public float maxVerticalAngle = 80f; // Ângulo máximo de rotação vertical

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    void Start()
    {
        // Inicializa a rotação com a rotação atual da câmera
        _rotationX = transform.eulerAngles.y;
        _rotationY = transform.eulerAngles.x;
    }

    void Update()
    {
        // Ler os valores do acelerômetro
        Vector3 acceleration = Input.acceleration;

        // Mapear a inclinação do celular para a rotação da câmera
        _rotationX += acceleration.x * rotationSpeed;
        _rotationY -= acceleration.y * rotationSpeed;

        // Limitar a rotação vertical para não passar de um certo ângulo
        _rotationY = Mathf.Clamp(_rotationY, -maxVerticalAngle, maxVerticalAngle);

        // Aplicar a rotação à câmera
        transform.rotation = Quaternion.Euler(_rotationY, _rotationX, 0f);
    }
}
