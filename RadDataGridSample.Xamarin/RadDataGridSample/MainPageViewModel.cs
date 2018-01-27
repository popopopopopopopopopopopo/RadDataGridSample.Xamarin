using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadDataGridSample.Models;

namespace RadDataGridSample
{
    public class MainPageViewModel : BindableBase
    {
        public MainPageViewModel()
        {
            InitializeCommands();
        }

        private ObservableCollection<Person> _myPersons = Person.GetSampleList();
        public ObservableCollection<Person> Persons
        {
            get => _myPersons;
            set => SetProperty(ref _myPersons, value);
        }


        public string _myLogoUrl = "XamarinApp001.Resources.icons8-webhook-50.png";
        /// <summary>
        /// 
        /// </summary>
        public string LogoUrl
        {
            get { return _myLogoUrl; }
            set
            {
                SetProperty(ref _myLogoUrl, value);
            }
        }

        public string _myLogoUrlLongPack = "pack://application:,,,/XamarinApp001;component/Resources/icons8-webhook-50.png";
        /// <summary>
        /// この記述だと、Xamarinでは参照できない
        /// </summary>
        public string LogoUrlLongPack
        {
            get { return _myLogoUrlLongPack; }
            set
            {
                SetProperty(ref _myLogoUrlLongPack, value);
            }
        }

        private string _myInputMessage = "";
        public string InputMessage
        {
            get { return _myInputMessage; }
            set
            {
                SetProperty(ref _myInputMessage, value);
            }
        }

        private void InitializeCommands()
        {
            HelloCommand = new DelegateCommand(() => 
            {
                Message = $"Hello {InputMessage}";

                Persons.Add(new Person { Name = Message });

            }, ()=> {
                return string.IsNullOrEmpty(InputMessage);
            });
        }

        public DelegateCommand HelloCommand { get; set; }

        private string _myCallBackMessage = "";
        public string CallBackMessage
        {
            get { return _myCallBackMessage; }
            set
            {
                SetProperty(ref _myCallBackMessage, value);
            }
        }

        private string _myMessage = "";
        public string Message
        {
            get { return _myMessage; }
            set { SetProperty(ref _myMessage, value, () => 
            {
                CallBackMessage = $"Hello Seted {_myMessage}";
            }); }
        }

        private static MainPageViewModel myInstance = new MainPageViewModel();
        public static MainPageViewModel Instance
        {
            get { return myInstance; }
            set { myInstance = value; }
        }
    }
}
