﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Eigene Usings
using Model = MeisterGeister.Model;
using System.Diagnostics;

namespace MeisterGeister.Model.Service {
    public class HeldService : ServiceBase {

        #region //----- EIGENSCHAFTEN ----

        public List<Model.Held> HeldenListe
        {
            get { return Liste<Held>(); }
        }

        public List<Model.Held> HeldenGruppeListe
        {
            get { return HeldenListe.Where(h => h.AktiveHeldengruppe == true).OrderBy(h => h.Name).ToList(); }
        }

        #endregion

        #region //----- KONSTRUKTOR ----

        public HeldService() {         
        }

        #endregion

        #region //----- DATENBANKABFRAGEN ----

        public Held LoadHeldByName(string aName) {
            var tmp = Context.Held.Where(held => held.Name == aName).FirstOrDefault();
            return tmp;
        }

        public Sonderfertigkeit LoadSonderfertigkeitByName(string aName)
        {
            var tmp = Context.Sonderfertigkeit.Where(s => s.Name == aName).FirstOrDefault();
            return tmp;
        }

        public VorNachteil LoadVorNachteilByName(string aName)
        {
            var tmp = Context.VorNachteil.Where(s => s.Name == aName).FirstOrDefault();
            return tmp;
        }

        #endregion


        public List<Held> LoadHeldenGruppeWithZauberzeichen()
        {
            List<Held> tmp = Liste<Sonderfertigkeit>().Where(s => s.Name == "Zauberzeichen" || s.Name == "Runenkunde" || s.Name.StartsWith("Zauberzeichen: Bann") || s.Name.StartsWith("Zauberzeichen: Schutz"))
                .Join(Context.Held_Sonderfertigkeit, s => s.SonderfertigkeitID, hs => hs.SonderfertigkeitID, (s, hs) => hs)
                .Join(Context.Held, hs => hs.HeldGUID, h => h.HeldGUID, (hs, h) => h).ToList();
            return tmp.Distinct().ToList();
        }
        public List<Zauberzeichen> LoadZauberzeichenByHeld(Model.Held held)
        {
            List<Zauberzeichen> zauberzeichen = Liste<Held>().Where(h=>h.HeldGUID==held.HeldGUID).Join(Context.Held_Sonderfertigkeit,h=>h.HeldGUID,hs=>hs.HeldGUID,(h,hs)=>hs)
                .Join(Context.Sonderfertigkeit,hs=>hs.SonderfertigkeitID,s=>s.SonderfertigkeitID,(hs,s)=>s)
                .Join(Context.Zauberzeichen, s=>s.SonderfertigkeitID, zz=>zz.SonderfertigkeitID,(s,zz)=>zz).Where(z=>z.Typ=="Arkanoglyphe").ToList();
            return zauberzeichen;
        }

        public List<Zauberzeichen> LoadKreiseByHeld(Held held)
        {   
            List<Zauberzeichen> kreise = Liste<Held>().Where(h => h.HeldGUID == held.HeldGUID).Join(Context.Held_Sonderfertigkeit, h => h.HeldGUID, hs => hs.HeldGUID, (h, hs) => hs)
                .Join(Context.Sonderfertigkeit, hs => hs.SonderfertigkeitID, s => s.SonderfertigkeitID, (hs, s) => s)
                .Join(Context.Zauberzeichen, s => s.SonderfertigkeitID, zz => zz.SonderfertigkeitID, (s, zz) => zz).Where(z => z.Typ == "Bannkreis" || z.Typ == "Schutzkreis").ToList();
            return kreise;
        }

        public List<Zauberzeichen> LoadRunenByHeld(Held held)
        {
            List<Zauberzeichen> runen = Liste<Held>().Where(h => h.HeldGUID == held.HeldGUID).Join(Context.Held_Sonderfertigkeit, h => h.HeldGUID, hs => hs.HeldGUID, (h, hs) => hs)
                .Join(Context.Sonderfertigkeit, hs => hs.SonderfertigkeitID, s => s.SonderfertigkeitID, (hs, s) => s)
                .Join(Context.Zauberzeichen, s => s.SonderfertigkeitID, zz => zz.SonderfertigkeitID, (s, zz) => zz).Where(z => z.Typ == "Rune").ToList();
            return runen;
        }

