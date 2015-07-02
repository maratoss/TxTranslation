namespace Unclassified.TxEditor.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;

    using Unclassified.TxEditor.Managers;
    using Unclassified.UI;

    internal class UploadFlagToCultureViewModel : INotifyPropertyChanged
    {
        private readonly FlagLoader flagLoader;

        private readonly HashSet<string> cultureNames;

        private string selectedCulture;

        private string selectedFlagSrc;

        public UploadFlagToCultureViewModel(FlagLoader flagLoader, HashSet<string> cultureNames)
        {
            this.flagLoader = flagLoader;
            this.cultureNames = cultureNames;
            this.UploadFlagCommand = new DelegateCommand(this.UploadFlag);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedFlagSrc
        {
            get
            {
                return this.selectedFlagSrc;
            }
            set
            {
                this.selectedFlagSrc = value;
                this.OnPropertyChanged("SelectedFlagSrc");
            }
        }

        public string SelectedCulture
        {
            get
            {
                return this.selectedCulture;
            }
            set
            {
                this.selectedCulture = value;
                this.OnPropertyChanged("SelectedCulture");

                this.LoadFlag();
            }
        }

        public ICommand UploadFlagCommand { get; private set; }

        public IList<string> AvaiableCulture
        {
            get { return this.cultureNames.ToList(); }
        }

        private void LoadFlag()
        {
            if (!string.IsNullOrWhiteSpace(this.SelectedCulture) && this.flagLoader.IsExist(this.SelectedCulture))
            {
                this.SelectedFlagSrc = this.flagLoader.GetFullPathToImage(this.SelectedCulture);
            }
            else
            {
                this.SelectedFlagSrc = null;
            }
        }

        private void UploadFlag()
        {
            if (!string.IsNullOrWhiteSpace(this.SelectedFlagSrc) && !string.IsNullOrWhiteSpace(this.selectedCulture))
            {
                this.flagLoader.Upload(this.SelectedCulture, this.SelectedFlagSrc, true);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}