using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Mathematics;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject DamageEffect;
    public Transform []Gunpoint;
   
    public GameObject Enemybullet;
    public float GunShoottime=0.5f;
    public GameObject Enemyflash;

    public float speed =0.1f;
    public GameObject EnemyexplosionPrefeb;
    public HealthBar HealthBar;
    public float Health = 10f;

    float Barsize=1f;
    float damage;
    public AudioClip BullletSound;
    public AudioClip DamageSound;
    public AudioClip ExplosionSound;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Enemyflash.SetActive(false);
        StartCoroutine(shoot());
        damage = Barsize/Health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*speed *Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag=="PlayerBullet")
         {
            audioSource.PlayOneShot(DamageSound,0.5f);
            damagehelthbar();
            Destroy(collision.gameObject);
            GameObject damageVfx=Instantiate(DamageEffect,collision.transform.position,Quaternion.identity);
            Destroy(damageVfx,0.04f);
            
            if(Health<=0)
            {
                AudioSource.PlayClipAtPoint(ExplosionSound,Camera.main.transform.position,0.5f);
                Instantiate(coinPrefabs,transform.position,Quaternion.identity);
                Destroy(gameObject);  
                GameObject Enemyexplosion=Instantiate(EnemyexplosionPrefeb,transform.position,Quaternion.identity);
                Destroy(Enemyexplosion,0.4f);
            }
         
        }
    }
    void damagehelthbar()
    {
        if (Health>0)
        {
           Health-=1;
            Barsize= Barsize-damage;
            HealthBar.setsize(Barsize);

        }
    }

     
    void fire()
    {
        for(int i=0; i<Gunpoint.Length;i++)
        {
            Instantiate(Enemybullet,Gunpoint[i].position,Quaternion.identity);
        }
        //Instantiate(Enemybullet,Gunpoint1.position,Quaternion.identity);
        //Instantiate(Enemybullet,Gunpoint2.position,Quaternion.identity);
    }
    IEnumerator shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(GunShoottime);
            fire();
            audioSource.Play();
            Enemyflash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            Enemyflash.SetActive(false);
        }
    }

}
