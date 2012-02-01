using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Delay;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HybridOrientationChanges
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Provide easy access to the frame
        private static HybridOrientationChangesFrame MyHybridOrientationChangesFrame
        {
            get { return (HybridOrientationChangesFrame)(((App)(App.Current)).RootFrame); }
        }

        public MainPage()
        {
            InitializeComponent();

            // Prevent screen lock
            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
        }

        private void HandleIsAnimationEnabledChanged(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            MyHybridOrientationChangesFrame.IsAnimationEnabled = checkBox.IsChecked.GetValueOrDefault();
        }

        private void HandleDurationChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            MyHybridOrientationChangesFrame.Duration = TimeSpan.FromSeconds(double.Parse(((string)radioButton.Content).Split()[0], CultureInfo.InvariantCulture));
        }

        private void HandleEasingFunctionChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            switch ((string)radioButton.Content)
            {
                case "CircleEase":
                    MyHybridOrientationChangesFrame.EasingFunction = new CircleEase();
                    break;
                case "QuadraticEase":
                    MyHybridOrientationChangesFrame.EasingFunction = new QuadraticEase();
                    break;
            }
        }
    }
}
