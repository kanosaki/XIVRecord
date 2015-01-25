using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace XIVRecord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.MainViewModel();
            Messenger.Default.Register(this, (Action<NavigatePageMassage>)this.NavigatePage);
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void NavigatePage(NavigatePageMassage msg)
        {
            try
            {
                this.ContentSource = msg.Uri;
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage(ex.Message, FirstFloor.ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
            }
        }
    }
}