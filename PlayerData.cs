using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
  public int highscore = 0;


  public PlayerData(Data d){
  	highscore = d.highScore;
  }

}
