using JetBrains.Annotations;
using TMPro; // Para usar TextMeshPro
using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject proxfita;
    public GameObject porta;
    public bool primeirafita;
    public TextMeshProUGUI mensagemTexto; // Refer�ncia para o objeto de texto
    public float duracaoMensagem = 5f; // Dura��o que a mensagem ficar� vis�vel


public string texto1;
public string texto2;


public int ID;

public bool fitacoletada;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (primeirafita)
            {
                porta.SetActive(true);
                GameData.numerodefitas++;

                // Exibe a mensagem "entre na casa"
                mensagemTexto.text = "ENTRE NA CASA";
                mensagemTexto.gameObject.SetActive(true);

                // Inicia a corrotina para ocultar a mensagem ap�s a dura��o configurada
                StartCoroutine(OcultarMensagem());

                Destroy(gameObject);
            }
            else
            {
                proxfita.SetActive(true);
                GameData.numerodefitas++;
              
              //mostrar menu
              //atualizar o texto do menu

//if(ID==1){
    //texto 1
//}

              // parar o player

              fitacoletada=true;
          
           
          
            }
        }
    }


void Update(){

if (fitacoletada==true&&Input.GetMouseButtonDown(0)){

//fecha menu
//ativa o player

 Destroy(gameObject);

}

    private IEnumerator OcultarMensagem()
    {
        yield return new WaitForSeconds(duracaoMensagem);
        mensagemTexto.gameObject.SetActive(false);
    }
}
