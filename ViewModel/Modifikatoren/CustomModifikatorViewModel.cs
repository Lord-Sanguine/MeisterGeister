﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeisterGeister.ViewModel.Kampf.Logic.Modifikatoren;
using MeisterGeister.Logic.Extensions;

namespace MeisterGeister.ViewModel.Modifikatoren
{
    public class CustomModifikatorViewModel : Base.ViewModelBase
    {
        /// <summary>
        /// Factory zum Erstellen des Modifikators
        /// </summary>
        private CustomModifikatorFactory factory = new CustomModifikatorFactory();

        #region Basisdaten zum Nachschlagen
        /// <summary>
        /// Liste von möglichen Modifikatoren (gruppiert nach Typ)
        /// </summary>
        public IList<ModifikatorTyp> ModifikatorTypen
        {
            get { return ModifikatorTyp.Liste; }
        }
        ModifikatorTyp selectedModifikatorTyp;
        public ModifikatorTyp SelectedModifikatorTyp
        {
            get { return selectedModifikatorTyp; }
            set { Set(ref selectedModifikatorTyp, value); }
        }
        
        private static List<string> operatoren = new List<string>() { "+", "-", "*", "/" };
        /// <summary>
        /// Liste von Rechenfunktionen
        /// </summary>
        public static List<string> Operatoren
        {
            get { return operatoren; }
        }

        IEnumerable<string> zaubernamen = null;
        /// <summary>
        /// Liste von Zaubernamen
        /// </summary>
        public IEnumerable<string> Zaubernamen
        {
            get {
                if (zaubernamen == null)
                    zaubernamen = Global.ContextHeld.ZauberListe.Select(z => z.Name);
                return zaubernamen; 
            }
            set { Set(ref zaubernamen, value); }
        }

        string selectedZaubername = null;
        /// <summary>
        /// Zum Hinzufügen ausgewählter Zaubername
        /// </summary>
        public string SelectedZaubername
        {
            get { return selectedZaubername; }
            set { Set(ref selectedZaubername, value); }
        }
        
        IEnumerable<string> talentnamen = null;
        /// <summary>
        /// Liste von Talentnamen
        /// </summary>
        public IEnumerable<string> Talentnamen
        {
            get
            {
                if (talentnamen == null)
                    talentnamen = Global.ContextHeld.TalentListe.Select(z => z.Name);
                return talentnamen;
            }
            set { Set(ref talentnamen, value); }
        }

        string selectedTalentname = null;
        /// <summary>
        /// Zum Hinzufügen ausgewählter Talentname
        /// </summary>
        public string SelectedTalentname
        {
            get { return selectedTalentname; }
            set { Set(ref selectedTalentname, value); }
        }
        #endregion

        #region Eigenschaften des Modifikators aus der Factory
        //Liste von eingebrachten Modifikatoren
        ExtendedObservableCollection<ModifikatorTypViewModel> modifikatorTypVMListe = new ExtendedObservableCollection<ModifikatorTypViewModel>();
        public ExtendedObservableCollection<ModifikatorTypViewModel> ModifikatorTypVMListe
        {
            get { return modifikatorTypVMListe; }
            set { Set(ref modifikatorTypVMListe, value); }
        }

        /// <summary>
        /// Fehler aufrund von fehlenden oder falschen Eingaben
        /// </summary>
        IReadOnlyDictionary<object, string> Errors
        {
            get { return factory.Errors; }
        }

        /// <summary>
        /// Die Auswirkungen als Text
        /// </summary>
        string Auswirkungen
        {
            get { return factory.Auswirkungen; }
        }

        /// <summary>
        /// Name des zu erstellenden Modifikators
        /// </summary>
        string Name
        {
            get
            {
                return factory.Name;
            }
            set
            {
                factory.Name = value;
                OnChanged("Name");
            }
        }

        /// <summary>
        /// Literaturangabe des zu erstellenden Modifikators (optional)
        /// </summary>
        string Literatur
        {
            get
            {
                return factory.Literatur;
            }
            set
            {
                factory.Literatur = value;
                OnChanged("Literatur");
            }
        }

        //aus dem childVMs bestimmen, ob die felder benötigt werden.
        bool? needsTalentname = null;
        /// <summary>
        /// Gibt an, ob ein Talentname gebraucht wird.
        /// Wird keiner gebraucht, muss man auch keine Eingabefelder dafür anzeigen.
        /// </summary>
        public bool NeedsTalentname
        {
            private set { Set(ref needsTalentname, value); }
            get
            {
                if (needsTalentname == null)
                {
                    needsTalentname = false;
                    foreach(var vm in modifikatorTypVMListe)
                    {
                        if (vm.NeedsTalentname)
                        {
                            needsTalentname = true;
                            break;
                        }
                    }
                }
                return needsTalentname.Value;
            }
        }

