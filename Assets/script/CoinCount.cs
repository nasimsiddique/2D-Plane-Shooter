using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    public TMP_Text coincountText;
    public GameController gameController;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Addcount()
    {
        count++;
         coincountText.text= count.ToString();
         gameController.updateHighScore(count);
    }
}
