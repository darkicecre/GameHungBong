using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text lvSize;
    public Text lvSpeed;
    public Text describeSize;
    public Text describeSpeed;
    public Text roundText;
    public Button updateSize;
    public Button updateSpeed;
    public InputField giftInput;

    public GameObject GameOverPanel;

    public string GetGiftInput(){
        return giftInput.text;
    }

    public void SetGiftInput(string txt){
        giftInput.text = txt;
    }

    public void SetDescribeSizeText(string txt){
        if(describeSize){
            describeSize.text = txt;
        }
    }
    
    public void SetDescribeSpeedText(string txt){
        if(describeSpeed){
            describeSpeed.text = txt;
        }
    }

    public void SetScoreText(string txt){
        if(scoreText){
            scoreText.text = txt;
        }
    }

    public void SetLevelSizeText(string txt){
        if(lvSize){
            lvSize.text = txt;
        }
    }

    public void SetLevelSpeedText(string txt){
        if(lvSpeed){
            lvSpeed.text = txt;
        }
    }

    public void SetRoundText(string txt){
        if(roundText){
            roundText.text = txt;
        }
    }

    public void SetColorRoundText(Color color){
        if(roundText){
            roundText.color=color;
        }
    }

    public void ShowGameOverPanel(bool isShow){
        if(GameOverPanel){
            GameOverPanel.SetActive(isShow);
        }
    }

    public void ShowButtonUpdateSize(bool isShow){
        if(updateSize){
            updateSize.gameObject.SetActive(isShow);
        }
    }
    public void ShowButtonSpeedSize(bool isShow){
        if(updateSpeed){
            updateSpeed.gameObject.SetActive(isShow);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
