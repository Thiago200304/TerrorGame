using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight;           // Referência à Spot Light da lanterna
    public Slider batterySlider;       // Referência à barra de energia da lanterna (UI Slider)
    public AudioSource flashlightAudio; // Referência ao AudioSource para tocar o som
    public AudioClip toggleSound;      // O som que será tocado ao ligar/desligar a lanterna
    public float batteryLife = 30f;    // Duração da bateria em segundos (30 segundos)
    private float currentBatteryLife;
    private bool isOn = false;         // Estado da lanterna (ligada/desligada)
    private bool isRecharging = false; // Verifica se está recarregando devido ao esgotamento total
    private Image sliderFill;          // Componente de cor da barra de bateria

    private void Start()
    {
        currentBatteryLife = batteryLife;   // Inicia a bateria com carga total
        batterySlider.maxValue = batteryLife;
        batterySlider.value = currentBatteryLife;
        sliderFill = batterySlider.fillRect.GetComponent<Image>();
        UpdateSliderColor();
        flashlight.enabled = isOn;
    }

    private void Update()
    {
        // Liga/desliga a lanterna com a tecla "F"
        if (Input.GetKeyDown(KeyCode.F) && !isRecharging)
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
            PlayToggleSound(); // Toca o som ao alternar o estado da lanterna
        }

        // Descarrega ou recarrega a bateria dependendo do estado da lanterna
        if (isOn)
        {
            if (currentBatteryLife > 0)
            {
                currentBatteryLife -= Time.deltaTime;
                UpdateSliderColor();
            }
            else
            {
                StartCoroutine(HandleBatteryDepletion());
            }
        }
        else
        {
            if (currentBatteryLife < batteryLife)
            {
                currentBatteryLife += Time.deltaTime;
                UpdateSliderColor();
            }
        }

        // Atualiza o valor da barra de bateria
        batterySlider.value = currentBatteryLife;
    }

    // Corrotina que lida com a lanterna ao atingir carga zero
    private IEnumerator HandleBatteryDepletion()
    {
        isOn = false;
        flashlight.enabled = false;
        isRecharging = true;
        sliderFill.color = new Color32(67, 0, 0, 255);  // Vermelho escuro (#430000) quando a bateria acaba

        yield return new WaitForSeconds(15f); // Espera 15 segundos para recarregar

        isRecharging = false;
        UpdateSliderColor(); // Atualiza a cor quando a recarga começa
    }

    // Atualiza a cor do slider de acordo com o estado da bateria e lanterna
    private void UpdateSliderColor()
    {
        if (isRecharging)
        {
            sliderFill.color = new Color32(67, 0, 0, 255); // Vermelho escuro (#430000) enquanto recarrega devido ao esgotamento completo
        }
        else if (!isOn)
        {
            sliderFill.color = Color.white; // Branco enquanto recarrega normalmente
        }
        else
        {
            sliderFill.color = Color.yellow; // Amarelo enquanto a lanterna está ligada
        }
    }

    // Toca o som ao alternar o estado da lanterna
    private void PlayToggleSound()
    {
        if (flashlightAudio != null && toggleSound != null)
        {
            flashlightAudio.PlayOneShot(toggleSound);
        }
    }
}
