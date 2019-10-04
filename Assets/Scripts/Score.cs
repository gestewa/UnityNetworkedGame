using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class Score : NetworkBehaviour
{
    public Text scoreText;
    private Dictionary<string, int> scores = new Dictionary<string, int>();

    public void clear(){scores = new Dictionary<string, int>();}
    public void deletePlayer(string name){scores.Remove(name);}
    public void score(string name){scores[name] += 1;display();}
    public void addPlayer(string name){ scores.Add(name, 0);}

    public void display(){
        scoreText.text = "";
        foreach (KeyValuePair<string, int> score in scores) {
            Debug.Log(score.Key+": "+score.Value);
            scoreText.text += score.Key+": "+score.Value + "\n";
        }
    }

}