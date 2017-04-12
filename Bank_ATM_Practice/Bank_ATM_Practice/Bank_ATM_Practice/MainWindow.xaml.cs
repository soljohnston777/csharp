using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Drawing;

namespace Bank_ATM_Practice
{
    //Sol Johnston Bank ATM Week 6
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // public double Total { get; set; }
       // delegate int Total()

        public MainWindow()
        {
            InitializeComponent();
            //if (textTotal.Text != null)
            // {
            soundElement1.Source = new Uri("Kalimba.mp3", UriKind.RelativeOrAbsolute); 
            soundElement1.Play();
            mediaElement1.Source= new Uri("duckseasonrabbitseason.gif", UriKind.RelativeOrAbsolute);
            mediaElement1.Play();

            double AccountBalance = 1500;
                

            //WithdrawalAmount = Convert.ToDouble(textInput.Text);
            //WithdrawalAmount = Convert.ToInt32(textInput.Text);

                textTotal.Text = ("Total amount" + Convert.ToString(AccountBalance));
                textCurrentBalance.Text = "" + Convert.ToString(AccountBalance);

            //  }
        }
       
        //double AccountBalance = 1500;
        // public Double AccountBalance { get; set; }
        private Double _AccountBalance;
        public Double AccountBalance
        {
            get
            {
                _AccountBalance = 1500.00;
                return _AccountBalance;
            }

            set
            {
                _AccountBalance = 1500.00;
                _AccountBalance = value;
            }
        }

        // public Double Total { get; set; }
       

        private void WithdrawFunds_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
                double WithdrawalAmount;
                WithdrawalAmount = double.Parse(textInput.Text);
                Double MaxWithdrawalAmount = 0;
                textCurrentBalance.Text = "" + Convert.ToString(AccountBalance);
                //  bool ok = false;
                for (MaxWithdrawalAmount = 0; MaxWithdrawalAmount <= 500; MaxWithdrawalAmount += 20)
                {
                    if (WithdrawalAmount == MaxWithdrawalAmount)
                    {
                        double Total = (AccountBalance - WithdrawalAmount);
                        // double Total = (AccountBalance - WithdrawalAmount);
                        textError.Text = ("Thank you for your transaction with Wimble CO Bank");
                        textTotal.Text = "$" + Convert.ToString(Total);
                        mediaElement1.Source = new Uri("moneytoburn.gif", UriKind.RelativeOrAbsolute);
                        mediaElement1.Play();
                        // ok = true;
                        break;
                    }
                    else if (WithdrawalAmount != MaxWithdrawalAmount)
                    {
                        double Total = (AccountBalance);
                        textError.Text = ("Only Increments of $20 allowed for Withdrawals up to $500");
                        textTotal.Text = "$" + Convert.ToString(Total);
                        mediaElement1.Source = new Uri("airbirdtree.gif", UriKind.RelativeOrAbsolute);
                        mediaElement1.Play();

                    }
                    /*               if (!ok)
                                   {
                                       for (MaxWithdrawalAmount = 0; MaxWithdrawalAmount <= 500; MaxWithdrawalAmount += 20)
                                       if (WithdrawalAmount != MaxWithdrawalAmount)
                                       {
                                           textError.Text = ("Only Increments of $20 allowed for withdraw up to $500");
                                           textTotal.Text = "Total amount $" + Convert.ToString(Total);
                                           //ok = true;
                                           //break;

                                           //textError.Text = ("Only Increments of $20 allowed for withdraw up to $500");
                                           //textTotal.Text = ("" + AccountBalance);
                                       }
                                   }
                                   */
                }
            }
            catch
            {
                textError.Text = ("Input Error - Try increments of $20 up to $500");
                textTotal.Text = ("" + AccountBalance);
                mediaElement1.Source = new Uri("coffee.gif", UriKind.RelativeOrAbsolute);
                mediaElement1.Play();

            }
        }
    }
 }
