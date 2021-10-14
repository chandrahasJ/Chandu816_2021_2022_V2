using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleTraderApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : UserControl
    {


        public ICommand SelectedAssetsChangeCommand
        {
            get { return (ICommand)GetValue(SelectedAssetsChangeCommandProperty); }
            set { SetValue(SelectedAssetsChangeCommandProperty, value); }
        } 

        public static readonly DependencyProperty SelectedAssetsChangeCommandProperty =
            DependencyProperty.Register("SelectedAssetsChangeCommand", typeof(ICommand), typeof(SellView), new PropertyMetadata(null));


        public SellView()
        {
            InitializeComponent();
        }

        private void cbAssests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbAssests.SelectedItem != null)
            {
                if (SelectedAssetsChangeCommand.CanExecute(null))
                {
                    SelectedAssetsChangeCommand?.Execute(null);
                }
            }
                
        }
    }
}
