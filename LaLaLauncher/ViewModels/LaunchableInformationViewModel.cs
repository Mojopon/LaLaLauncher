using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using LaLaLauncher.Models;

namespace LaLaLauncher.ViewModels
{
    public class LaunchableInformationViewModel : ViewModel
    {
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


        public LaunchableInformationViewModel(Launchable selectedLaunchable)
        {
            SelectedLaunchable = selectedLaunchable;
            if (selectedLaunchable != null)
                Console.WriteLine(selectedLaunchable.Name);
        }

        public LaunchableInformationViewModel()
        {
            SelectedLaunchable = null;
        }

        public void Initialize()
        {
        }
    }
}
