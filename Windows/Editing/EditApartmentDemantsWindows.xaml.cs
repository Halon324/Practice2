﻿using RealEstateProject.Database;
using RealEstateProject.Windows.Demands;
using RealEstateProject.Windows.Estate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RealEstateProject.Windows.Editing
{
    /// <summary>
    /// Логика взаимодействия для EditApartmentDemantsWindows.xaml
    /// </summary>
    public partial class EditApartmentDemantsWindows : Window
    {
        Entities entity = new Entities();
        ApartmentDemands apartmentDemands;
        HouseDemands houseDemands;
        LandDemands landDemands;
        string action;
        int typeOper;
        Regex regex = new Regex("^[0-9]+");
        public EditApartmentDemantsWindows(ApartmentDemands apartmentDemandsInfo, HouseDemands houseDemandsInfo, LandDemands landDemandsInfo, int typeinfo)
        {
            InitializeComponent();
            switch (typeinfo)
            {
               case 0:
                    if (apartmentDemandsInfo != null)
                    {
                        apartmentDemands = apartmentDemandsInfo;
                        this.Title = "Редактирование квартиры";
                        action = "изменена";
                    }
                    else
                    {
                        this.Title = "Добавление квартиры";
                        action = "добавлена";
                    }
                    break;
                case 1:
                    if (houseDemandsInfo != null)
                    {
                        houseDemands = houseDemandsInfo;
                        this.Title = "Редактирование дома";
                        action = "изменена";
                    }
                    else
                    {
                        this.Title = "Добавление дома";
                        action = "добавлена";
                    }
                    break;
                case 2:
                    if (landDemandsInfo != null)
                    {
                        landDemands = landDemandsInfo;
                        this.Title = "Редактирование земли";
                        action = "изменена";
                    }
                    else
                    {
                        this.Title = "Добавление земли";
                        action = "добавлена";
                    }
                    break;

            }
            typeOper = typeinfo;
        }

        private void SaveBttn_Click(object sender, RoutedEventArgs e)
        {
            if (typeOper == 0)
            {
                try
                {
                    CheckTextBoxInput();
                    apartmentDemands.CityId = Convert.ToInt32(cityCB.SelectedValue);
                    apartmentDemands.StreetId = Convert.ToInt32(streetCB.SelectedValue);
                    apartmentDemands.AddressHouse = Convert.ToInt32(addressTB.Text);
                    apartmentDemands.AddressNumber = Convert.ToInt32(addressNumberTB.Text);
                    apartmentDemands.MinPrice = Convert.ToInt32(latitudeTB.Text);
                    apartmentDemands.MaxPrice = Convert.ToInt32(longitudeTB.Text);
                    apartmentDemands.AgentID = Convert.ToInt32(agentCB.SelectedValue);
                    apartmentDemands.ClientId = Convert.ToInt32(clientCB.SelectedValue);
                    apartmentDemands.MinArea = Convert.ToInt32(floorTB.Text);
                    apartmentDemands.MaxArea = Convert.ToInt32(floorMaxTB.Text);
                    apartmentDemands.MinRooms = 0;
                    apartmentDemands.MaxRooms = 0;
                    apartmentDemands.MinFloor = 0;
                    apartmentDemands.MaxFloor = 0;
                    entity.ApartmentDemands.AddOrUpdate(apartmentDemands);
                    entity.SaveChanges();
                    MessageBox.Show($"Квартира успешно {action}", "Уведомление");
                    BackBttn_Click(sender, e);
                }
                catch (Exception error)
                {
                    MessageBox.Show
                   ($"Возникла ошибка при добавлений или изменений квартиры\n{error}"
                        , "Ошибка");
                }
            }
            if (typeOper == 1)
            {
                try
                {
                    CheckTextBoxInput();
                    houseDemands.CityId = Convert.ToInt32(cityCB.SelectedValue);
                    houseDemands.StreetId = Convert.ToInt32(streetCB.SelectedValue);
                    houseDemands.AddressHouse = Convert.ToInt32(addressTB.Text);
                    houseDemands.AddressNumber = Convert.ToInt32(addressNumberTB.Text);
                    houseDemands.MinPrice = Convert.ToInt32(latitudeTB.Text);
                    houseDemands.MaxPrice = Convert.ToInt32(longitudeTB.Text);
                    houseDemands.AgentID = Convert.ToInt32(agentCB.SelectedValue);
                    houseDemands.ClientId = Convert.ToInt32(clientCB.SelectedValue);
                    houseDemands.MinFloor = 0;
                    houseDemands.MaxFloor = 0;
                    houseDemands.MinArea = Convert.ToInt32(floorTB.Text);
                    houseDemands.MaxArea = Convert.ToInt32(floorMaxTB.Text);
                    houseDemands.MinRooms = 0;
                    houseDemands.MaxRooms = 0;
                    entity.HouseDemands.AddOrUpdate(houseDemands);
                    entity.SaveChanges();
                    MessageBox.Show($"Дом успешно {action}", "Уведомление");
                    BackBttn_Click(sender, e);
                }
                catch (Exception error)
                {
                    MessageBox.Show
                   ($"Возникла ошибка при добавлений или изменений дома\n{error}"
                        , "Ошибка");
                }
            }
            if (typeOper == 2)
            {
                try
                {
                    CheckTextBoxInput();
                    landDemands.CityId = Convert.ToInt32(cityCB.SelectedValue);
                    landDemands.StreetId = Convert.ToInt32(streetCB.SelectedValue);
                    landDemands.AddressHouse = Convert.ToInt32(addressTB.Text);
                    landDemands.AddressNumber = Convert.ToInt32(addressNumberTB.Text);
                    landDemands.MinPrice = Convert.ToInt32(latitudeTB.Text);
                    landDemands.MaxPrice = Convert.ToInt32(longitudeTB.Text);
                    landDemands.AgentID = Convert.ToInt32(agentCB.SelectedValue);
                    landDemands.ClientId = Convert.ToInt32(clientCB.SelectedValue);
                    landDemands.MinArea = Convert.ToInt32(floorTB.Text);
                    landDemands.MaxArea = Convert.ToInt32(floorMaxTB.Text);
                    entity.LandDemands.AddOrUpdate(landDemands);
                    entity.SaveChanges();
                    MessageBox.Show($"Земля успешно {action}", "Уведомление");
                    BackBttn_Click(sender, e);
                }
                catch (Exception error)
                {
                    MessageBox.Show
                   ($"Возникла ошибка при добавлений или изменений земли\n{error}"
                        , "Ошибка");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cityCB.ItemsSource = entity.Cities.ToList();
            streetCB.ItemsSource = entity.Streets.ToList();
            agentCB.ItemsSource = entity.Agents.ToList();
            clientCB.ItemsSource = entity.Clients.ToList();
            if (typeOper == 0)
            {
                if (apartmentDemands != null)
                {
                    cityCB.SelectedValue = apartmentDemands.CityId;
                    streetCB.SelectedValue = apartmentDemands.StreetId;
                    addressTB.Text = apartmentDemands.AddressHouse.ToString();
                    addressNumberTB.Text = apartmentDemands.AddressNumber.ToString();
                    latitudeTB.Text = apartmentDemands.MinPrice.ToString();
                    longitudeTB.Text = apartmentDemands.MaxPrice.ToString();
                    agentCB.SelectedValue = apartmentDemands.AgentID;
                    clientCB.SelectedValue = apartmentDemands.ClientId;
                    floorTB.Text = apartmentDemands.MinArea.ToString();
                    floorMaxTB.Text = apartmentDemands.MaxArea.ToString();
                }
                else
                {
                    apartmentDemands = new ApartmentDemands();
                    apartmentDemands.Id = entity.ApartmentDemands.Max(x => x.Id) + 1;
                }
            }
            if (typeOper == 1)
            {
                if (houseDemands != null)
                {
                    cityCB.SelectedValue = houseDemands.CityId;
                    streetCB.SelectedValue = houseDemands.StreetId;
                    addressTB.Text = houseDemands.AddressHouse.ToString();
                    addressNumberTB.Text = houseDemands.AddressNumber.ToString();
                    latitudeTB.Text = houseDemands.MinPrice.ToString();
                    longitudeTB.Text = houseDemands.MaxPrice.ToString();
                    agentCB.SelectedValue = houseDemands.AgentID;
                    clientCB.SelectedValue = houseDemands.ClientId;
                    floorTB.Text = houseDemands.MinArea.ToString();
                    floorMaxTB.Text = houseDemands.MaxArea.ToString();
                }
                else
                {
                    houseDemands = new HouseDemands();
                    houseDemands.Id = entity.HouseDemands.Max(x => x.Id) + 1;
                }
            }
            if (typeOper == 2)
            {
                if (landDemands != null)
                {
                    cityCB.SelectedValue = landDemands.CityId;
                    streetCB.SelectedValue = landDemands.StreetId;
                    addressTB.Text = landDemands.AddressHouse.ToString();
                    addressNumberTB.Text = landDemands.AddressNumber.ToString();
                    latitudeTB.Text = landDemands.MinPrice.ToString();
                    longitudeTB.Text = landDemands.MaxPrice.ToString();
                    agentCB.SelectedValue = landDemands.AgentID;
                    clientCB.SelectedValue = landDemands.ClientId;
                    floorTB.Text = landDemands.MinArea.ToString();
                    floorMaxTB.Text = landDemands.MaxArea.ToString();
                }
                else
                {
                    landDemands = new LandDemands();
                    landDemands.Id = entity.LandDemands.Max(x => x.Id) + 1;
                }
            }

        }
        private void BackBttn_Click(object sender, RoutedEventArgs e)
        {
            var demands = new DemandsWindow();
            demands.Show();
            this.Close();
        }
        private void NumberFilter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !regex.IsMatch(e.Text);
        }
        private void CheckTextBoxInput()
        {
            if (cityCB.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали город!");
                return;
            }
            if (streetCB.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали улицу!");
                return;
            }
            if (addressTB.Text.Length <= 0 && addressTB.Text == "")
            {
                MessageBox.Show("Вы не вписали адрес!");
                return;
            }
            if (addressNumberTB.Text.Length <= 0 && addressNumberTB.Text == "")
            {
                MessageBox.Show("Вы не вписали номер адреса!");
                return;
            }
            if (latitudeTB.Text.Length <= 0 && latitudeTB.Text == "")
            {
                MessageBox.Show("Вы не вписали минимальный прайс!");
                return;
            }
            if (longitudeTB.Text.Length <= 0 && longitudeTB.Text == "")
            {
                MessageBox.Show("Вы не вписали максимальный прайс!");
                return;
            }
            if (agentCB.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали агента!");
                return;
            }
            if (clientCB.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали клиента!");
                return;
            }
            if (floorTB.Text.Length <= 0 && floorTB.Text == "")
            {
                MessageBox.Show("Вы не вписали минимальную область!");
                return;
            }
            if (floorMaxTB.Text.Length <= 0 && floorTB.Text == "")
            {
                MessageBox.Show("Вы не вписали максимальную область!");
                return;
            }
        }
    }
}
