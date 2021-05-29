using WorkApp.UI.Wpf.ViewModel;

namespace WorkApp.UI.Wpf.Model
{
    public class ToDoBindingModel : ViewModelBase
    {
        private int _id;
        private string _text;
        private bool _isCompleted;
        private bool _isDeleted;

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


        public string Text
        {
            get { return _text; }

            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }


        public bool IsCompleted
        {
            get { return _isCompleted; }

            set
            {
                _isCompleted = value;
                OnPropertyChanged();
            }
        }


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
