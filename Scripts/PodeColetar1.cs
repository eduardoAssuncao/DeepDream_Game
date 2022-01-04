using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PodeColetar1 : MonoBehaviour
{
    //Coleta de itens;
    public bool podeDestruir;

    //Pontos
    public Text scoreText;
    private int score = 0;
    public GameObject textColete;

    private PlayerMovement player1;

    void Start()
    {
        player1 = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;//Procura um objeto e o retona nesse script;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        podeDestruir = true;
        textColete.SetActive(true);
        Debug.Log(podeDestruir);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        podeDestruir = false;
        textColete.SetActive(false);
        Debug.Log(podeDestruir);
    }

    // Update is called once per frame
    public void CotetarItem()
    {
        scoreText.text = scoreText.text.ToString();
        if (/*Input.GetKeyDown(KeyCode.Z) && */podeDestruir == true)
        {
            Destroy(gameObject);
            player1.addscore();//Acessar o objeto criado no script PodeColetar(score++)
            scoreText.text = "  " + player1.score;
            Debug.Log(player1.score);
            //score = score + 10;
            //score++;
        }
    }
}
