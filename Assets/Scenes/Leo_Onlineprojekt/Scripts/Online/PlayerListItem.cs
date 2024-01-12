using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text text;
    Player player;
    string[] playerNames;

    public void SetUp(Player _player)
    {
        player = _player;
        text.text = _player.NickName;
    }

    public override void OnEnable()
    {
        UpdateList();
        base.OnEnable();
    }

    public void UpdateList()
    {
        playerNames = new string[PhotonNetwork.PlayerList.Length];
        for (int i = 0; i < playerNames.Length; i++)
        {
            playerNames[i] = PhotonNetwork.PlayerList[i].NickName;
        }
        text.text = "";
        foreach (string name in playerNames)
        {
            text.text += name + "\n";
        }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdateList();
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateList();
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnJoinedRoom()
    {
        UpdateList();
        base.OnJoinedRoom();
    }

    public override void OnLeftRoom()
    {
        UpdateList();
        base.OnLeftRoom();
    }


}
