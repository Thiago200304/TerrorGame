using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugTest : MonoBehaviour
{

    public GameObject soundMy;
    private string debugText = "";
    private GUIStyle guiStyle = new GUIStyle();

    void Start()
    {
        // Configuração inicial para o estilo do texto na tela
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            soundMy.GetComponent<AudioSource>().Play();

        }

        // Captura os valores dos eixos
        float axis4 = Input.GetAxis("Mouse X"); // ou o nome exato do eixo configurado no Input Manager
        float axis5 = Input.GetAxis("Mouse Y"); // ou o nome exato do eixo configurado no Input Manager

        // Atualiza o texto de debug com os valores capturados
        debugText = $"Axis 4: {axis4}\nAxis 5: {axis5}";
    }

    void OnGUI()
    {
        // Exibe o texto de debug na tela
        GUI.Label(new Rect(10, 10, 500, 200), debugText, guiStyle);
    }
}
