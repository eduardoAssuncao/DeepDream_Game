using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum status {normal, raiva, enfurecido};
public enum acoes {Inicial = 1, Normal, Raiva, Enfurecido, Morte};
public class Enemy : MonoBehaviour
{
    //public status humor;

    /*public float speed;
    public float stoppingDistance;
    public float retreatDistance;*/

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;

    public Transform shotPoint;

    /*----contador de tempo----*/
    public float count = 0.0f;
    //public float acao1 = 5.0f;

    /*----statusMode-----*/
    public acoes modo;

   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Projectile buffSpeed = projectile.GetComponent<Projectile>();//Buff no script do cuspeF, em sua velocidade.
        buffSpeed.speed = 10;
        timeBtwShots = startTimeBtwShots;
        modo = acoes.Inicial;
    }

    void Update()
    {
        count += Time.deltaTime;
        if (count >= 10)
        {
            modo = acoes.Normal;
        }

        if (modo == acoes.Normal)
        {
            AcaoNormaolRato();
        }

        if (count >= 20)
        {
            modo = acoes.Raiva;
        }

        if (modo == acoes.Raiva)
        {
            AcaoRaivaRato();
        }

        if (count >= 30)
        {
            modo = acoes.Enfurecido;
        }

        if (modo == acoes.Enfurecido)
        {
            AcaoEnfurecidoRato();
        }

        if (count >= 40)
        {
            modo = acoes.Morte;
        }

        if (modo == acoes.Morte)
        {
            AcaoMorteRato();
        }

        if (count >= 43)
        {
            //muudar para a cena de agradecimento.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
        }
        /*if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);    
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }*/


        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, shotPoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    /*--------BUFFS DO REI RATO------------*/
    void AcaoNormaolRato() 
    {
        this.transform.Rotate(0,0,10);
        startTimeBtwShots = 1.3f;
        
    }

    void AcaoRaivaRato()
    {
        this.transform.Rotate(0,0,-15);
        startTimeBtwShots = 1;
        PatrolReiRato buff = this.GetComponent<PatrolReiRato>();//Buff no script da patrulha do ReiRato.
        buff.speed = 25f;//Buff no rato.
        Projectile buffSpeed = projectile.GetComponent<Projectile>();//Buff no script do cuspeF, em sua velocidade.
        buffSpeed.speed = 15;//Buff na bullet.
    }

    void AcaoEnfurecidoRato()
    {
        this.transform.Rotate(0,0,20);
        startTimeBtwShots = 0.7f;
        PatrolReiRato buff = this.GetComponent<PatrolReiRato>();
        buff.startWaitTime = 0.1f;
        buff.speed = 30f;
        Projectile buffSpeed = projectile.GetComponent<Projectile>();//Buff no script do cuspeF, em sua velocidade.
        buffSpeed.speed = 20;
    }

    void AcaoMorteRato()
    {
        this.transform.Translate(-100,0,0);
        startTimeBtwShots = 50;
        //Destroy(this.gameObject);
    }
}
