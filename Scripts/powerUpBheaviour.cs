using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpBheaviour : MonoBehaviour
{
    public GameObject itemPowerUp;
    public GameObject powerUpEv;
    public GameObject player;
    public GameObject ativarCamera;
    public bool podeDestruir;


    public void ColetarPowerUp()
    {
        if (/*Input.GetKeyDown(KeyCode.X) && */podeDestruir == true)
        {
            Destroy(itemPowerUp.gameObject);
            Destroy(player.gameObject);
            powerUpEv.gameObject.SetActive(true);
            ativarCamera.gameObject.SetActive(true);
            //Instantiate(powerUpEv.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            podeDestruir = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            podeDestruir = false;
        }
    }
}
