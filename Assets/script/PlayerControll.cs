using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControll : MonoBehaviour
{
    public GameObject Explosion;
    public HealthBar HealthBar;
    public CoinCount coinCountscript;
    public GameController gameController;
    public float Health=10f;
    public float speed=1f;
     float minX;
     float maxX;
    float minY;
    float maxY;
    public float padding=0.8f;
    float damage;
    float Barsize=1f;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
        damage= Barsize/Health;
    }
    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x+padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x-padding;
        
        minY= gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y+padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y-padding;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetMouseButton(0))
        {
            Vector2 newpos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            transform.position=Vector2.Lerp(transform.position,newpos,10*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag=="EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound,0.5f);
         damagehelthbar();
         Destroy(collision.gameObject);
         if(Health<=0)
         {
            AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position,0.5f);
            gameController.GameOver();
            Destroy(gameObject);
            
            GameObject Enemyexplosion=Instantiate(Explosion,transform.position,Quaternion.identity);
            Destroy(Enemyexplosion,0.4f);
         }
        
        }
        if(collision.gameObject.tag=="coin")
        {
            audioSource.PlayOneShot(coinSound,0.5f);
            Destroy(collision.gameObject);
            coinCountscript.Addcount();
        }



      
       
    }
    void damagehelthbar()
    {
       if(Health>0)
       {
        Health-=1;
        Barsize-=damage;
        HealthBar.setsize(Barsize);
       }
    }
}
