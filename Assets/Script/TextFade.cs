using UnityEngine;
using TMPro; // Certifique-se de incluir o namespace do TMP

public class TextFade : MonoBehaviour
{
    public TextMeshProUGUI tmpText; // Referência ao TextMeshProUGUI
    public float fadeDuration = 1f; // Duração da animação de fade
    private bool isFadingIn = true; // Controla se está desvanecendo ou aparecendo
    private float fadeTimer;

    void Start()
    {
        if (tmpText != null)
        {
            Color textColor = tmpText.color;
            textColor.a = 0; // Inicialmente invisível
            tmpText.color = textColor;
        }

        fadeTimer = fadeDuration;
    }

    void Update()
    {
        if (tmpText != null)
        {
            FadeText();
        }
    }

    void FadeText()
    {
        fadeTimer -= Time.deltaTime;

        if (fadeTimer <= 0)
        {
            isFadingIn = !isFadingIn; // Inverte a direção do fade
            fadeTimer = fadeDuration; // Reseta o tempo
        }

        // Calcula a nova opacidade com base na interpolação linear
        float alpha = isFadingIn ? Mathf.Lerp(0, 1, 1 - (fadeTimer / fadeDuration)) : Mathf.Lerp(1, 0, 1 - (fadeTimer / fadeDuration));

        Color textColor = tmpText.color;
        textColor.a = alpha; // Aplica a nova opacidade ao TMP
        tmpText.color = textColor;
    }
}
