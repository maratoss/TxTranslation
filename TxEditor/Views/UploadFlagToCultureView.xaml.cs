namespace Unclassified.TxEditor.Views
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using Microsoft.Win32;

    using Unclassified.TxEditor.ViewModels;

    public partial class UploadFlagToCultureView : UserControl
    {
        public UploadFlagToCultureView()
        {
            this.InitializeComponent();
        }

        private void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            return;
            //if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Any() && this.DataContext as UploadFlagToCultureViewModel != null)
                {
                    ((UploadFlagToCultureViewModel)this.DataContext).SelectedFlagSrc = files[0];
                    if (((UploadFlagToCultureViewModel)this.DataContext).UploadFlagCommand.CanExecute(null))
                    {
                        ((UploadFlagToCultureViewModel)this.DataContext).UploadFlagCommand.Execute(null);
                    }
                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "image file (.png)|*.png" };
            var result = dlg.ShowDialog();

            if (result == true && this.DataContext as UploadFlagToCultureViewModel != null)
            {
                ((UploadFlagToCultureViewModel)this.DataContext).SelectedFlagSrc = dlg.FileName;
                if (((UploadFlagToCultureViewModel)this.DataContext).UploadFlagCommand.CanExecute(null))
                {
                    ((UploadFlagToCultureViewModel)this.DataContext).UploadFlagCommand.Execute(null);
                }
            }
        }
    }
}
