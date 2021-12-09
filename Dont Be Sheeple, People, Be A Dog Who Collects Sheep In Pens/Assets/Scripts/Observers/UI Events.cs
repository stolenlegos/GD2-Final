using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents {
  public delegate void UIText (string text);
  public static event UIText TimerUpdated;

  public delegate void WinLose();
  public static event WinLose GameWon;
  public static event WinLose GameLost;
  public static event WinLose TimeLost;
  public static event WinLose PlayerDead;

  public delegate void GameStart();
  public static event GameStart GameStarted;


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


  public static void StartGame() {
    if (GameStarted != null) {
      GameStarted();
    }
  }


  public static void LoseTime() {
    if (TimeLost != null) {
      TimeLost();
    }
  }


  public static void KillPlayer() {
    if (PlayerDead != null) {
      PlayerDead();
    }
  }
}
