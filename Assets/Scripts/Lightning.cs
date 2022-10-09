using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
   GameController m_gc;
    public float gravity;
    private Rigidbody2D rb;
    WhiteLine line;

    private void Start(){
        line = FindObjectOfType<WhiteLine>();
        m_gc = FindObjectOfType<GameController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    private void Update(){

    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player") ){
            line.SetLightningTime(3);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("DeathZone") ){
            Destroy(gameObject);
        }
    }
}
