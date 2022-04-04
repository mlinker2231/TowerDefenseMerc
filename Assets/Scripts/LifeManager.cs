using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LifeManager : MonoBehaviour
{
    [SerializeField] int _lives;
    [SerializeField] TMP_Text livesText;

    void Start()
    {
        livesText.text = "Lives: " + _lives;   
    }

    public void loseLife()
    {

        _lives -= 1;
        livesText.text = "Lives: " + _lives;
        if (_lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
