using LGame.LUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CLUIHeroPanel : CLUIBehaviour
{

    protected override void OnAwake()
    {

    }

    protected override void OnStart()
    {

    }

    protected override void OnCollider(GameObject btn)
    {
        if (btn == null) return;
        string btnName = btn.name;

        if (btnName == "close")
        {
            SLGameTools.CloseUI(ELUI.HeroPanel);
        }
    }

    protected override void OnClear()
    {

    }

}

