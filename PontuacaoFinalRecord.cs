using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuacaoFinalRecord : MonoBehaviour
{
    public Text recorde;

    // Start is called before the first frame update
    void Start()
    {
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
