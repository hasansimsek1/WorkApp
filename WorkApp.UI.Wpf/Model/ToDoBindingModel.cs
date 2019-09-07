using WorkApp.UI.Wpf.ViewModel;

namespace WorkApp.UI.Wpf.Model
{
    /// <summary>
    /// Data transfer object of the ToDo entity that is bound to user interface. 
    /// Inherits from ViewModelBase class that implements INotifyPropertyChanged interface.
    /// </summary>
    public class ToDoBindingModel : ViewModelBase
    {
        private int _id;
        private string _text;
        private bool _isCompleted;
        private bool _isDeleted;

        /// <summary>
        /// Unique identifier for the todo object.
        /// </summary>
        public int Id
        {
            get {
                return _id;
            }

            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Text of the todo object.
        /// </summary>
        public string Text
        {
            get { return _text; }

            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Status of the todo object that shows if it is completed or not.
        /// </summary>
        public bool IsCompleted
        {
            get { return _isCompleted; }

            set
            {
                _isCompleted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Status of the soft-delete operation of the ToDo entity.
        /// </summary>
        public bool IsDeleted
        {
            get { return _isDeleted; }

            set
            {
                _isDeleted = value;
                OnPropertyChanged();
            }
        }
    }
}
