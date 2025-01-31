using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform SpwamPointR;
    public Transform SpwamPointL;
    public float bulletSpwantime=0.5f;
    public GameObject Flash;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
       Flash.SetActive(false);
        StartCoroutine( shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void fire()
    {
         Instantiate(playerBullet,SpwamPointR.position,Quaternion.identity);
         Instantiate(playerBullet,SpwamPointL.position,Quaternion.identity);

    }
   
    IEnumerator shoot()
    {
        while(true)
      { 
         yield return new WaitForSeconds(bulletSpwantime);
         fire();
         audioSource.Play();
         Flash.SetActive(true);
         yield return new WaitForSeconds(0.04f);
         Flash.SetActive(false);
        
      }
    }
}
