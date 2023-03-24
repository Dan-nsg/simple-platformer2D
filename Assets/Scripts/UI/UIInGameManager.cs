using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Plataformer2D.Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }
}
