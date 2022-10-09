using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject money;
    public GameObject gold;
    public GameObject jewel;
    public GameObject poison;
    public GameObject lightning;
    public float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;
    float lvSize = 1;
    float lvSpeed = 1;
    float scaleSize = 1;
    float scaleSpeed = 7;
    int requiredSizeScore = 30;
    int requiredSpeedScore = 30;
    int count = 0;
    string codeAdd100 = "HappyNewYear";
    string codeAdd1000 = "Vole1000@0909";
    string codeAdd10000 = "10000$";
    string codeAdd100000 = "hack$";
    int[] roundRequired = {5,12,20,30};
    UIManager m_ui;
    WhiteLine line;


    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: "+m_score);
        line = FindObjectOfType<WhiteLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(count%10==0){
            spawnTime = spawnTime*0.96f;
            count++;
        }
        if(count<=roundRequired[0]){
        }
        else if(count>=roundRequired[0]&&count<=roundRequired[1]){
            m_ui.SetRoundText("Round 2");
            Color color = new Color(0,130,0);
            m_ui.SetColorRoundText(color);
        }
        else if(count<=roundRequired[2]){
            m_ui.SetRoundText("Round 3");
            Color color = new Color(0,0,150);
            m_ui.SetColorRoundText(color);
        }
        else if(count<=roundRequired[3]){
            m_ui.SetRoundText("Round 4");
            Color color = new Color(55,0,75);
            m_ui.SetColorRoundText(color);
        }
        else{
            m_ui.SetRoundText("Round 5");
            Color color = new Color(255,125,0);
            m_ui.SetColorRoundText(color);
        }

        m_spawnTime = m_spawnTime - Time.deltaTime;

        if(m_isGameOver){
            m_spawnTime = 0;
            spawnTime = 3;
            m_ui.SetRoundText(" ");
            m_ui.ShowGameOverPanel(true);
            if(m_score>=requiredSizeScore){
                m_ui.ShowButtonUpdateSize(true);
            }
            else{
                m_ui.ShowButtonUpdateSize(false);
            }
            if(m_score>=requiredSpeedScore){
                m_ui.ShowButtonSpeedSize(true);
            }
            else{
                m_ui.ShowButtonSpeedSize(false);
            }
            return;
        }

        if(m_spawnTime<=0){
            SpawnRandom(0);
            if(count>=50){
                SpawnRandom(7);
            }
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnRandom(int dist){
        int rdSpawn = Random.Range(0,11);
        if(count<=roundRequired[0]){
            if(rdSpawn<=6){
                SpawnBall(dist);
            }
            else if(rdSpawn<=9){
                SpawnMoney(dist);
            }
            else{
                SpawnLightning(dist);
            }
        }
        else if(count<=roundRequired[1]){
            if(rdSpawn<=4){
                SpawnBall(dist);
            }
            else if(rdSpawn<=7){
                SpawnMoney(dist);
            }
            else if(rdSpawn<=9){
                SpawnGold(dist);
            }
            else{
                SpawnLightning(dist);
            }
        }
        else if(count<=roundRequired[2]){
            if(rdSpawn<=2){
                SpawnBall(dist);
            }
            else if(rdSpawn<=5){
                SpawnMoney(dist);
            }
            else if(rdSpawn<=7){
                SpawnGold(dist);
            }
            else if(rdSpawn<=9){
                SpawnJewel(dist);
            }
            else{
                SpawnLightning(dist);
            }
        }
        else{
            if(rdSpawn<=1){
                SpawnBall(dist);
            }
            else if(rdSpawn<=3){
                SpawnMoney(dist);
            }
            else if(rdSpawn<=5){
                SpawnGold(dist);
            }
            else if(rdSpawn<=7){
                SpawnJewel(dist);
            }
            else if(rdSpawn<=9){
                SpawnPoison(dist);
            }
            else{
                SpawnLightning(dist);
            }
        }
        
    }

    public void SpawnBall(int dist){
        Vector2 spawnPos = new Vector2(Random.Range(-8,8),6+dist);
        if(ball){
            Instantiate(ball,spawnPos, Quaternion.identity);
            count++;
        }
    }

    public void SpawnJewel(int dist){
        Vector2 spawnPos = new Vector2(Random.Range(-8,8),6+dist);
        if(jewel){
            Instantiate(jewel,spawnPos, Quaternion.identity);
            count++;
        }
    }

    public void SpawnMoney(int dist){
        Vector2 spawnPos = new Vector2(Random.Range(-8,8),6+dist);
        if(money){
            Instantiate(money,spawnPos, Quaternion.identity);
            count++;
        }
    }

    public void SpawnGold(int dist){
        Vector2 spawnPos = new Vector2(Random.Range(-8,8),6+dist);
        if(gold){
            Instantiate(gold,spawnPos, Quaternion.identity);
            count++;
        }
    }

    public void SpawnPoison(int dist){
        Vector2 spawnPos = new Vector2(Random.Range(-8,8),6+dist);
        if(poison){
            Instantiate(poison,spawnPos, Quaternion.identity);
            count++;
        }
    }

    public void SpawnLightning(int dist){
        Vector2 spawnPos = new Vector2(Random.Range(-8,8),6+dist);
        if(lightning){
            Instantiate(lightning,spawnPos, Quaternion.identity);
            count++;
        }
    }

    public void SetScore(int val){
        m_score = val;
    }

    public int GetScore(){
        return m_score;
    }

    public void IncrementScore(int inc){
        m_score+=inc;
        m_ui.SetScoreText("Score: "+m_score);
    }

    public bool IsGameOver(){
        return m_isGameOver;
    }

    public void SetGameOverState(bool state){
        m_isGameOver = state;
    }

    public void Replay(){
        m_isGameOver = false;
        count = 0;
        m_ui.SetScoreText("Score: "+m_score);
        m_ui.ShowGameOverPanel(false);
        m_ui.SetRoundText("Round 1");
        m_ui.SetColorRoundText(Color.white);
    }

    public void updateSize(){
        if(m_score > requiredSizeScore){
            m_score-= (int)(requiredSizeScore);
            requiredSizeScore = (int)(requiredSizeScore*1.5f);
            lvSize++;
            scaleSize+=0.1f;
            line.SetSize(scaleSize);
            if(lvSize==21){
                requiredSizeScore = 99999999;
                m_ui.SetDescribeSizeText("Đã đạt giới hạn kích thước");
            }
            else{
                m_ui.SetLevelSizeText("Lv. "+lvSize);
                m_ui.SetDescribeSizeText("Tăng kích thước thanh đẩy "+requiredSizeScore+"đ");
            }
            m_ui.SetScoreText("Score: "+m_score);
        }
    }

    public void updateSpeed(){
        if(m_score > requiredSpeedScore){
            m_score-= (int)(requiredSpeedScore);
            requiredSpeedScore = (int)(requiredSpeedScore*1.5f);
            lvSpeed++;
            scaleSpeed+=0.75f;
            line.SetSpeed(scaleSpeed);
            if(lvSpeed==21){
                requiredSpeedScore = 99999999;
                m_ui.SetDescribeSpeedText("Đã đạt giới hạn kích thước");
            }
            else{
                m_ui.SetLevelSpeedText("Lv. "+lvSpeed);
                m_ui.SetDescribeSpeedText("Tăng kích thước thanh đẩy "+requiredSpeedScore+"đ");
            }
            m_ui.SetScoreText("Score: "+m_score);
        }
    }

    public void SubmitGiftCode(){
        if(m_ui.GetGiftInput().Equals(codeAdd100000)){
            m_score+=100000;
            m_ui.SetScoreText("Score: "+m_score);
        }
        else if(m_ui.GetGiftInput().Equals(codeAdd100)){
            m_score+=100;
            m_ui.SetScoreText("Score: "+m_score);
        }
        else if(m_ui.GetGiftInput().Equals(codeAdd1000)){
            m_score+=1000;
            m_ui.SetScoreText("Score: "+m_score);
        }
        else if(m_ui.GetGiftInput().Equals(codeAdd10000)){
            m_score+=10000;
            m_ui.SetScoreText("Score: "+m_score);
        }

        m_ui.SetGiftInput("");
    }
}
