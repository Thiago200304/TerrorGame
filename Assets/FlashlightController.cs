using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight; // Arraste a Spot Light para este campo no Inspector
    private bool isOn = true; // Define se a lanterna está ligada ou desligada

    void Update()
    {
        // Pressionar "F" alterna a lanterna
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            flashlight.enabled = isOn; // Habilita/desabilita a luz
        }
    }
}
