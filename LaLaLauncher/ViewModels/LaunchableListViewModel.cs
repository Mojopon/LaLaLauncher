using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using LaLaLauncher.Models;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using MetroTrilithon.Serialization;
using LaLaLauncher.Settings;
using LaLaLauncher.Models.Managers;
using LaLaLauncher.Utility;
using System.IO;

namespace LaLaLauncher.ViewModels
{
    public class LaunchableListViewModel : ViewModel
    {
        private ObservableCollection<Launchable> _Launchables = new ObservableCollection<Launchable>();
        public ObservableCollection<Launchable> Launchables { get { return _Launchables; } }

        #region SelectedItem変更通知プロパティ
        private Launchable _SelectedLaunchable;

        public Launchable SelectedLaunchable
        {
            get
            { return _SelectedLaunchable; }
            set
            {
                if (_SelectedLaunchable == value)
                    return;
                _SelectedLaunchable = value;
                RaisePropertyChanged();
                UpdateLaunchableInformation();
                if (_SelectedLaunchable != null)
                {
                    LaunchableSelected = true;
                }
                else
                {
                    LaunchableSelected = false;
                }
            }
        }
        #endregion


        #region LaunchableSelected変更通知プロパティ
        private bool _LaunchableSelected;
        public bool LaunchableSelected
        {
            get
            { return _LaunchableSelected; }
            set
            { 
                if (_LaunchableSelected == value)
                    return;
                _LaunchableSelected = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region InformationContent変更通知プロパティ
        private LaunchableInformationViewModel _InformationContent;

        public LaunchableInformationViewModel InformationContent
        {
            get
            { return _InformationContent; }
            set
            { 
                if (_InformationContent == value)
                    return;
                _InformationContent = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public LaunchableListViewModel()
        {
            LaunchableSelected = false;
            _Launchables = LaunchableManager.Instance.GetLaunchables();
            UpdateLaunchableInformation();
        }

        void UpdateLaunchableInformation()
        {
            InformationContent = new LaunchableInformationViewModel(_SelectedLaunchable);
        }

        public void Initialize()
        {
        }

        public void AddNewLaunchable()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "アプリケーション(.exe)|*.exe|All Files (*.*)|*.*";

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var path = openFileDialog.FileName;

                AddNewLaunchable(path);
            }
        }

        public void AddNewLaunchable(string path)
        {
            Launchable newLaunchable = new Launchable(path);
            Launchables.Add(newLaunchable);
        }

        public void DeleteSelectedLaunchable()
        {
            if (SelectedLaunchable == null) return;

            var selectedLaunchables = Launchables.Where(x => x.IsSelected == true).ToArray();
            foreach (var launchable in selectedLaunchables)
                Launchables.Remove(launchable);

            SelectedLaunchable = null;
        }

        public void LaunchSelected()
        {
            if (SelectedLaunchable == null) return;

            var selectedLaunchables = Launchables.Where(x => x.IsSelected == true);
            foreach (var launchable in selectedLaunchables)
                launchable.Launch();
        }
    }
}
