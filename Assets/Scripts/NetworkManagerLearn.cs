using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerLearn : NetworkManager
{
    // Note: if there are n players, numPlayers is n-1, ex. if there is 1 player, numPlayers is 0
        public override void OnServerAddPlayer(NetworkConnection conn, AddPlayerMessage extraMessage)
    {
        Debug.Log("numPlayers connected to server: "+numPlayers);
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }

}
