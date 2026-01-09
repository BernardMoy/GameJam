using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class howToPlay : MonoBehaviour
{   

    public void StartTraining(){
        SceneManager.LoadScene(1);
    }

    public void StartBoss(){
        SceneManager.LoadScene(2);
    }

    public void HomeScreen(){
        SceneManager.LoadScene(0);
    }
}


