using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
[SerializeField] float sceneLoadDelay=2f;
ScoreKeeper scoreKeeper;

void Awake(){
   scoreKeeper=FindObjectOfType<ScoreKeeper>();
}
public void loadGame(){
   scoreKeeper.resetScore();
    SceneManager.LoadScene("Level1");
 }
 public void loadMainMenu(){
    SceneManager.LoadScene("MainMenu");
 }
 public void loadGameOver(){
    StartCoroutine(WaitAndLoad("GameOver",sceneLoadDelay));
 }
 public void quitGame(){
    Debug.Log("quiting Gmae");
    Application.Quit();
 }
 IEnumerator WaitAndLoad(String sceneName,float delay){
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(sceneName);
 }
}
