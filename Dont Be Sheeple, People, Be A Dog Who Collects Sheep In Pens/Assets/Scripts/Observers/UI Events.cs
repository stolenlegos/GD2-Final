using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents {
  public delegate void UIText (string text);
  public static event UIText TimerUpdated;

  public delegate void WinLose();
  public static event WinLose GameWon;
  public static event WinLose GameLost;


  public static void UpdateTimer (string text) {
    if (TimerUpdated != null) {
      TimerUpdated(text);
    }
  }


  public static void WinGame() {
    if (GameWon != null) {
      GameWon();
    }
  }


  public static void LoseGame() {
    if (GameLost != null) {
      GameLost();
    }
  }
}
