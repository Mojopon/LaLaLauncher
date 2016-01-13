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
        private ObservableCollection<LaunchableGroup> _LaunchableGroups = new ObservableCollection<LaunchableGroup>();
        public ObservableCollection<LaunchableGroup> LaunchableGroups { get { return _LaunchableGroups; } }

        #region SelectedItem変更通知プロパティ
        private LaunchableGroup _SelectedGroup;

        public LaunchableGroup SelectedGroup
        {
            get
            { return _SelectedGroup; }
            set
            {
                if (_SelectedGroup == value)
                    return;
                _SelectedGroup = value;
                RaisePropertyChanged();
                UpdateLaunchableInformation();
                if (_SelectedGroup != null)
                {
                    GroupSelected = true;
                }
                else
                {
                    GroupSelected = false;
                }
            }
        }
        #endregion

        #region LaunchableSelected変更通知プロパティ
        private bool _GroupSelected;
        public bool GroupSelected
        {
            get
            { return _GroupSelected; }
            set
            { 
                if (_GroupSelected == value)
                    return;
                _GroupSelected = value;
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
            GroupSelected = false;
            _LaunchableGroups = LaunchableManager.Instance.GetLaunchables();
            UpdateLaunchableInformation();
        }

        void UpdateLaunchableInformation()
        {
            //InformationContent = new LaunchableInformationViewModel(_SelectedGroup);
        }

        public void Initialize()
        {
        }

        public void CreateNewCompositeLaunchable()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "アプリケーション(.exe)|*.exe|All Files (*.*)|*.*";

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var path = openFileDialog.FileName;

                var newLaunchable = Launchable.Create(path);
                if(newLaunchable != null)
                {
                    var newGroup = new LaunchableGroup();
                    newGroup.Add(newLaunchable);
                    Console.WriteLine("new composite launchable created");
                    LaunchableGroups.Add(newGroup);
                }
            }
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
            /*
            var newLaunchable = Launchable.Create(path);
            if (newLaunchable == null) return;

            CompositeLaunchables.Add(newLaunchable);
            SaveLaunchables();
            */
        }

        void SaveLaunchables()
        {
            LaunchableManager.Instance.Save();
        }

        public void DeleteSelectedLaunchable()
        {
            if (SelectedGroup == null) return;

            var selectedLaunchables = LaunchableGroups.Where(x => x.IsSelected == true).ToArray();
            foreach (var launchable in selectedLaunchables)
                LaunchableGroups.Remove(launchable);

            SelectedGroup = null;
            SaveLaunchables();
        }

        public void LaunchSelected()
        {
            /*
            if (SelectedLaunchable == null) return;

            var selectedLaunchables = CompositeLaunchables.Where(x => x.IsSelected == true);
            foreach (var launchable in selectedLaunchables)
                launchable.Launch();
                */
        }
    }
}
