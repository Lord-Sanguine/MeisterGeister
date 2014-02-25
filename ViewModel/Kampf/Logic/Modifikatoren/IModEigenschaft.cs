﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeisterGeister.ViewModel.Kampf.Logic.Modifikatoren
{
    public interface IModEigenschaft : IModifikator { }
    public interface IModMitAuswirkungAufBerechneteWerte : IModifikator { }

    #region Basiseigenschaften
    public interface IModMU : IModEigenschaft
    {
        int ApplyMUMod(int wert);
    }

    public interface IModKL : IModEigenschaft
    {
        int ApplyKLMod(int wert);
    }

    public interface IModIN : IModEigenschaft
    {
        int ApplyINMod(int wert);
    }

    public interface IModCH : IModEigenschaft
    {
        int ApplyCHMod(int wert);
    }

    public interface IModFF : IModEigenschaft
    {
        int ApplyFFMod(int wert);
    }
    public interface IModFFArmL : IModFF { }
    public interface IModFFArmR : IModFF { }

    public interface IModGE : IModEigenschaft
    {
        int ApplyGEMod(int wert);
    }

    public interface IModKO : IModEigenschaft
    {
        int ApplyKOMod(int wert);
    }

    public interface IModKK : IModEigenschaft
    {
        int ApplyKKMod(int wert);
    }

    public interface IModKKArmL : IModKK {}
    public interface IModKKArmR : IModKK {}

    #endregion

    #region Abgeleitete Eigenschaften
    public interface IModGS : IModEigenschaft
    {
        double ApplyGSMod(double wert);
    }

    public interface IModLE : IModEigenschaft
    {
        int ApplyLEMod(int wert);
    }

    public interface IModAU : IModEigenschaft
    {
        int ApplyAUMod(int wert);
    }

    public interface IModAE : IModEigenschaft
    {
        int ApplyAEMod(int wert);
    }

    public interface IModKE : IModEigenschaft
    {
        int ApplyKEMod(int wert);
    }

    public interface IModMR : IModEigenschaft
    {
        int ApplyMRMod(int wert);
    }

    public interface IModINIBasis : IModEigenschaft
    {
        int ApplyINIBasisMod(int wert);
    }

    public interface IModINI : IModEigenschaft
    {
        int ApplyINIMod(int wert);
    }

    public interface IModATBasis : IModEigenschaft
    {
        int ApplyATBasisMod(int wert);
    }

    public interface IModAT : IModEigenschaft
    {
        int ApplyATMod(int wert);
    }
    public interface IModATArmL : IModAT {}
    public interface IModATArmR : IModAT {}

    public interface IModPABasis : IModEigenschaft
    {
        int ApplyPABasisMod(int wert);
    }

    public interface IModPA : IModEigenschaft
    {
        int ApplyPAMod(int wert);
    }
    public interface IModPAArmL : IModPA {}
    public interface IModPAArmR : IModPA {}

    public interface IModFKBasis : IModEigenschaft
    {
        int ApplyFKBasisMod(int wert);
    }

    public interface IModFK : IModEigenschaft
    {
        int ApplyFKMod(int wert);
    }

    public interface IModAusweichen : IModEigenschaft
    {
        int ApplyAusweichenMod(int wert);
    }
    #endregion

    #region Talente und Zauber
    
    /// <summary>
    /// Ist Talentname null, gilt der Modifikator für alle Talente.
    /// </summary>
    public interface IModTalentwert : IModEigenschaft
    {
        ISet<string> Talentname { get; }
        int ApplyTalentwertMod(int wert);
    }
    /// <summary>
    /// Ist Zaubername null, gilt der Modifikator für alle Zauber.
    /// </summary>
    public interface IModZauberwert : IModEigenschaft
    {
        ISet<string> Zaubername { get; }
        int ApplyZauberwertMod(int wert);
    }
    #endregion

    #region Behinderung
    /// <summary>
    /// Der BE Mod wird nirgendwo angewandt. Er dient nur zur Darstellung in der ModifikatorListe.
    /// Siehe die Klasse BehinderungModifikator zur Verwendung.
    /// </summary>
    public interface IModBE : IModifikator
    {
        int ApplyBEMod(int wert);
    }
    #endregion
}
