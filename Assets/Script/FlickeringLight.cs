using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light pointLight;   // Arraste a Point Light para este campo no Inspector
    public float minTime = 0.1f;  // Tempo m�nimo entre piscadas
    public float maxTime = 0.5f;  // Tempo m�ximo entre piscadas
    public float minIntensity = 0f;  // Intensidade m�nima da luz (0 = apagada)
    public float maxIntensity = 2f;  // Intensidade m�xima da luz

    private float timer;

    void Start()
    {
        timer = Random.Range(minTime, maxTime); // Definir o tempo inicial para a primeira piscada
    }

    void Update()
    {
        timer -= Time.deltaTime; // Subtrai o tempo a cada frame

        if (timer <= 0)
        {
            // Alterna a intensidade da luz para simular piscadas
            pointLight.intensity = Random.Range(minIntensity, maxIntensity);

            // Redefine o timer para uma nova piscada
            timer = Random.Range(minTime, maxTime);
        }
    }
}
