using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class Score : NetworkBehaviour
{
    public class SyncDictionaryStringItem : SyncDictionary<string, int> {}

    public Text scoreText;
    private SyncDictionaryStringItem scores = new SyncDictionaryStringItem();

    public void clear(){scores = new SyncDictionaryStringItem();}
    public void deletePlayer(string name){scores.Remove(name);}
    public void score(string name){scores[name] += 1;}
    public void addPlayer(string name){ scores.Add(name, 0);}

    public override void OnStartServer()
    {
        clear();
        // Don't need anything here
        Debug.Log("Starting the score");
    }

    public override void OnStartClient()
    {
        // Equipment is already populated with anything the server set up
        // but we can subscribe to the callback in case it is updated later on
        scores.Callback += OnScoreChange;
    }
    void OnScoreChange(SyncDictionaryStringItem.Operation op, string key, int score)
    {
        display(key, score);
        // equipment changed,  perhaps update the gameobject
        Debug.Log(op + " - " + key);
    }


    public void display(string key, int new_score)
    {
        scoreText.text = "";
        foreach (KeyValuePair<string, int> score in scores) {
            if (score.Key == key)
            {
                Debug.Log(key + ": " + new_score);
                scoreText.text += key + ": " + new_score + "\n";
            }
            else
            {
                Debug.Log(score.Key + ": " + score.Value);
                scoreText.text += score.Key + ": " + score.Value + "\n";
            }
        }
    }

}