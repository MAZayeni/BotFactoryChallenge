
using Common.Interface;
using Common.Tools;
using Factories;
using BotFactory.Tools;
using System;
using System.Windows.Controls;
using System.Windows;
using Models;

namespace BotFactory.Pages
{
    /// <summary>
    /// Interaction logic for FactoryTest.xaml
    /// </summary>
    public partial class FactoryTest : Page
    {
        FactoryDataContext _dataContext = new FactoryDataContext();
        UnitTest _unitTestPage;

        public FactoryTest()
        {
            InitializeComponent();
            DataContext = _dataContext;
        }

        public void SetTestingFactory(UnitFactory factory)
        {
            _dataContext.Builder = factory;
            _dataContext.Builder.FactoryStatus += Builder_FactoryProgress;
        }
        private void Builder_FactoryProgress(object sender, System.EventArgs e)
        {
            _dataContext.ForceUpdate();
        }
        private void AddUnitToQueue_Click(object sender, RoutedEventArgs e)
        {
            if (ModelsList.SelectedIndex >= 0 && !string.IsNullOrEmpty(UnitName.Text))
            {
                Type item = (Type)ModelsList.SelectedItem;
                string name = UnitName.Text;
                WorkingUnit instance = (WorkingUnit)Activator.CreateInstance(item);
                MessageBoxResult result = MessageBox.Show("vous avez choisi de construire le robot " + item.Name + " qui a pour temps de construction " + instance.BuildTime + " secondes, Etes vous sur de construire ce robot","Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _dataContext.Builder.AddWorkableUnitToQueue(item, name, new Coordinates(0, 0), new Coordinates(10, 10));
                    _dataContext.ForceUpdate();
                }
                
            }
        }
        private void UpdateButtonValidity()
        {
            AddUnitToQueue.IsEnabled = ModelsList.SelectedIndex >= 0 && !string.IsNullOrEmpty(UnitName.Text);
        }

        private void UnitName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateButtonValidity();
        }

        private void ModelsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonValidity();
        }

        private void StorageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StorageList.SelectedIndex >= 0)
            {
                if (_unitTestPage == null)
                {
                    _unitTestPage = new UnitTest();
                    _unitTestPage.SetUnitToTest((ITestingUnit)StorageList.SelectedItem);
                    UnitFrame.Navigate(_unitTestPage);
                }
                else
                {
                    _unitTestPage.SetUnitToTest((ITestingUnit)StorageList.SelectedItem);
                }
            }
        }
    }
}
