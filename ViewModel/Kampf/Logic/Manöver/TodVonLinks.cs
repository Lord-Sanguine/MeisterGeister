﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeisterGeister.ViewModel.Kampf.Logic.Manöver
{
    public class TodVonLinks : Attacke
    {
        public static bool BeherrschtManöver(KämpferInfo ausführender)
        {
            if (ausführender == null)
                return false;
            if (ausführender.Kämpfer is Model.Held)
                return ((Model.Held)ausführender.Kämpfer).HatSonderfertigkeitUndVoraussetzungen("Tod von Links", true);
            else //TODO evtl check auf Kampfregel
                return false;
        }

        public TodVonLinks(KämpferInfo ausführender)
            : base(ausführender)
        { }

        protected override void Init()
        {
            base.Init();
            Name = "Tod von Links";
            Literatur = "WdS 65";
        }
    }
}
