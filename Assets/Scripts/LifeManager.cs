using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LifeManager : MonoBehaviour
{
    [SerializeField] int _lives;
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text highScoreText;

    private int highScoreLevel = 3;
    private EnemySpawner enemySpawner;

    void Start()
    {
        LoadPlayer();
        livesText.text = "Lives: " + _lives;
        enemySpawner = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>();
    }

    public void loseLife()
    {
        _lives -= 1;
        livesText.text = "Lives: " + _lives;
        if (_lives == 0)
        {
            SavePlayer();
            SceneManager.LoadScene("GameOver");
        }
    }
    public void SavePlayer()
    {
        int level = enemySpawner.level;

        int oldHighScore = int.Parse(highScoreText.text);
        
        if (level > oldHighScore) 
        SaveData.SavePlayer(level);
    }
    public void LoadPlayer()
    {

        PlayerData data = SaveData.LoadPlayer();

        if (data != null)
            highScoreLevel = data.level;

        highScoreText.text = "" + highScoreLevel;
    }

}
