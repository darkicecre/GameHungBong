using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteLine : MonoBehaviour
{
    public float moveSpeed;
    public float Size;
    float xDir;
    float poisonTime = 0;
    float lightningTime = 0;
    SpriteRenderer m_rd;

    // Start is called before the first frame update
    void Start()
    {
        m_rd = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
       
        if(poisonTime>0){
            float moveStep = moveSpeed*xDir*Time.deltaTime;
            if(transform.position.x <= -8.5f + Size && xDir>0 || transform.position.x >= 8.5f - Size && xDir < 0){
                return; 
            }
            m_rd.color = new Color(0,60,0);
            transform.position = transform.position - new Vector3(moveStep,0,0);
            poisonTime-=Time.deltaTime;
        }
        else if(lightningTime>0){
            float moveStep = moveSpeed*xDir*Time.deltaTime*2f;
            if(transform.position.x <= -8.5f + Size && xDir<0 || transform.position.x >= 8.5f - Size && xDir > 0){
                return; 
            }
            m_rd.color = new Color(205,205,0);
            transform.position = transform.position + new Vector3(moveStep,0,0);
            lightningTime-=Time.deltaTime;
        }
        else{
            float moveStep = moveSpeed*xDir*Time.deltaTime;
            if(transform.position.x <= -8.5f + Size && xDir<0 || transform.position.x >= 8.5f - Size && xDir > 0){
                return; 
            }
            m_rd.color = Color.white;
            transform.position = transform.position + new Vector3(moveStep,0,0);
        }
    }



    public void SetSize(float size){
        Size = size;
        transform.localScale = new Vector3(0.6f*Size,0.06f,0);
    }

    public void SetSpeed(float speed){
        moveSpeed = speed;
    }

    public void SetPoisonTime(float time){
        poisonTime = time;
    }

    public void SetLightningTime(float time){
        lightningTime = time;
    }
}
