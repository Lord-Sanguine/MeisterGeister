﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MeisterGeister.Logic.Extensions;
using System.IO;

namespace MeisterGeister.Logic.General
{
    public static class Pdf
    {
        private static string openCommand = null;
        public static string OpenCommand
        {
            get {
                if (string.IsNullOrEmpty(Pdf.openCommand))
                {
                    Pdf.openCommand = Einstellung.Einstellungen.PdfReaderCommand;
                    if (String.IsNullOrWhiteSpace(Pdf.openCommand))
                        GetDefaultReader();
                    if (String.IsNullOrWhiteSpace(Pdf.openCommand))
                        SetReader("Adobe Reader");
                }
                return Pdf.openCommand; 
            }
            set { Einstellung.Einstellungen.PdfReaderCommand = Pdf.openCommand = value; }
        }

        private static string openArguments = null;
        public static string OpenArguments
        {
            get
            {
                if (string.IsNullOrEmpty(Pdf.openArguments))
                {
                    Pdf.openArguments = Einstellung.Einstellungen.PdfReaderArguments;
                    if (String.IsNullOrWhiteSpace(Pdf.openArguments))
                        GetDefaultReader();
                    if (String.IsNullOrWhiteSpace(Pdf.openArguments))
                        SetReader("Adobe Reader");
                } 
                return Pdf.openArguments;
            }
            set { Einstellung.Einstellungen.PdfReaderArguments = Pdf.openArguments = value; }
        }

        public static Dictionary<string, string[]> readers = new Dictionary<string, string[]>();

        static Pdf()
        {
            readers.Add("Adobe Reader", new string[] { "AcroRd32.exe", "/A \"page={1}\" \"{0}\"" });
            readers.Add("Adobe Acrobat", new string[] { "Acrobat.exe", "/A \"page={1}\" \"{0}\"" });
            readers.Add("Evince", new string[] { "evince.exe", "--page-label={1} \"{0}\"" });
            readers.Add("Foxit Reader", new string[] { "Foxit Reader.exe", "/A \"page={1}\" \"{0}\"" });
            readers.Add("PDF-XChange Viewer", new string[] { "PDFXCview.exe", "/A \"page={1}\" \"{0}\"" });
            readers.Add("Sumatra PDF", new string[] { "SumatraPDF.exe", "-page {1} \"{0}\"" });
            readers.Add("Xpdf", new string[] { "xpdf.exe", "\"{0}\" {1}" });

            // weitere PDF-Reader: http://de.wikipedia.org/wiki/Liste_von_PDF-Software
        }

        public static bool SetReader(string readerName, string readerPath = null)
        {
            if(readers.ContainsKey(readerName))
            {
                if(readerPath != null)
                    Pdf.OpenCommand = readerPath;
                else
                    Pdf.OpenCommand = readers[readerName][0];
                Pdf.OpenArguments = readers[readerName][1];
                return true;
            }
            return false;
        }

        public static Process OpenReader(Literatur.Literaturangabe literaturangabe)
        {
            if (literaturangabe == null)
                throw new ArgumentNullException("Die Literaturangabe fehlt.");
            return OpenReader(literaturangabe, literaturangabe.Seiten.FirstOrDefault());
        }

        public static Process OpenReader(Literatur.Literaturangabe literaturangabe, Literatur.Seitenangabe seitenangabe)
        {
            if (literaturangabe == null)
                throw new ArgumentNullException("Die Literaturangabe fehlt.");
            if (seitenangabe == null)
                throw new ArgumentNullException("Die Seitenangabe fehlt.");
            return OpenReader(literaturangabe.Kürzel, seitenangabe.Seite, seitenangabe.IsErrata);
        }

        public static Process OpenReader(string literaturKürzel, int page = 1, bool isErrata = false)
        {
            var l = Model.Literatur.GetByAbkürzung(literaturKürzel, isErrata);
            if (l == null || String.IsNullOrWhiteSpace(l.Pfad))
                throw new Literatur.LiteraturPfadMissingException(literaturKürzel, l);
            string fileName = l.Pfad;
            page += l.Seitenoffset;
            return OpenFileInReader(fileName, page);
        }

        public static Process OpenFileInReader(string fileName, int page = 1)
        {
            if(String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("fileName", "Dateiname (fileName) wurde nicht angegeben.");
            Process p = new Process();
            // relativen Pfad in absoluten umwandeln
            fileName = Logic.Extensions.FileExtensions.ConvertRelativeToAbsolutePath(fileName);
            ProcessStartInfo pi = new ProcessStartInfo(OpenCommand, String.Format(OpenArguments, fileName, page));
            p.StartInfo = pi;
            pi.UseShellExecute = true;
            try
            {
                p.Start();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                throw new System.ComponentModel.Win32Exception(string.Format("Der PDF Reader konnte nicht gefunden werden.\nReader: {0}\nDatei: {1}", OpenCommand, fileName), ex);
            }
            return p;
        }

        /// <summary>
        /// Holt den mit .pdf assozierten Reader von Windows.
        /// Und legt diesen auch gleich fest.
        /// </summary>
        /// <returns>Name des Readers oder null</returns>
        public static string GetDefaultReader()
        {
            string path = FileExtensions.FileExtentionInfo(FileExtensions.AssocStr.Executable, ".pdf");
            if(String.IsNullOrWhiteSpace(path))
                return null;
            string readerExe = System.IO.Path.GetFileName(path);
            foreach(var readerName in readers.Keys)
            {
                if(readers[readerName][0] == readerExe)
                {
                    SetReader(readerName, path);
                    return readerName;
                }
            }
            return null;
        }
    }
}
