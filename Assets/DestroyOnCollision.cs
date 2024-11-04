using JetBrains.Annotations;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject proxfita;
    public GameObject porta;
    public bool primeirafita;
    //public bool ultimafita;
    private void OnTriggerEnter(Collider other)
    {



        if (other.CompareTag("Player"))
        {


            if (primeirafita==true)
            {
                porta.SetActive(true);
                GameData.numerodefitas++;
                Destroy(gameObject);
            }

            else
            {
                proxfita.SetActive(true);
                GameData.numerodefitas++;
                Destroy(gameObject);
            }
         
        }
    }
}
