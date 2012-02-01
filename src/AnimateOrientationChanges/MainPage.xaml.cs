using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Delay;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AnimateOrientationChanges
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Provide easy access to the frame
        private static AnimateOrientationChangesFrame MyAnimateOrientationChangesFrame
        {
            get { return (AnimateOrientationChangesFrame)(((App)(App.Current)).RootFrame); }
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
            MyAnimateOrientationChangesFrame.IsAnimationEnabled = checkBox.IsChecked.GetValueOrDefault();
        }

        private void HandleDurationChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            MyAnimateOrientationChangesFrame.Duration = TimeSpan.FromSeconds(double.Parse(((string)radioButton.Content).Split()[0], CultureInfo.InvariantCulture));
        }

        private void HandleEasingFunctionChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            switch ((string)radioButton.Content)
            {
                case "ElasticEase":
                    MyAnimateOrientationChangesFrame.EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 5 };
                    break;
                case "QuarticEase":
                    MyAnimateOrientationChangesFrame.EasingFunction = new QuarticEase();
                    break;
            }
        }
    }
}
