using UnityEngine;
using UnityEngine.UI;

public class SceneFadeIn : MonoBehaviour
{
    public Image fadeImage; // Imagem que ser� usada para o fade
    public float fadeDuration = 1f; // Dura��o do fade in

    private float fadeTimer;
    private Color imageColor;

    void Start()
    {
        if (fadeImage != null)
        {
            imageColor = fadeImage.color;
            imageColor.a = 1; // Come�a com a tela completamente preta
            fadeImage.color = imageColor;

            fadeTimer = fadeDuration; // Define o tempo do fade
        }
    }

    void Update()
    {
        if (fadeImage != null && fadeTimer > 0)
        {
            fadeTimer -= Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, 1 - (fadeTimer / fadeDuration)); // Interpola��o para diminuir o alpha

            imageColor.a = alpha;
            fadeImage.color = imageColor;

            // Quando o fade termina, desativar a imagem
            if (fadeTimer <= 0)
            {
                fadeImage.gameObject.SetActive(false); // Desativa o objeto para liberar recursos
            }
        }
    }
}
