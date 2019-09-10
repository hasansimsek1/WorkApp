using System.Windows;
using System.Windows.Controls;
using WorkApp.UI.Wpf.ViewModel;


namespace WorkApp.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml. 
    /// UI related logic in MainWindow is done in this class (like SizeChanged event handler)
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        /// <summary>
        /// Being used by the drawer component of WPF material library to determine the open/close state of the drawer.
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// Binds the viewmodel parameter to its data context and runs the LoadAsync method of the incoming viewmodel.
        /// </summary>
        /// <param name="viewModel">A viewmodel class that will be bound to DataContext of the MainWindow. Dependency injector injects the related class automatically at runtime.</param>
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }


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
    }
}
