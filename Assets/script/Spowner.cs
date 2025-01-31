using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    public GameObject[]enemy;
    public float respwonTime=2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpwaner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpwaner()
    {
        while(true)
        {
         yield return new WaitForSeconds(respwonTime);
         SpwanEnemy();

        }
      
    }
    void SpwanEnemy()
    {
        int randomValue=Random.Range(0,enemy.Length);
        int randomXpos=Random.Range(-2,2);
        Instantiate(enemy[randomValue],new Vector2(randomXpos,transform.position.y),Quaternion.identity);
    }
}
