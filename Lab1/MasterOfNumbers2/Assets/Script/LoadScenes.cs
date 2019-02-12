using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void backButton(){
             SceneManager.LoadScene("StartScene");
        }
     public void helpButton(){
             SceneManager.LoadScene("HelpScene");
        }
     public void startButton(){
             SceneManager.LoadScene("BallScene");
        }
}
