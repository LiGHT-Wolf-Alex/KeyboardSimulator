using Keyboard_simulator.AdditionalСlass;
using Keyboard_simulator.AdditionalСlass.Menu;
using Print_Simulator;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Keyboard_simulator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LVl1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChosenLesson.Text = LessonLevel.Name(((Border)sender).Name);
            MenuLVL1.Visibility = Visibility.Collapsed;
            MenuLVL2.Visibility = Visibility.Visible;
        }
        private void gif_MediaEnded(object sender, RoutedEventArgs e)
        {
            gif.Position = new TimeSpan(0, 0, 1);
            gif.Play();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            NumberTextBox.Text = NumberTextBox.Text.Replace(" ", "");
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NumberTextBox.Text = NumberTextBox.Text.Replace(" ", "");
            if (NumberTextBox.Text == "") NumberTextBox.Text = "0";
            int a = int.Parse(NumberTextBox.Text);
            if (--a <= 0)
                NumberTextBox.Text = "0";
            else NumberTextBox.Text = (--a).ToString();
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            NumberTextBox.Text = NumberTextBox.Text.Replace(" ", "");
            if (NumberTextBox.Text == "") NumberTextBox.Text = "0";
            int a = int.Parse(NumberTextBox.Text);
            NumberTextBox.Text = (++a).ToString();
        }

        private void TextBlock_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (sound.Text == " Включен")
            {
                sound.Foreground = new SolidColorBrush(Color.FromRgb(255, 115, 115));
                sound.Text = " Выключен";
                DynamicData.Sound = false;
            }
            else
            {
                sound.Foreground = new SolidColorBrush(Color.FromRgb(168, 255, 189));
                sound.Text = " Включен";
                DynamicData.Sound = true;
            }
        }

        private void LeaveButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuLVL1.Visibility = Visibility.Visible;
            MenuLVL2.Visibility = Visibility.Collapsed;
            NumberTextBox.Text = "0";
        }

        private void StartButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (NumberTextBox.Text.Replace(" ", "") != "" && NumberTextBox.Text.Replace(" ", "") != "0")
            {
                DynamicData.NumberOfCharacters = Int32.Parse(NumberTextBox.Text.Replace(" ", ""));
                Text_Output TextGeneric = new Text_Output();
                TextGeneric.TextGeneration();
                KeyboardSimulator keyboardSimulator = new KeyboardSimulator();
                WindowMeny.Visibility = Visibility.Visible;
                keyboardSimulator.Show();
                DynamicData.windowState = this.WindowState;
                this.Close();
            }
        }
    }
}