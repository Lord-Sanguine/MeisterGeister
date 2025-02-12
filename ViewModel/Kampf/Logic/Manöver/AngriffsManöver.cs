﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeisterGeister.Logic.General;
using MeisterGeister.Model;
using MeisterGeister.View.General;
using System.Diagnostics;

namespace MeisterGeister.ViewModel.Kampf.Logic.Manöver
{
    public abstract class AngriffsManöver : NahkampfManöver
    {
        public AngriffsManöver(KämpferInfo ausführender)
            : base(ausführender)
        { }

        #region Mods

        public const string WUCHTSCHLAG_MOD = "Wuchtschlag";
        public const string FINTE_MOD = "Finte";
        public const string STUMPF_MOD = "Stumpf";
        public const string ÜBERRASCHT_MOD = "Überrascht";
        public const string PASSIERSCHLAG_MOD = "Passierschlag";

        protected override void InitMods(IWaffe waffe)
        {
            base.InitMods(waffe);

            //----------ANSAGEN----------

            NahkampfModifikator<int> wuchtschlag = new NahkampfModifikator<int>(this);
            if (Ausführender.PreAngriffsMods != null)
                wuchtschlag.Value = ((NahkampfModifikator<int>)Ausführender.PreAngriffsMods[WUCHTSCHLAG_MOD]).Value;
            wuchtschlag.GetMod = WuchtschlagMod;
            mods.Add(WUCHTSCHLAG_MOD, wuchtschlag);

            NahkampfModifikator<int> finte = new NahkampfModifikator<int>(this);
            if (Ausführender.PreAngriffsMods != null)
                finte.Value = ((NahkampfModifikator<int>)Ausführender.PreAngriffsMods[FINTE_MOD]).Value;
            finte.GetMod = FinteMod;
            mods.Add(FINTE_MOD, finte);

            NahkampfModifikator<int> stumpf = new NahkampfModifikator<int>(this);
            if (Ausführender.PreAngriffsMods != null)
                stumpf.Value = ((NahkampfModifikator<int>)Ausführender.PreAngriffsMods[STUMPF_MOD]).Value;
            mods.Add(STUMPF_MOD, stumpf);

            //----------POSITION UND SITUATION----------

            NahkampfModifikator<bool> passierschlag = new NahkampfModifikator<bool>(this);
            if (Ausführender.PreAngriffsMods != null)
                passierschlag.Value = ((NahkampfModifikator<bool>)Ausführender.PreAngriffsMods[PASSIERSCHLAG_MOD]).Value;
            passierschlag.GetMod = PassierschlagMod;
            mods.Add(PASSIERSCHLAG_MOD, passierschlag);

            NahkampfModifikator<int> überrascht = new NahkampfModifikator<int>(this);
            if (Ausführender.PreAngriffsMods != null)
                überrascht.Value = ((NahkampfModifikator<int>)Ausführender.PreAngriffsMods[ÜBERRASCHT_MOD]).Value;
            mods.Add(ÜBERRASCHT_MOD, überrascht);
        }

        protected virtual int WuchtschlagMod(INahkampfwaffe waffe, int value)
        {
            Held held = Ausführender.Kämpfer as Held;
            if (held != null && held.HatSonderfertigkeitUndVoraussetzungen("Wuchtschlag"))
            {
                return value;
            }
            else return Math.Max(0, value * 2);
        }

        protected virtual int FinteMod(INahkampfwaffe waffe, int value)
        {
            Held held = Ausführender.Kämpfer as Held;
            if (held != null && held.HatSonderfertigkeitUndVoraussetzungen("Finte"))
            {
                return value;
            }
            else return Math.Max(0, value * 2);
        }

        protected virtual int PassierschlagMod(INahkampfwaffe waffe, bool value)
        {
            //TODO: Ini-Modifikator beachten, Aufmerksamkeit(+4), Kampfgespür(+2)
            if (value)
                return 4;
            else return 0;
        }

        protected override int GrößeMod(INahkampfwaffe waffe, Größe value)
        {
            switch (value)
            {
                case Größe.Winzig:
                    return 4;
                case Größe.SehrKlein:
                    return 2;
                default:
                    return 0;
            }
        }

        protected override int PositionGegnerMod(INahkampfwaffe waffe, Position value)
        {
            switch (value)
            {
                case Position.Liegend:
                    return -3;
                case Position.Kniend:
                    return -1;
                case Position.Fliegend:
                    return 2;
                default:
                    return 0;
            }
        }

