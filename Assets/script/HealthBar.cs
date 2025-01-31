using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform Bar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setsize(float Size)
    {
        Bar.localScale = new Vector2(Size ,1f);
    } 
    
}