        bool? needsZaubername = null;
        /// <summary>
        /// Gibt an, ob ein Zaubername gebraucht wird.
        /// Wird keiner gebraucht, muss man auch keine Eingabefelder dafür anzeigen.
        /// </summary>
        public bool NeedsZaubername
        {
            private set { Set(ref needsZaubername, value); }
            get
            {
                if (needsZaubername == null)
                {
                    needsZaubername = false;
                    foreach (var vm in modifikatorTypVMListe)
                    {
                        if (vm.NeedsZaubername)
                        {
                            needsZaubername = true;
                            break;
                        }
                    }
                }
                return needsZaubername.Value;
            }
        }
        //0-n Zaubername
        ISet<string> zaubername = new SortedSet<string>();
        public ISet<string> Zaubername
        {
            get { return zaubername; }
            private set { Set(ref zaubername, value); }
        }
        //0-n Talentname
        ISet<string> talentname = new SortedSet<string>();
        public ISet<string> Talentname
        {
            get { return talentname; }
            private set { Set(ref talentname, value); }
        }
        #endregion

        #region Je ModifikatorTyp
        public class ModifikatorTypViewModel : Base.ViewModelBase
        {
            private CustomModifikatorFactory factory;
            /// <summary>
            /// Sobald die Werte in diesem Dictionary festgelegt werden, gelten sie auch automatisch für das Ergebnis.
            /// </summary>
            IDictionary<string, object> factoryProperties;
            
            public ModifikatorTypViewModel(ModifikatorTyp typ, CustomModifikatorFactory factory, ISet<string> talentname = null, ISet<string> zaubername = null)
            { 
                this.factory = factory;
                this.factoryProperties = factory[typ.Typ];
                Typ = typ;
                if (NeedsTalentname)
                    Talentname = talentname;
                if (NeedsZaubername)
                    Zaubername = zaubername;
                ApplyExpression();
            }

            bool? needsMethod = null;
            /// <summary>
            /// Gibt an, ob eine Methode gebraucht wird.
            /// Wird keine gebraucht, muss man auch keine Eingabefelder dafür anzeigen.
            /// </summary>
            public bool NeedsMethod
            {
                get
                {
                    if (needsMethod == null)
                        needsMethod = (GetMethodName() != null);
                    return needsMethod.Value;
                }
            }

            string methodName = "Nothing";
            private string GetMethodName()
            {
                if (methodName != "Nothing")
                    return methodName;
                foreach (var key in factoryProperties.Keys)
                {
                    if (key.StartsWith("Apply") && key.EndsWith("Mod"))
                        return methodName = key;
                }
                return methodName = null;
            }

            bool? needsZaubername = null;
            /// <summary>
            /// Gibt an, ob ein Zaubername gebraucht wird.
            /// Wird keiner gebraucht, muss man auch keine Eingabefelder dafür anzeigen.
            /// </summary>
            public bool NeedsZaubername
            {
                private set { Set(ref needsZaubername, value); }
                get
                {
                    if (needsZaubername == null)
                        needsZaubername = factoryProperties.ContainsKey("Zaubername");
                    return needsZaubername.Value;
                }
            }

            ISet<string> zaubername = null;
            public ISet<string> Zaubername
            {
                get { return zaubername; }
                set { 
                    if(Set(ref zaubername, value))
                    {
                        factoryProperties["Zaubername"] = value;
                        OnChanged("Auswirkungen");
                    }
                }
            }

            bool? needsTalentname = null;
            /// <summary>
            /// Gibt an, ob ein Talentname gebraucht wird.
            /// Wird keiner gebraucht, muss man auch keine Eingabefelder dafür anzeigen.
            /// </summary>
            public bool NeedsTalentname
            {
                private set { Set(ref needsTalentname, value); }
                get
                {
                    if (needsTalentname == null)
                        needsTalentname = factoryProperties.ContainsKey("Talentname");
                    return needsTalentname.Value;
                }
            }

            ISet<string> talentname = null;
            public ISet<string> Talentname
            {
                get { return talentname; }
                set
                {
                    if (Set(ref talentname, value))
                    {
                        factoryProperties["Talentname"] = value;
                        OnChanged("Auswirkungen");
                    }
                }
            }