        protected override int ÜberzahlMod(INahkampfwaffe waffe, int value)
        {
            return value > 0 ? -1 : 0;
        }

        protected override int UnbewaffnetMod(INahkampfwaffe waffe, bool value)
        {
            return value ? 1 : 0;
        }

        protected override int BeengtMod(INahkampfwaffe waffe, bool value)
        {
            if (value)
            {
                Talent talent = waffe.Talent;
                if (talent != null)
                {
                    if (KämpftMitTalent(waffe, "Anderthalbhänder", "Kettenwaffen", "Peitsche", "Stäbe", "Zweihandflegel", "Zweihand-Hiebwaffen", "Zweihandschwerter/-säbel"))
                        return 6;
                    else if (KämpftMitTalent(waffe, "Hiebwaffen", "Infanteriewaffen", "Säbel", "Schwerter"))
                        return 2;
                }
            }
            return 0;
        }

        protected override int WasserMod(INahkampfwaffe waffe, Wassertiefe value)
        {
            int mod;
            switch (value)
            {
                case Wassertiefe.Hüfttief:
                    mod = 2;
                    break;
                case Wassertiefe.Schultertief:
                    mod = 4;
                    break;
                case Wassertiefe.UnterWasser:
                    mod = 6;
                    break;
                default:
                    mod = 0;
                    break;
            }
            return CheckWasserkampf(mod, value, Ausführender.Kämpfer as Held, waffe);
        }

        #endregion

        protected override void Init()
        {
            base.Init();
            Angriffsaktionen = 1;
            Typ = ManöverTyp.Aktion;
        }

        public override void AktionAusführen()
        {
            base.AktionAusführen();

            foreach (var wz in WaffeZiel)
            {
                Probe p = new Probe();
                p.Probenname = Name;
                p.Werte = new int[] { wz.Key.AT };
                p.WerteNamen = "AT";
                p.Modifikator = Mods.Values.Sum(mod => mod.Result);
                p.KritischVerhaltenGlücklich = ProbeKritischVerhalten.BESTÄTIGUNG;
                p.KritischVerhaltenPatzer = ProbeKritischVerhalten.BESTÄTIGUNG;
                if (Ausführender.Kämpfer is Held)
                    ViewHelper.ShowProbeDialog(p, Ausführender.Kämpfer as Held);
                
                //Prüfen ob das Ziel pariert o.Ä.
                bool cancel = OnAusgeführt(p);
                if (!cancel)
                {
                    ProbeAuswerten(p, wz.Value, wz.Key, null);
                }
            }
            if (WaffeZiel.Count == 0 && Ausführender.Kämpfer is Gegner)
            {
                Gegner_Angriff gAngriff = (Ausführender.Kämpfer as Gegner).Angriffe.FirstOrDefault();
                if (gAngriff != null)
                {
                    Probe p = new Probe();
                    p.Probenname = gAngriff.Name;
                    p.Werte = new int[] { gAngriff.AT };
                    p.WerteNamen = "AT";
                    p.Modifikator = Mods.Values.Sum(mod => mod.Result);
                    p.KritischVerhaltenGlücklich = ProbeKritischVerhalten.BESTÄTIGUNG;
                    p.KritischVerhaltenPatzer = ProbeKritischVerhalten.BESTÄTIGUNG;
                    if (Ausführender.Kämpfer is Gegner)
                        ViewHelper.ShowProbeDialog(p, null);

                    //Prüfen ob das Ziel pariert o.Ä.
                    bool cancel = OnAusgeführt(p);
                    if (!cancel)
                    {
                        //TODO: Standard Waffe müsste erstellt werden
                        //    ProbeAuswerten(p, (Ausführender.Kämpfer as Gegner).ki, gAngriff.Base_Angriff null, null);
                    }
                }
            }
        }

        protected override void Erfolg(Probe p, KämpferInfo ziel, INahkampfwaffe waffe, ManöverEventArgs e_init)
        {
            //Schaden machen
            int schaden = ViewHelper.ShowWürfelDialog(String.Format("{0}W{1}+{2}", waffe.TPWürfelAnzahl, waffe.TPWürfel, waffe.TPBonus + waffe.TPKKBonus), "Schaden mit " + waffe.Name);

            if (ziel != null)
                ziel.SchadenMachen.Execute(schaden);
        }

        //TODO JT: Wenn AusdauerImKampf
        //Wenn Waffe schwerer als KK*10 Unzen
        // Ausführender.AusdauerAktuell--;
        //Wenn BE / 3 > 0
        // Ausführender.AusdauerAktuell-= BE/3;
    }
}
