using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerManager playerManager;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    public void JumpButton()
    {
        playerController.JumpButton();
    }

    public void StarButton()
    {
        playerManager.StarButton();
    }
}
