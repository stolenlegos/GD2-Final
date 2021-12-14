using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEvents {
  public delegate void SheepAction(GameObject obj);
  public static event SheepAction SheepCollected;
  public static event SheepAction SheepDied;
  public static event SheepAction SheepEscaped;

  public delegate void SheepGoal(int num);
  public static event SheepGoal SetGoal;

  public delegate void SheepBounds (bool tf);
  public static event SheepBounds BoundsCheck;


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
      Debug.Log(sheepDied);
    }
  }


  public static void GoalSet(int num) {
    if(SetGoal != null) {
      SetGoal(num);
      //Debug.Log("Goal was Sent");
    }
  }

  public static void CheckBounds(bool tf) {
    if (BoundsCheck != null) {
      BoundsCheck(tf);
    }
  }
}
