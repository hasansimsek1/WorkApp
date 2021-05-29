using System.Windows;
using System.Windows.Controls;
using WorkApp.UI.Wpf.ViewModel;

/// <summary>
/// 
/// </summary>
namespace WorkApp.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        private MainViewModel _viewModel;

        public bool IsChecked { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth < 1000)
            {
                if (ContentGrid.RowDefinitions.Count < 4)
                {
                    RowDefinition thirdRow = new RowDefinition();
                    thirdRow.Name = "ContentGridFourthRow";
                    RowDefinition fourthRow = new RowDefinition();
                    fourthRow.Name = "ContentGridThirdRow";
                    ContentGrid.RowDefinitions.Add(thirdRow);
                    ContentGrid.RowDefinitions.Add(fourthRow);

                    Grid.SetColumn(NonVisibleToDoCard, 0);
                    Grid.SetRow(NonVisibleToDoCard, 0);

                    Grid.SetColumn(NonVisibleNoteCard, 0);
                    Grid.SetRow(NonVisibleNoteCard, 1);

                    Grid.SetColumn(NonVisibleWebPage1, 0);
                    Grid.SetRow(NonVisibleWebPage1, 2);

                    Grid.SetColumn(NonVisibleWebPage2, 0);
                    Grid.SetRow(NonVisibleWebPage2, 3);

                    ContentGrid.ColumnDefinitions.Remove(ContentGrid.ColumnDefinitions[1]);
                }
            }
            else
            {
                if (ContentGrid.RowDefinitions.Count > 2)
                {
                    ColumnDefinition secondColumn = new ColumnDefinition();
                    secondColumn.Name = "ContentGridSecondColumn";
                    ContentGrid.ColumnDefinitions.Add(secondColumn);

                    ContentGrid.RowDefinitions.Remove(ContentGrid.RowDefinitions[2]);
                    ContentGrid.RowDefinitions.Remove(ContentGrid.RowDefinitions[2]);

                    Grid.SetRow(NonVisibleToDoCard, 0);
                    Grid.SetColumn(NonVisibleToDoCard, 0);

                    Grid.SetRow(NonVisibleNoteCard, 0);
                    Grid.SetColumn(NonVisibleNoteCard, 1);

                    Grid.SetRow(NonVisibleWebPage1, 1);
                    Grid.SetColumn(NonVisibleWebPage1, 0);

                    Grid.SetRow(NonVisibleWebPage2, 1);
                    Grid.SetColumn(NonVisibleWebPage2, 1);
                }
            }
        }






        //private void MakeWindowMobileButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Window window = Application.Current.MainWindow;
        //    window.WindowState = WindowState.Normal;
        //    window.Height = SystemParameters.FullPrimaryScreenHeight;
        //    window.Width = 500;
        //    window.Top = 0;
        //    window.Left = 0;
        //}

        //private void MaximizeWindowButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Window window = Application.Current.MainWindow;
        //    window.WindowState = WindowState.Maximized;
        //}

        //private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Window window = Application.Current.MainWindow;
        //    window.WindowState = WindowState.Minimized;
        //}

        //private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}
    }
}
