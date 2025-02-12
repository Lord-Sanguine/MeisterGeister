﻿using Q42.HueApi;
using System;
using System.Windows;
using System.Windows.Media;

namespace MeisterGeister.View.Settings
{
  /// <summary>
  /// Holds a ColorPicker control, and exposes the ColorPicker SelectedColor.
  /// 
  /// Enhanced by Mark Treadwell (1/2/10) to include:
  ///  - Added ability to set ColorPicker initial color via constructor or property
  ///  - Use of Button's IsDefault and IsCancel properties
  ///  - Setting tab behavior
  /// </summary>
  public partial class HUEColorDialog : Window
  {
    #region Constructors

    /// <summary>
    /// Default constructor initializes to Black.
    /// </summary>
    public HUEColorDialog()
      : this(Colors.Black)
    { }

    /// <summary>
    /// Constructor with an initial color.
    /// </summary>
    /// <param name="initialColor">Color to set the ColorPicker to.</param>
    public HUEColorDialog(Color initialColor)
    {
      InitializeComponent();
      colorPicker.InitialColor = initialColor;
    }

        #endregion

        #region Public Properties
    /// <summary>
    /// Gets/sets the ColorDialog color.
    /// </summary>
    public Color SelectedColor
    {
      get { return colorPicker.SelectedColor; }
      set { colorPicker.InitialColor = value; }
    }

    private Light _testLight = null;
    public Light TestLight
    {
        get { return colorPicker.TestLight; }
        set { colorPicker.TestLight = value; }
    }


        #endregion

        #region Event Handlers

        /// <summary>
        /// Close ColorDialog, accepting color selection.
        /// </summary>
        private void btnOK_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
    }

    /// <summary>
    ///  Close ColorDialog, rejecting color selection.
    /// </summary>
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = false;
    }

    #endregion
  }
}
