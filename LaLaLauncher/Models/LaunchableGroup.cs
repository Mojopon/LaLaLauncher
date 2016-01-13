using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLaLauncher.Models
{
    public class LaunchableGroup : ObservableCollection<Launchable>
    {
        public bool? IsSelected { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public Launchable Representative;

        public LaunchableGroup() : base()
        {
            CollectionChanged += (sender, args) => OnCollectionChanged();
        }

        public void UpdateLaunchableInfos()
        {
            if (Count <= 0) return;

            foreach(Launchable item in this)
            {
                item.GetApplicationInfoFromThePath();
            }
        }

        void OnCollectionChanged()
        {
            if (Count <= 0) return;
            ChangeRepresentative(0);
        }
        
        void ChangeRepresentative(int id)
        {
            if (id < 0 || id >= Count) return;

            Representative = this[id];
            Name = Representative.Name;
            Path = Representative.Path;

            Console.WriteLine("Representative changed");
        }
    }
}