        public int LoadMaxRitualkenntnisWertByHeld(Held held)
        {
            List<int> werte= new List<int>();
            if(held.HatTalent("Ritualkenntnis (Gildenmagie)")) werte.Add(held.Talentwert("Ritualkenntnis (Gildenmagie)"));
            if (held.HatTalent("Ritualkenntnis (Kristallomantie)")) werte.Add(held.Talentwert("Ritualkenntnis (Kristallomantie)"));
            if (held.HatTalent("Ritualkenntnis (Alchimie)")) werte.Add(held.Talentwert("Ritualkenntnis (Alchimie)"));
            if (held.HatTalent("Ritualkenntnis (Zibiljas)")) werte.Add(held.Talentwert("Ritualkenntnis (Zibiljas)"));
            if (held.HatTalent("Ritualkenntnis (Geister binden)")) werte.Add(held.Talentwert("Ritualkenntnis (Geister binden)"));
            if (held.HatTalent("Ritualkenntnis (Runenkunde)")) werte.Add(held.Talentwert("Ritualkenntnis (Runenkunde)"));
            werte.Sort();
            return werte[werte.Count-1];
        }

        public List<Talent> LoadZauberzeichenTalenteByHeld(Held held)
        {
            List<Talent> talente = Liste<Held>().Where(h => h.HeldGUID == held.HeldGUID).Join(Context.Held_Talent, h => h.HeldGUID, ht => ht.HeldGUID, (h, ht) => ht)
                .Join(Context.Talent, ht => ht.Talentname, t => t.Talentname, (ht, t) => t).Where(t => t.Talentname == "Feinmechanik" || t.Talentname == "Holzbearbeitung" || t.Talentname == "Malen/Zeichnen" || t.Talentname == "Schneidern" || t.Talentname == "Webkunst").ToList();
            return talente;
        }

        public List<Talent> LoadRunenTalenteByHeld(Held held)
        {
            List<Talent> talente = Liste<Held>().Where(h => h.HeldGUID == held.HeldGUID).Join(Context.Held_Talent, h => h.HeldGUID, ht => ht.HeldGUID, (h, ht) => ht)
                .Join(Context.Talent, ht => ht.Talentname, t => t.Talentname, (ht, t) => t).Where(t => t.Talentname == "Feinmechanik" || t.Talentname == "Holzbearbeitung" || t.Talentname == "Malen/Zeichnen" || t.Talentname == "Schneidern" || t.Talentname == "Webkunst" || t.Talentname == "Tätowieren").ToList();
            return talente;
        }


        public List<string> LoadIntensitätsbestimmungFertigkeitenAlchimieByHeld(Held held)
        {
            List<string> zauber = Liste<Held>().Where(h => h.HeldGUID == held.HeldGUID).Join(Context.Held_Zauber, h => h.HeldGUID, hz => hz.HeldGUID, (h, hz) => hz)
                .Join(Context.Zauber, hz => hz.ZauberID, z => z.ZauberID, (hz, z) => z).Where(z => z.Name == "Odem Arcanum" || z.Name == "Oculus Astralis").OrderBy(z=>z.Name).Select(z=>z.Name).ToList();
            if (zauber.Contains("Odem Arcanum")) zauber.Add("Odem Arcanum (Sicht)");
            //TODO ??: MP liturgie "Sicht auf Madas Welt"
            List<string> talente = Liste<Held>().Where(h => h.HeldGUID == held.HeldGUID).Join(Context.Held_Talent, h => h.HeldGUID, ht => ht.HeldGUID, (h, ht) => ht)
                .Join(Context.Talent, ht => ht.Talentname, t => t.Talentname, (ht, t) => t).Where(t => t.Talentname == "Pflanzenkunde" || t.Talentname == "Magiegespür").Select(t => t.Talentname).ToList();

            List<string> ret = new List<string>();
            ret.AddRange(zauber);
            ret.AddRange(talente);
            return ret;
        }

        internal List<string> LoadStrukturanalyseFertigkeitenAlchimieByHeld(Held held)
        {
            List<string> zauber = Liste<Held>().Where(h => h.HeldGUID == held.HeldGUID).Join(Context.Held_Zauber, h => h.HeldGUID, hz => hz.HeldGUID, (h, hz) => hz)
                .Join(Context.Zauber, hz => hz.ZauberID, z => z.ZauberID, (hz, z) => z).Where(z => z.Name == "Analys Arcanstruktur" || z.Name == "Oculus Astralis").OrderBy(z => z.Name).Select(z => z.Name).ToList();
            if (zauber.Contains("Odem Arcanum")) zauber.Add("Odem Arcanum (Sicht)");
            //TODO ??: MP liturgien "Blick der Weberin" "Blick durch Tairachs Augen"
            //TODO ??: MP Abfrage nach Allegorischer Analyse (Schale)
            List<string> ret = new List<string>(); 
            ret.AddRange(zauber);
            ret.Add("Analyse nach Augenschein");
            ret.Add("Laboranalyse");
            ret.Add("Infundibulum der Allweisen");
            return ret;
        }
    }
}