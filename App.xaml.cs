﻿using System;
using System.Data.SqlServerCe;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using MeisterGeister.Daten;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using System.Xml;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Globalization;
using System.Windows.Markup;
using Microsoft.Win32;
using System.Diagnostics;
using System.Linq;

// Eigene Usings
using MeisterGeister.Logic.Einstellung;
using MeisterGeister.Logic.General;
using MeisterGeister.View.Windows;

namespace MeisterGeister {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        /// <summary>
        /// Startup-Fenster, das während der Initialisierung und des Abspielens des Jingles angezeigt wird.
        /// </summary>
        static StartupWindow _splashScreen = new StartupWindow();

        public static object SqlCompactVersion = "-";

        private static BackgroundWorkerQueue _queue;
        public static BackgroundWorkerQueue Queue
        {
            get
            {
                if (_queue == null)
                    _queue = new BackgroundWorkerQueue();
                return _queue;
            }
        }


        public App() {

            // Überprüfen, ob MeisterGeister bereits läuft
            Process proc = Process.GetCurrentProcess();
            int count = Process.GetProcesses().Where(p => p.ProcessName == proc.ProcessName).Count();

            if (count > 1)
            {
                MessageBox.Show("MeisterGeister ist schon gestartet. \nProzess wird beendet...");
                App.Current.Shutdown();
                return;
            }


            LogInfo log = Logger.PerformanceLogStart("Programmstart");

#if !DEBUG
            this.DispatcherUnhandledException += Application_DispatcherUnhandledException;
#endif

            // ShutdownMode
            ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;

            // Prüfen, ob MG von einem Netzlaufwerk gestartet wird
            if (CheckNetzlaufwerk())
                return;

#if !DEBUG
            // Startup-Fenster anzeigen (schließt sich automatisch)
            _splashScreen.Show();
#endif

            // Windows-Forms-Controls Windows-Theme aktivieren
            System.Windows.Forms.Application.EnableVisualStyles();

            // Prüfen, ob Datenbank vorhanden ist
            if (!File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Daten\DatabaseDSA.sdf")) {
                // Es handelt sich vermutlich um eine Neuinstallation:
                // Standard-Datenbank kopieren und umbenennen
                try {
                    File.Copy(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Daten\DatabaseDSA_Standard.sdf",
                         Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Daten\DatabaseDSA.sdf", false);
                } catch (Exception ex) {
                    MsgWindow errWin = new MsgWindow("Datenbank-Fehler", "Die Standard-Datanbank konnte nicht gefunden werden!", ex);
                    errWin.ShowDialog();
                    Shutdown();
                    return;
                }
            }

            // Erneut prüfen...
            if (!File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Daten\DatabaseDSA.sdf"))
            {
                string msg = "Die Datenbank-Datei \"Daten\\DatabaseDSA.sdf\" konnte nicht gefunden werden. Das Programm wird geschlossen.";
                MsgWindow errWin = new MsgWindow("Datenbank-Fehler", msg);
                errWin.ShowDialog();
                Shutdown();
                return;
            }

            // Schreibrecht prüfen
            if (!IsWriteable(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Daten\DatabaseDSA.sdf"))
            {
                string msg = "Das Programm hat keinen schreibenden Zugriff auf die Datenbank-Datei \"Daten\\DatabaseDSA.sdf\". "
                    + "Kopiere DSA MeisterGeister in ein Verzeichnis mit Schreibzugriff und starte es erneut.";
                MsgWindow errWin = new MsgWindow("Datenbank-Fehler", msg);
                errWin.ShowDialog();
                Shutdown();
                return;
            }

            // SQL-Server Compact Version prüfen
            SqlCompactVersion = "-";
            SqlCompactVersion = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server Compact Edition\v4.0", "Version", "-");
            string sqlCompactVersionNeeded = "4.0.8"; //4.0.8482.1 oder 4.0.8876.1
            if (SqlCompactVersion == null || !SqlCompactVersion.ToString().StartsWith(sqlCompactVersionNeeded))
            {
                string msg = "Es ist keine, eine falsche oder eine beschädigte Microsoft SQL Server Compact Edition installiert.\n"
                    + "Installiert:\t" + SqlCompactVersion
                    + "\nBenötigt:\t\t" + sqlCompactVersionNeeded + "\n\nDie benötigte Edition kann unter folgendem Link heruntergeladen werden:\n\n"
                    + @"http://www.microsoft.com/de-de/download/details.aspx?id=30709";
                MsgWindow errWin = new MsgWindow("Datenbank-Fehler", msg);
                errWin.ShowDialog();
                Shutdown();
                return;
            }

            //Version der Datenbank überprüfen und upgraden.
            try {
                SqlCeUpgrade.Run(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Daten\DatabaseDSA.sdf");
            } catch (Exception ex) {
#if !DEBUG
                MsgWindow errWin = new MsgWindow("Fehler beim Datenbank-Upgrade", "Beim Datenbank-Upgrade ist ein Fehler aufgetreten!", ex);
                errWin.ShowDialog();
                Shutdown();
#endif
            }

            // Auf Datenbank-Update prüfen
            try {
                string msg = string.Empty;
                MsgWindow msgWin = null;

                switch (DatabaseUpdate.PerformDatabaseUpdate()) {
                    case DatabaseUpdateResult.DatenbankVersionOK:
                        break;
                    case DatabaseUpdateResult.DatenbankUpdateOK:                        
                        //Neues Release auf Vorab-Version - HINWEISTEXT
                        if (DatabaseUpdate.UserDatabaseVersion < 129)
                            msg = string.Format("Update auf die Vorab-Version Release 2.5.2."
                                + "\nDiese Vorab-Version haben wir erstellt, damit ihr die neuen Features jetzt schon testen und nutzen könnt."
                                + "\nAllerdings kann es bei der Vorab-Version zu unvorhergesehenem Fehlverhalten oder Abstürzen des Programms kommen."
                                + "\nNatürlich haben wir versucht alles bislang erkannte zu eliminieren, jedoch kann es sein, dass wir nicht alle "
                                + "\nVarianten abgefangen haben."
                                + "\nFalls ihr mit dieser Version nicht zurecht kommt, könnt ihr das erstellte Backup zurückspielen und die "
                                + "\nvorherige Version nutzen." + "\n\n");

                        msg += string.Format("Es wurde ein Update Ihrer Datenbank durchgeführt, da Ihre Version veraltet war!"
                            + "\nBitte starten Sie die Anwendung neu.\n\nBisherige Datenbank-Version: {0}\nNeue Datenbank-Version: {1}"
                            + "\n\nEs wurde ein Backup der Datenbank im Daten-Verzeichnis erstellt.", DatabaseUpdate.UserDatabaseVersion, DatabaseUpdate.DatenbankVersionAktuell);
                        msgWin = new MsgWindow("Datenbank Update", msg, false);
                        msgWin.ShowDialog();                        

                        // nicht mehr benötigte Dateien aus früheren Versionen löschen bzw. verschieben
                        DatabaseUpdate.CleanUpDirectory();
                        Shutdown();
                        return;
                    case DatabaseUpdateResult.DatenbankNeuer:
                        msg = string.Format("Die verwendete Datenbank-Version ist neuer als die erwartete Version!"
                            + "\n Die MeisterGeister Programm-Version ist zu alt für die Datenbak."
                            + "\nBitte lade eine neue MeisterGeister Version herunter (www.meistergeister.org).\n\nVerwendete Datenbank-Version: {0}\nErwartete Datenbank-Version: {1}",
                        DatabaseUpdate.UserDatabaseVersion, DatabaseUpdate.DatenbankVersionAktuell);
                        msgWin = new MsgWindow("Fehler beim Datenbank-Update", msg, false);
                        msgWin.ShowDialog();
                        Shutdown();
                        return;
                    case DatabaseUpdateResult.UnbekanntesErgebnis:
                    case DatabaseUpdateResult.DatenbankUpdateError:
                    default:
                        msgWin = new MsgWindow("Fehler beim Datenbank-Update", "Unbekannter Datenbank-Update Fehler.\n" + DatabaseUpdate.UpdateStatus, false);
                        msgWin.ShowDialog();
                        Shutdown();
                        return;
                }
            } catch (Exception ex) {
                MsgWindow errWin = new MsgWindow("Fehler beim Datenbank-Update", "Beim Datenbank-Update ist ein Fehler aufgetreten!\n" + DatabaseUpdate.UpdateStatus, ex);
                errWin.ShowDialog();
                Shutdown();
                return;
            }

            InitializeComponent();

            try {
                // Jingle abspielen
#if !(NO_JINGLE)
                if (!Einstellungen.JingleAbstellen)
                    AudioPlayer.PlayJingle();
#endif
            } catch (Exception ex) {
                MsgWindow errWin = new MsgWindow("Audio Fehler", "Beim Abspielen des Start-Jingles ist ein Fehler aufgetreten.", ex);
                Nullable<bool> dialogResult = errWin.ShowDialog();
                errWin.Close();
                Application.Current.MainWindow.Opacity = 1;
            }

            Logger.PerformanceLogEnd(log);

            // Restliche Daten aus Datenbank laden
            LoadDataFromDatabase();

            QueueAsyncJobs();
        }

        private void QueueAsyncJobs()
        {
            
        }

        private bool CheckNetzlaufwerk()
        {
            string dirRoot = System.IO.Directory.GetDirectoryRoot(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            bool isNetzlaufwerk = true;

            try
            {
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(dirRoot);
                isNetzlaufwerk = (driveInfo.DriveType == DriveType.Network);
            }
            catch (Exception) { }

            if (isNetzlaufwerk)
            {
                if (MessageBox.Show("MeisterGeister wird von einem Netzlaufwerk gestartet. Leider wird die Verwendung eines Netzlaufwerks nicht zuverlässig unterstützt. Es wird empfohlen eine lokale Festplatte zu nutzen."
                    + "\n\n   Trotzdem starten (OK)      Beenden (Abbrechen)", "Starten von Netzlaufwerk", 
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel) == MessageBoxResult.Cancel)
                {
                    Shutdown();
                    return true;
                }
            }
            return false;
        }

        private void LoadDataFromDatabase() {
            //DW 2012-01-24: Globale-Klasse mit allen Daten wird initialisiert
            Global.Init();
        }

        public static bool IsWriteable(string filename) {
            if (File.Exists(filename)) {
                FileInfo fi = new FileInfo(filename);
                if (fi.IsReadOnly)
                    return false;
            }
            return true;
        }

        public static void SaveHelden() {
            //Wenn Helden gespeichert werden, werden sie für die neue Struktur neu geladen
            Global.ContextHeld.UpdateList<Model.Held>();
        }

        public static void SaveAll() {
            // Änderungen in Datenbank speichern
            if (Global.IsInitialized) {
                try {
                    Global.ContextHeld.Save();
                } catch (Exception ex) {
                    MsgWindow errWin = new MsgWindow("Fehler beim Speichern der Datenbank", "Beim Speichern der Datenbank ist ein Fehler aufgetreten!", ex);
                    errWin.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Verfügbare Download-Versionen abrufen.
        /// </summary>
        /// <returns>[0] enthällt die öffentliche Release Version, [1] die interne Release Version</returns>
        public static Version[] GetVersionDownload() {
            Version v = new Version();
            Version vIntern = new Version();
            Version[] versionen = new Version[] { v, vIntern };
            XmlDocument xmlDoc;
            try {
                xmlDoc = new XmlDocument();
                WebClient webClient = new WebClient();
                webClient.Headers.Add("user-agent", string.Format("MeisterGeister/{0} (OS: {1}, Id: {2})", App.GetVersionStringLong(), Environment.OSVersion.ToString(), Einstellungen.MeisterGeisterID.ToString()));
                string xmlString = webClient.DownloadString("http://meistergeister.org/download/675/");
                xmlDoc.LoadXml(xmlString);
                
                string version = string.Empty;

                XmlNodeList versionXml = xmlDoc.SelectNodes("meistergeister/version");
                if (versionXml != null && versionXml.Count > 0)
                {
                    version = versionXml[0].InnerText;
                    string[] values = version.Split('.');
                    if (values.Length == 3)
                        v = new Version(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), 0, Convert.ToInt32(values[2]));
                    else if (values.Length > 3)
                        v = new Version(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[3]), Convert.ToInt32(values[2]));
                    versionen[0] = v;
                }

                versionXml = xmlDoc.SelectNodes("meistergeister/version_intern");
                if (versionXml != null && versionXml.Count > 0)
                {
                    version = versionXml[0].InnerText;
                    string[] values = version.Split('.');
                    if (values.Length == 3)
                        vIntern = new Version(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), 0, Convert.ToInt32(values[2]));
                    else if (values.Length > 3)
                        vIntern = new Version(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[3]), Convert.ToInt32(values[2]));
                    versionen[1] = vIntern;
                }
            } catch (Exception ex) {
                MsgWindow errWin = new MsgWindow("Fehler bei Update-Prüfung", "Beim Prüfung auf Updates ist ein Fehler aufgetreten!", ex);
                errWin.ShowDialog();
            }

            return versionen;
        }

        public static string GetVersionStringLong()
        {
            string intern = string.Empty;
            if (Global.INTERN)
            {
                intern = "INTERN";
            }
#if TEST
            intern = "TEST";
#endif
            return string.Format("Version: {0} / {1}   {2}", App.GetVersionString(App.GetVersionProgramm()), DatabaseUpdate.DatenbankVersionAktuell, intern);
        }

        public static string GetVersionString(Version v) {
            if (v.Build == 0)
                return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Revision);
            else
                return string.Format("{0}.{1}.{2}.{3}", v.Major, v.Minor, v.Revision, v.Build);
        }

        public static Version GetVersionProgramm() {
            // Programm-Version abrufen
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            return assemName.Version;
        }

        public static void CheckUpdates(bool popupWhenUpToDate) {
            try
            {
                Version[] vDownload = GetVersionDownload();
                Version vProgramm = GetVersionProgramm();
                string vDownloadString = GetVersionString(vDownload[0]);
                string vDownloadInternString = GetVersionString(vDownload[1]);
                string vProgrammString = GetVersionString(vProgramm);
                string infoText = string.Empty;
                int compareVersions = int.MinValue;

                if (vDownload == null || vDownload[0] == null || vDownload[0] == new Version())
                    infoText = "Die aktuelle Programm Version konnte nicht geprüft werden.";
                else
                {
                    vProgramm = new Version(vProgramm.Major, vProgramm.Minor, vProgramm.Revision, vProgramm.Build);
                    vDownload[0] = new Version(vDownload[0].Major, vDownload[0].Minor, vDownload[0].Revision, vDownload[0].Build);
                    if (vDownload[1] == null || vDownload[1] == new Version())
                        vDownload[1] = new Version(0, 0, 0, 0);
                    else
                        vDownload[1] = new Version(vDownload[1].Major, vDownload[1].Minor, vDownload[1].Revision, vDownload[1].Build);

                    compareVersions = vDownload[0].CompareTo(vProgramm);
                    if (compareVersions == 0)
                        infoText += string.Format("Das Programm ist auf dem aktuellsten Stand.\n\nInstallierte Version: {0}", vProgrammString);
                    else if (compareVersions > 0)
                        infoText = string.Format("Es liegt eine neue Programm-Version vor.\n\nInstallierte Version: {0}\nDownload Version: {1}"
                        + "\n\nDie aktuelle Version kann unter '{2}' runtergeladen werden.", vProgrammString, vDownloadString,
                        MeisterGeister.Properties.Settings.Default.MeisterGeisterURL);
                    else
                    {
                        // möglicherweise handelt es sich um einen Intern-Release
                        compareVersions = vDownload[1].CompareTo(vProgramm);
                        if (compareVersions == 0)
                            infoText = string.Format("Das Programm ist auf dem aktuellsten Stand.\n\nInstallierte Version: {0}", vProgrammString);
                        else
                            infoText = string.Format("Die installierte Programm-Version ist neuer als die Download-Version.\n\nInstallierte Version: {0}\nDownload Version: {1}",
                                vProgrammString, vDownloadString);
                    }
                }

                infoText += "\n\nLetzte Update-Prüfung: " + Einstellungen.LastUpdateCheck;
                DateTime checkTime = DateTime.Now;
                Einstellungen.LastUpdateCheck = checkTime.ToString();
                infoText += Einstellungen.CheckForUpdates ? "\nNächste automatische Prüfung frühestens: " + checkTime.Date.AddDays(1) : string.Empty;
                infoText += "\n\n(Die automatische Update-Prüfung kann in den Einstellungen deaktiviert werden.)";


                if (compareVersions == 0 && !popupWhenUpToDate)
                    return;

                MessageBox.Show(infoText, "Versions-Prüfung", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MsgWindow errWin = new MsgWindow("Fehler bei Update-Prüfung", "Beim Prüfung auf Updates ist ein Fehler aufgetreten!", ex);
                errWin.ShowDialog();
            }
        }


        internal static string GetOSName() {
            if (Environment.OSVersion.Version.Major == 10)
                return "Windows 10";
            else if (Environment.OSVersion.Version.ToString().StartsWith("6.2"))
                return "Windows 8";
            else if (Environment.OSVersion.Version.ToString().StartsWith("6.1.8400"))
                return "Windows Home Server 2011";
            else if (Environment.OSVersion.Version.ToString().StartsWith("6.1"))
                return "Windows 7 / Server 2008 R2";
            else if (Environment.OSVersion.Version.ToString().StartsWith("6.0"))
                return "Windows Vista / Server 2008";
            else if (Environment.OSVersion.Version.ToString().StartsWith("5.2"))
                return "Windows XP 64bit / Server 2003 / Server 2003 R2";
            else if (Environment.OSVersion.Version.ToString().StartsWith("5.1"))
                return "Windows XP";
            else if (Environment.OSVersion.Version.ToString().StartsWith("5.0"))
                return "Windows 2000";
            else if (Environment.OSVersion.Version.ToString().StartsWith("4.9"))
                return "Windows Me";
            return "Unbekannt";
        }

        internal static string GetFrameworkFromRegistry()
        {
            string version = string.Empty;

            // Versionen 1-4
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {

                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, must be later.
                            version += Environment.NewLine + "  " + versionKeyName + "  " + name;
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                version += Environment.NewLine + "  " + versionKeyName + "  " + name + "  SP" + sp;
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later.
                                version += Environment.NewLine + "  " + versionKeyName + "  " + name;
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    version += Environment.NewLine + "    " + subKeyName + "  " + name + "  SP" + sp;
                                }
                                else if (install == "1")
                                {
                                    version += Environment.NewLine + "    " + subKeyName + "  " + name;
                                }

                            }

                        }

                    }
                }
            }

            // Versionen 4.5 und höher
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
               RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
            {
                version += Environment.NewLine + "  v4.5";
                string versionKey = ndpKey.GetValue("Version").ToString();
                version += Environment.NewLine + "    Full " + versionKey;
            }
            return version;
        }

        internal static void CloseSplashScreen() {
            if (_splashScreen != null) {
                _splashScreen.KillMe();
                _splashScreen = null;
            }
        }

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CreateSpecificCulture("de-DE").IetfLanguageTag)));

        }

        protected override void OnExit(ExitEventArgs e)
        {
            Global.CleanUp();
            base.OnExit(e);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            // Dieser EventHandler fängt alle unbehandelten Ausnahmen und zeigt den Fehler an.
            MsgWindow errWin = new MsgWindow("Unbehandelte Ausnahme", "Es ist eine unbehandelte Ausnahme aufgetreten. Das Programm wird beendet.\n", e.Exception);
            errWin.ShowDialog();
            e.Handled = true;
            Shutdown();
        }

    }
}
