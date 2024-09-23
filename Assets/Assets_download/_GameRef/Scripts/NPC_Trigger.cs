using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC_Trigger : MonoBehaviour
{
    [TextArea(5, 5)]
    public string meuTexto;

    private GameObject gameCanvas;
    private GameObject NPCanvasText;
    private string npcTextToShow;

    private void Start()
    {
        gameCanvas = GameObject.Find("Canvas");
        NPCanvasText = gameCanvas.transform.GetChild(0).transform.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            npcTextToShow = meuTexto;
            NPCanvasText.GetComponent<TextMeshProUGUI>().text = npcTextToShow;
            NPCanvasText.SetActive(true);

        }

    }


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            NPCanvasText.SetActive(false);

        }



    }




}
