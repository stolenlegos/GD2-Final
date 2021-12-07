using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEvents {
  public delegate void SheepAction(GameObject obj);
  public static event SheepAction SheepCollected;
  public static event SheepAction SheepDied;
  public static event SheepAction SheepEscaped;


  public static void CollectSheep(GameObject obj) {
    if (SheepCollected != null) {
      SheepCollected(obj);
    }
  }


  public static void EscapeSheep(GameObject obj) {
    if (SheepEscaped != null) {
      SheepEscaped(obj);
    }
  }


  public static void KillSheep(GameObject obj) {
    if (SheepDied != null) {
      SheepDied(obj);
    }
  }
}