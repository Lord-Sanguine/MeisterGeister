﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeisterGeister.Model.Extensions;

namespace MeisterGeister.Model
{
    public partial class Held_Talent : MeisterGeister.Logic.General.Probe
    {
        #region //---- PROBE ----

        override public int[] Werte
        {
            get
            {
                if (_werte == null)
                    _werte = new int[3];
                if (Held != null && Talent != null)
                {
                    _werte[0] = Held.GetEigenschaftWert(Talent.Eigenschaft1);
                    _werte[1] = Held.GetEigenschaftWert(Talent.Eigenschaft2);
                    _werte[2] = Held.GetEigenschaftWert(Talent.Eigenschaft3);
                }
                return _werte;
            }
            set
            {
                _werte = value;
                _chanceBerechnet = false;
                OnChanged("Werte");
            }
        }

        [DependentProperty("TaW")]
        public override int Fertigkeitswert
        {
            get
            {
                return TaW ?? 0;
            }
            set
            {
                TaW = value;
                _chanceBerechnet = false;
                OnChanged("Fertigkeitswert");
            }
        }

        #endregion //---- PROBE ----
    }
}
