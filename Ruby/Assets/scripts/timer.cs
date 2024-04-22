using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class timer : MonoBehaviour
{
    public Button button;
    
    bool soundplay;
    public AudioClip loseSound;

    AudioSource audioSource;

    bool changer = true;    
    
    
    public float time = 30.0f;
    public TMP_Text timerText;
    public RubyController EndGame;


    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Button btn = button.GetComponent<Button>();
    }
   

    void Update()
    {
        if (changer == false)
        {
            time -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(time);
        }

        if (time < 0)
        {
            
            time = 0;
            timerText.text = "No More Time";
            EndGame.speed = 0.0f;
            EndGame.background.SetActive(true);
            EndGame.gameOverText.enabled = true;
            EndGame.gameOverText.text = "You Lost! Press R to Restart!";

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (!soundplay)
            {
                PlaySound(loseSound);
                soundplay = true;
            }
            
        }

        if (EndGame.health == 0)
        {
            time = 0.0f;
            timerText.text = "You Died!";
            changer = true;
        }

        if (EndGame.score == 6)
        {
            timerText.text = "Challenge Won!";
            changer = true;
        }
        
    }

    public void click()
    {

        timerText.enabled = true;
        button.gameObject.SetActive(false);
        changer = false;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    
}
