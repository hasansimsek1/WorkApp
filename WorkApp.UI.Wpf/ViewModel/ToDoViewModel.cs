﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WorkApp.Common.Entities;
using WorkApp.UI.Wpf.Interfaces;
using System.Windows;
using System.Windows.Input;
using WorkApp.Service.Interfaces;
using WorkApp.UI.Wpf.Model;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WorkApp.UI.Wpf.ViewModel
{
    /// <summary>
    /// View model that is bound to the MainWindowToDoUserControl user control. 
    /// </summary>
    public class ToDoViewModel : ViewModelBase, IToDoViewModel
    {
        private ICrudService<ToDo> _toDoService;

        /// <summary>
        /// Bound to DataGrid element in the MainWindowToDoUserControl.
        /// </summary>
        public ObservableCollection<ToDoBindingModel> ToDoes { get; set; }


        /// <summary>
        /// Initializes ToDoes observable collection, binds a method to the ToDoes.CollectionChanged event and 
        /// dependency injection mechanism injects relevant ToDo service via ICrudService<ToDo> parameter.
        /// </summary>
        /// <param name="toDoService">Related todo service that injected by dependency injector</param>
        public ToDoViewModel(ICrudService<ToDo> toDoService)
        {
            ToDoes = new ObservableCollection<ToDoBindingModel>();
            _toDoService = toDoService;
            ToDoes.CollectionChanged += ToDoes_CollectionChanged;
        }

        private void ToDoes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (ToDoBindingModel item in e.NewItems)
                    item.PropertyChanged += ToDoes_PropertyChanged;

            if (e.OldItems != null)
                foreach (ToDoBindingModel item in e.OldItems)
                    item.PropertyChanged -= ToDoes_PropertyChanged;
        }

        private async void ToDoes_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            // *************** TAKE THESE CODES TO THE SERVICE LAYER *********************

            ToDoBindingModel toDoBindingModel = (ToDoBindingModel)sender;
            
            var result = await _toDoService.GetByIdAsync(toDoBindingModel.Id);

            if(result.HasError || result.Data == null)
            {
                System.Windows.Forms.MessageBox.Show("Could not find the record in database");
                return;
            }

            ToDo toDoEntity = result.Data;
            toDoEntity.IsCompleted = toDoBindingModel.IsCompleted;
            toDoEntity.IsDeleted = toDoBindingModel.IsDeleted;
            toDoEntity.Text = toDoBindingModel.Text;
            
            result = await _toDoService.UpdateAsync(toDoEntity);

            if(result.HasError)
                System.Windows.Forms.MessageBox.Show("An error has occured while updating the record!");

        }


        /// <summary>
        /// Gets todo records from service layer asynchronously and fills the ToDoes observable collection.
        /// </summary>
        /// <returns></returns>
        public async Task LoadAsync()
        {
            var result = await _toDoService.GetAllAsync();

            if (result.HasError)
            {
                MessageBox.Show("An error has occured while getting 'To Do' records from database.");
                return;
            }

            foreach (var toDo in result.Data.Where(x => x.IsDeleted != true).ToList())
            {
                ToDoes.Add(
                    new ToDoBindingModel
                    {
                        Id = toDo.Id,
                        IsCompleted = toDo.IsCompleted,
                        IsDeleted = toDo.IsDeleted,
                        Text = toDo.Text
                    });
            }
        }


        /// <summary>
        /// Command that binds DeleteToDo method to UI via RelayCommand<ToDoBindingModel>(DeleteToDo).
        /// </summary>
        public ICommand DeleteToDoCommand
        {
            get
            {
                if (_deleteToDoCommand == null)
                    _deleteToDoCommand = new RelayCommand<ToDoBindingModel>(DeleteToDo);
                return _deleteToDoCommand;
            }
        }
        private ICommand _deleteToDoCommand;
        private void DeleteToDo(object parameters)
        {
            // I think it is better to bind minus button to each item in the list
            System.Windows.Forms.MessageBox.Show("Not implemented yet..");
        }


        /// <summary>
        /// Command that binds AddToDo method to UI via RelayCommand<object>(AddToDo).
        /// </summary>
        public ICommand AddToDoCommand
        {
            get
            {
                if (_addToDoCommand == null)
                    _addToDoCommand = new RelayCommand<object>(AddToDo);
                return _addToDoCommand;
            }
        }
        private ICommand _addToDoCommand;
        private async void AddToDo(object parameter)
        {
            ToDo toDo = new ToDo { Text = "New to do..", IsCompleted = false };

            var result = await _toDoService.InsertAsync(toDo);

            if (result.HasError)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while inserting new to do to the database.");
                return;
            }

            ToDoes.Add(
                new ToDoBindingModel
                {
                    Id = result.Data.Id,
                    Text = result.Data.Text,
                    IsCompleted = result.Data.IsCompleted,
                    IsDeleted = result.Data.IsDeleted
                });
        }
    }
}
