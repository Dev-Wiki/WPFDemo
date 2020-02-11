using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFDemo.Annotations;

namespace WPFDemo.DataBinding {
    public class DataBindingViewModule : INotifyPropertyChanged {

        public string SearchText { get; set; }

        public ObservableCollection<Person> ResultList { get; private set; }

        public ObservableCollection<Person> Persons { get; private set; }

        public ICommand QueryCommand {
            get => new QueryCommand(Searching, CanSearch);
        }

        public DataBindingViewModule() {
            Persons = new ObservableCollection<Person> {
                new Person() {Name = "zhangsan", Age = 11},
                new Person() {Name = "lisi", Age = 10},
                new Person() {Name = "wangwu", Age = 11}
            };
            ResultList = Persons;
        }


        private void Searching() {
            if (string.IsNullOrEmpty(SearchText)) {
                ResultList = Persons;
            } else {
                ObservableCollection<Person> collection = new ObservableCollection<Person>();
                foreach (var person in Persons) {
                    if (person.Name.Contains(SearchText)) {
                        collection.Add(person);
                    }
                }

                if (collection.Count != 0) {
                    ResultList = collection;
                }
            }
        }

        private bool CanSearch() {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
