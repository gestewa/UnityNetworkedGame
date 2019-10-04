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
        // Don't need anything here
    }

    public override void OnStartClient()
    {
        // Equipment is already populated with anything the server set up
        // but we can subscribe to the callback in case it is updated later on
        scores.Callback += OnScoreChange;
    }
    void OnScoreChange(SyncDictionaryStringItem.Operation op, string key, int score)
    {
        display();
        // equipment changed,  perhaps update the gameobject
        Debug.Log(op + " - " + key);
    }


    public void display(){
        scoreText.text = "";
        foreach (KeyValuePair<string, int> score in scores) {
            Debug.Log(score.Key+": "+score.Value);
            scoreText.text += score.Key+": "+score.Value + "\n";
        }
    }

}