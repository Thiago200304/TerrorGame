using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject scareImage;

    public bool scareActiveted;


    IEnumerator jumpScareAction()
    {

        scareActiveted = true;
        scareImage.SetActive(true);
        yield return new WaitForSeconds(3);
        scareImage.SetActive(false);
        scareActiveted = false;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && scareActiveted == false)
        {

            StartCoroutine(jumpScareAction());

        }

    }
}
