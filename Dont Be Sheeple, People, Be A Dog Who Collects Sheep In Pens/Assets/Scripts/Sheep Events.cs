using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEvents {
  public delegate void SheepAction(GameObject obj);
  public static event SheepAction SheepCollected;

  public static void CollectSheep(GameObject obj){
    if (SheepCollected != null) {
      SheepCollected(obj);
    }
  }
}
