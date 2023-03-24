using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;

    public void KillPlayer()
    {
        if(player != null)
            player.DestroyMe();
    }
}
