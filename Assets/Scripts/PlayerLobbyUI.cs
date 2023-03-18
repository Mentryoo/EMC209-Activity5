using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLobbyUI : MonoBehaviour
{
    [SerializeField] private GameObject nickNameUI;
    [SerializeField] private GameObject actorNumUI;
    [SerializeField] private GameObject idUI;
    [SerializeField] private GameObject hostIcon;
    [SerializeField] private GameObject promoteButton;

    public void Initialize(string nickName, string actorNum, string id, bool host, bool playerIsHost) {
        nickNameUI.GetComponent<Text>().text = nickName;
        actorNumUI.GetComponent<Text>().text = actorNum;
        idUI.GetComponent<Text>().text = id;
        if(host) {
            hostIcon.GetComponent<SpriteRenderer>().color = Color.red;
        } else {
            hostIcon.GetComponent<SpriteRenderer>().color = Color.green;
        }

        if(playerIsHost) {
            promoteButton.SetActive(true);
        }
    }

    public void Promote() {
        hostIcon.GetComponent<SpriteRenderer>().color = Color.red;
        promoteButton.SetActive(false);
    }
}
