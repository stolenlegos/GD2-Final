using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

  private Scene scene;

  void Start() {
    scene = SceneManager.GetActiveScene();
  }

  public void QuitGame() {
    Application.Quit();
  }


  public void RestartGame() {
    SceneManager.LoadScene(scene.name);
  }
}
