using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    GameController m_gc;
    public float gravity;
    private Rigidbody2D rb;

    private void Start(){
        m_gc = FindObjectOfType<GameController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    private void Update(){

    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player") ){
            m_gc.IncrementScore(100);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("DeathZone") ){
            m_gc.SetGameOverState(true);
            Destroy(gameObject);
        }
    }
}
