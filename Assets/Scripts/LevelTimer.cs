using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float maxDuration;
    public float countDown;
    public static bool isGameOver = false;
    public Text txtCountDown;
    public Text txtFinalMessage;
    public AudioClip winSFX;
    public AudioClip loseSFX;
    public string nextLevel;
    public AudioClip enemySFX;
    public Text scoretxt;
    public int originalPickupCount;
    public int currentPickup;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        this.countDown = maxDuration;
        UpdateTimerText();
        originalPickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        currentPickup = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (this.countDown > 0)
            {
                this.countDown -= Time.deltaTime;
                UpdateTimerText();
                UpdateScoreText();
            }
            else
            {
                LevelLost();
            }
        }
    }

    void UpdateTimerText()
    {
        this.txtCountDown.text = this.countDown.ToString("F2");
    }

    void UpdateScoreText()
    {
        this.scoretxt.text = currentPickup+"/"+originalPickupCount;
    }


    public void LevelLost()
    {
        
        AudioSource.PlayClipAtPoint(this.loseSFX, GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        this.countDown = 0.00f;
        UpdateTimerText();
        isGameOver = true;
        txtFinalMessage.text = "GAME OVER!";
        txtFinalMessage.enabled = true;
        Invoke("RepeatLevel", 2);
    }

    public void LevelWon()
    {
        AudioSource.PlayClipAtPoint(this.winSFX, GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        isGameOver = true;
        txtFinalMessage.text = "YOU WON!";
        txtFinalMessage.enabled = true;
        Invoke("LoadLevel", 2);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(this.nextLevel);
    }

    public void RepeatLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        SceneManager.LoadScene(sceneName);
    }

    public void EnemyDestroyed()
    {
        AudioSource.PlayClipAtPoint(this.enemySFX, GameObject.FindGameObjectWithTag("MainCamera").transform.position);
    }

}
