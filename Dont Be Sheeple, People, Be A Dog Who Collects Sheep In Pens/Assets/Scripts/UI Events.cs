using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents {
  public delegate void UIText (string text);
  public static event UIText TimerUpdated;


  public static void UpdateTimer (string text) {
    if (TimerUpdated != null) {
      TimerUpdated(text);
    }
  }
}
