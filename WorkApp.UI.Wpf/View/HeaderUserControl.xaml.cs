using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace WorkApp.UI.Wpf.View
{
    /// <summary>
    /// Interaction logic for DockPanelUserControl.xaml
    /// </summary>
    public partial class HeaderUserControl : UserControl
    {
        bool _areBoxesHidden = false;

        public HeaderUserControl()
        {
            InitializeComponent();
        }

        private void MakeWindowMobileButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.MainWindow;
            window.WindowState = WindowState.Normal;
            window.Height = SystemParameters.FullPrimaryScreenHeight;
            window.Width = 500;
            window.Top = 0;
            window.Left = 0;
        }

        private void MaximizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.MainWindow;
            window.WindowState = WindowState.Maximized;
        }

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.MainWindow;
            window.WindowState = WindowState.Minimized;
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HideContentButton_Click(object sender, RoutedEventArgs e)
        {
            _areBoxesHidden = !_areBoxesHidden;
            Window window = Application.Current.MainWindow;

            if (_areBoxesHidden)
            {
                var toDoBoxCover = (Card)window.FindName("NonVisibleToDoCard");
                toDoBoxCover.Visibility = Visibility.Visible;
                toDoBoxCover.IsEnabled = true;

                var toDoUserControl = (MainWindowToDoUserControl)window.FindName("MainWindowToDoUserControl");
                toDoUserControl.Visibility = Visibility.Hidden;
                toDoUserControl.IsEnabled = false;

                var noteDockCover = (TextBlock)window.FindName("NonVisibleNoteTextBlock");
                noteDockCover.Text = "CONTENT IS HIDDEN";

                var webPage1Cover = (TextBlock)window.FindName("NonVisibleWebPage1Text");
                webPage1Cover.Text = "CONTENT IS HIDDEN";

                var webPage2Cover = (TextBlock)window.FindName("NonVisibleWebPage2Text");
                webPage2Cover.Text = "CONTENT IS HIDDEN";
            }
            else
            {
                var toDoBoxCover = (Card)window.FindName("NonVisibleToDoCard");
                toDoBoxCover.Visibility = Visibility.Hidden;
                toDoBoxCover.IsEnabled = false;

                var toDoUserControl = (MainWindowToDoUserControl)window.FindName("MainWindowToDoUserControl");
                toDoUserControl.Visibility = Visibility.Visible;
                toDoUserControl.IsEnabled = true;

                var noteDockCover = (TextBlock)window.FindName("NonVisibleNoteTextBlock");
                noteDockCover.Text = "NOTE BOX";

                var webPage1Cover = (TextBlock)window.FindName("NonVisibleWebPage1Text");
                webPage1Cover.Text = "MAIL BOX";

                var webPage2Cover = (TextBlock)window.FindName("NonVisibleWebPage2Text");
                webPage2Cover.Text = "MESSAGE BOX";
            }
        }
    }
}
