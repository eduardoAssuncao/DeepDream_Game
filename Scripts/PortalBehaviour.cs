using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalBehaviour : MonoBehaviour
{
    public bool podeEntrar = false;
    public GameObject portal2;
    public GameObject player;
    public GameObject textPressL;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void NextPorta()
    {
        if (/*Input.GetKeyDown(KeyCode.C) && */podeEntrar == true)
        {
            player.transform.position = portal2.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        podeEntrar = true;
        textPressL.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        podeEntrar = false;
        textPressL.SetActive(false);
    }
}