            ModifikatorTyp typ;
            public ModifikatorTyp Typ
            {
                get { return typ; }
                set { Set(ref typ, value); }
            }

            /// <summary>
            /// Liste der Operatoren.
            /// Wrapper für einfachere Referenzierung.
            /// </summary>
            public IList<string> Operatoren
            {
                get { return CustomModifikatorViewModel.Operatoren; }
            }

            string selectedOperator = "+";
            /// <summary>
            /// Gewählter Operator
            /// </summary>
            public string SelectedOperator
            {
                get { return selectedOperator; }
                set { 
                    if(Set(ref selectedOperator, value))
                        ApplyExpression();
                }
            }

            int wert = 0;
            /// <summary>
            /// Operand zur Rechenfunktion
            /// </summary>
            public int Wert
            {
                get { return wert; }
                set { 
                    if(Set(ref wert, value))
                        ApplyExpression();
                }
            }
            
            /// <summary>
            /// Erstellt mit der Factory eine Expression und weist diese zu.
            /// </summary>
            void ApplyExpression()
            {
                if(!NeedsMethod)
                    return;
                factory.SetModifikator(GetMethodName(), SelectedOperator, Wert);
                OnChanged("Auswirkungen");
            }
            // Beim EndetMitZeitpunkt-Modifikator muss später noch ein DSA-Datum hinzugefügt werden. Das setzt aber einen überarbeiteten Kalender voraus.
        }
        #endregion

        #region Aktionen
        //Aktionen
        // Modifikator hinzufügen
        void AddModifikatorTyp(ModifikatorTyp typ)
        {
            if (factory.AddModifikator(typ.Typ))
            {
                ModifikatorTypViewModel vm = new ModifikatorTypViewModel(typ, factory, talentname, zaubername);
                vm.PropertyChanged += ModVM_PropertyChanged;
                ModifikatorTypVMListe.Add(vm);
                if (vm.NeedsTalentname)
                    NeedsTalentname = true;
                if (vm.NeedsZaubername)
                    NeedsZaubername = true;
            }
        }

        /// <summary>
        /// Modifikator löschen
        /// </summary>
        /// <param name="vm"></param>
        void RemoveModifikatorTyp(ModifikatorTypViewModel vm)
        {
            if (factory.RemoveModifikator(vm.Typ.Typ))
            {
                ModifikatorTypVMListe.Remove(vm);
                vm.PropertyChanged -= ModVM_PropertyChanged;
                InvalidateCache();
            }
        }

        /// <summary>
        /// Talentname hinzufügen
        /// </summary>
        void AddTalentname()
        {
            if (SelectedTalentname != null && Talentname != null)
            {
                if (Talentname.Add(SelectedTalentname))
                    OnChanged("Auswirkungen");
            }
        }

        /// <summary>
        /// Talentname löschen
        /// </summary>
        /// <param name="name"></param>
        void RemoveTalentname(string name)
        {
            if (name != null && Talentname != null)
            {
                if (Talentname.Remove(name))
                    OnChanged("Auswirkungen");
            }
        }

        /// <summary>
        /// Zaubername hinzufügen
        /// </summary>
        void AddZaubername()
        {
            if (SelectedZaubername != null && Zaubername != null)
            {
                if (Zaubername.Add(SelectedZaubername))
                    OnChanged("Auswirkungen");
            }
        }
        
        /// <summary>
        /// Zaubername löschen
        /// </summary>
        /// <param name="name"></param>
        void RemoveZaubername(string name)
        {
            if (name != null && Zaubername != null)
            {
                if (Zaubername.Remove(name))
                    OnChanged("Auswirkungen");
            }
        }

        /// <summary>
        /// Anwenden der eingegebenen Daten.
        /// Es wird ein ICustomModifikator kompiliert und in die Datenbank abgespeichert.
        /// </summary>
        /// <returns>Erfolgreich oder nicht</returns>
        bool Anwenden()
        {
            OnChanged("Errors");
            if (factory.Errors.Count > 0)
                return false;
            ICustomModifikator mod = factory.Finish();
            string json = CustomModifikatorFactory.Serialize(mod);
            //TODO save in DB
            //Mit Überschreiben-Frage
            return true;
        }
        #endregion

        #region Hilfsmethoden
        void InvalidateCache()
        {
            needsZaubername = null;
            needsTalentname = null;
            OnChanged("NeedsTalentname");
            OnChanged("NeedsZaubername");
        }

        void ModVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Auswirkungen")
                OnChanged(e.PropertyName);
        }

        #endregion
    }
}
