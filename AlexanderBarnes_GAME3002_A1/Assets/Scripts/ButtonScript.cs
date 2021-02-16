using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour
{
    public Canvas gameOverUI, NextLevelUI;
    public string Level1, Level2;
    public Button tryAgain, nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        tryAgain.onClick.AddListener(TaskOnClick);
         nextLevel.onClick.AddListener(TaskOnClick2);
        gameOverUI.GetComponent<Canvas>().enabled = false;
        NextLevelUI.GetComponent<Canvas>().enabled = false;
      
  
        


    }

    // Update is called once per frame
  void TaskOnClick()
    {
        SceneManager.LoadScene(Level1);
    }

    void TaskOnClick2()
    {
        SceneManager.LoadScene(Level2);
    }
}
