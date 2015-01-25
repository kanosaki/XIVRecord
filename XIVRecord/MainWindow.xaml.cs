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
using XIVRecord.ViewModels;

namespace XIVRecord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModels.MainWindowViewModel();
            this.DataContext = _viewModel;
            Messenger.Default.Register(this, (Action<NavigatePageMassage>)this.NavigatePage);
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void NavigatePage(NavigatePageMassage msg)
        {
            try
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    this.LinkNavigator.Navigate(msg.Uri, frame);
                    if (msg.DataContext != null)
                    {
                        _viewModel.ContentContext = msg.DataContext;
                    }
                    //this.ContentSource = msg.Uri;
                }));
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage(ex.Message, FirstFloor.ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
            }
        }
    }
}