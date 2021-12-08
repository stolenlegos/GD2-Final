using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

  private Scene scene;
  //delete list when sheep can actually die
  private List<GameObject> _sheep = new List<GameObject>();

  void Awake() {
    scene = SceneManager.GetActiveScene();
    //delete loop when sheep can actually die
    foreach(GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep")) {
      _sheep.Add(sheep);
    }
  }

  public void QuitGame() {
    Application.Quit();
  }


  public void RestartGame() {
    SceneManager.LoadScene(scene.name);
  }


  public void StartGame() {
    UIEvents.StartGame();
  }

//delete this function when sheep can actually die
  public void KillSheep() {
    SheepEvents.KillSheep(_sheep[_sheep.Count - 1]);
  }
}
