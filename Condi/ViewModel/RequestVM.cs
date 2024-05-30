using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Condi.DBStorage;

namespace Condi.ViewModel
{
    public class RequestVM : BaseViewModel
    {
        private Request _request;
        public Request Request
        {
            get => _request;
            set
            {
                _request = value;
                OnPropertyChanged(nameof(Request));
            }
        }

        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        private Request _selectedRequest;
        public Request SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                _selectedRequest = value;
            }
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private DateTime _dateAdded;
        public DateTime DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                OnPropertyChanged(nameof(DateAdded));
            }
        }

        private string _deviceModel;
        public string DeviceModel
        {
            get => _deviceModel;
            set
            {
                _deviceModel = value;
                OnPropertyChanged(nameof(DeviceModel));
            }
        }

        private int _equipmentTypeId;
        public int EquipmentTypeId
        {
            get => _equipmentTypeId;
            set
            {
                _equipmentTypeId = value;
                OnPropertyChanged(nameof(EquipmentTypeId));
            }
        }

        private string _problemDescription;
        public string ProblemDescription
        {
            get => _problemDescription;
            set
            {
                _problemDescription = value;
                OnPropertyChanged(nameof(ProblemDescription));
            }
        }

        private string _clientName;
        public string ClientName
        {
            get => _clientName;
            set
            {
                _clientName = value;
                OnPropertyChanged(nameof(ClientName));
            }
        }

        private int _statusId;
        public int StatusId
        {
            get => _statusId;
            set
            {
                _statusId = value;
                OnPropertyChanged(nameof(StatusId));
            }
        }

        private int _executorId;
        public int ExecutorId
        {
            get => _executorId;
            set
            {
                _executorId = value;
                OnPropertyChanged(nameof(ExecutorId));
            }
        }

        private int _applicantId;
        public int ApplicantId
        {
            get => _applicantId;
            set
            {
                _applicantId = value;
                OnPropertyChanged(nameof(ApplicantId));
            }
        }

        private ObservableCollection<EquipmentType> _equipmentTypes;
        public ObservableCollection<EquipmentType> EquipmentTypes
        {
            get => _equipmentTypes;
            set
            {
                _equipmentTypes = value;
                OnPropertyChanged(nameof(EquipmentTypes));
            }
        }

        public RequestVM()
        {
            EquipmentTypes = new ObservableCollection<EquipmentType>();
            Requests = new ObservableCollection<Request>();
            LoadRequests();
        }

        public void LoadRequests()
        {
            if (Requests.Count > 0)
                Requests.Clear();
            var res = DBStorage.DBStorage.DB_s.Request.ToList();
            res.ForEach(e=>Requests?.Add(e));
        }

        public void DeleteSelectedRequest()
        {
            using (var db = new CondiEntities())
            {
                var res = MessageBox.Show("Вы уверены что хотите удалить выбранный элемент?\nЭто действие отменить невозможно","Предупреждение",MessageBoxButton.YesNo,MessageBoxImage.Question);

                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        var forDelete = db.Request.FirstOrDefault(e => e.Id == SelectedRequest.Id);
                        db.Request.Remove(forDelete);
                        db.SaveChanges();
                        MessageBox.Show("Данные успешно удалены","Удаление",MessageBoxButton.OK,MessageBoxImage.Information);
                        LoadRequests();
                    } catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось удалить выбранный элемент\nПодробности:\n{ex}","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                } 
            }
        }
    }
}
