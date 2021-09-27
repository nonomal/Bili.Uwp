// Copyright (c) Richasy. All rights reserved.

using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Richasy.Bili.App.Controls
{
    /// <summary>
    /// 主色设置.
    /// </summary>
    public sealed partial class PrimaryColorSettingSection : SettingSectionControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryColorSettingSection"/> class.
        /// </summary>
        public PrimaryColorSettingSection()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsCustomPrimaryColor)
            {
                CustomRadioButton.IsChecked = true;
            }
        }

        private void OnColorRadioButtonSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Any() && e.AddedItems.First() is RadioButton btn)
            {
                var isCustom = btn != SystemRadioButton;
                ViewModel.IsCustomPrimaryColor = isCustom;
            }
        }

        private void OnColorChanged(Microsoft.UI.Xaml.Controls.ColorPicker sender, Microsoft.UI.Xaml.Controls.ColorChangedEventArgs args)
        {
            ViewModel.CustomPrimaryColor = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToHex(args.NewColor);
        }
    }
}
