// Copyright (c) Richasy. All rights reserved.

using System;
using Microsoft.UI.Xaml.Controls;
using Richasy.Bili.ViewModels.Uwp;
using Windows.UI.Xaml;

namespace Richasy.Bili.App.Controls
{
    /// <summary>
    /// 根据不同设备类型自行切换布局的导航视图.
    /// </summary>
    public class AutoLayoutNavigationView : NavigationView
    {
        /// <summary>
        /// <see cref="IsForceTop"/>的依赖属性.
        /// </summary>
        public static readonly DependencyProperty IsForceTopProperty =
            DependencyProperty.Register(nameof(IsForceTop), typeof(bool), typeof(AutoLayoutNavigationView), new PropertyMetadata(false));

        /// <summary>
        /// <see cref="DesktopTemplate"/>的依赖属性.
        /// </summary>
        public static readonly DependencyProperty DesktopTemplateProperty =
            DependencyProperty.Register(nameof(DesktopTemplate), typeof(DataTemplate), typeof(AutoLayoutNavigationView), new PropertyMetadata(null));

        /// <summary>
        /// <see cref="XboxTemplate"/>的依赖属性.
        /// </summary>
        public static readonly DependencyProperty XboxTemplateProperty =
            DependencyProperty.Register(nameof(XboxTemplate), typeof(DataTemplate), typeof(AutoLayoutNavigationView), new PropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoLayoutNavigationView"/> class.
        /// </summary>
        public AutoLayoutNavigationView()
        {
            this.Loaded += OnLoaded;
        }

        /// <summary>
        /// 强制使用顶层布局.
        /// </summary>
        public bool IsForceTop
        {
            get { return (bool)GetValue(IsForceTopProperty); }
            set { SetValue(IsForceTopProperty, value); }
        }

        /// <summary>
        /// 桌面项模板.
        /// </summary>
        public DataTemplate DesktopTemplate
        {
            get { return (DataTemplate)GetValue(DesktopTemplateProperty); }
            set { SetValue(DesktopTemplateProperty, value); }
        }

        /// <summary>
        /// Xbox项模板.
        /// </summary>
        public DataTemplate XboxTemplate
        {
            get { return (DataTemplate)GetValue(XboxTemplateProperty); }
            set { SetValue(XboxTemplateProperty, value); }
        }

        private void OnLoaded(object sender, RoutedEventArgs e) => InitializeLayout();

        private void InitializeLayout()
        {
            if (AppViewModel.Instance.IsXbox && !IsForceTop)
            {
                PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
                OpenPaneLength = 120;
                CompactPaneLength = 120;
                IsPaneOpen = true;
            }
            else
            {
                PaneDisplayMode = NavigationViewPaneDisplayMode.Top;
            }

            MenuItemTemplate = AppViewModel.Instance.IsXbox ? XboxTemplate : DesktopTemplate;
            IsSettingsVisible = false;
            IsPaneToggleButtonVisible = false;
            IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
        }
    }
}
