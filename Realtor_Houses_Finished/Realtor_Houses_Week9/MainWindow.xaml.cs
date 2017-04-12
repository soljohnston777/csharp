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
using ClassAttemptLibrary;
using System.IO;
using Microsoft.Win32;


namespace Realtor_Houses_Week9
{

    //Sol Johnston Realty App  Resubmitted
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string sr { get; set; }
        public StreamReader reader;
        public StreamReader textsr;

        private int _countItems;
        public int countItems
        {
            get
            {
                _countItems = Inventory.Distinct().Count();
                return _countItems;
            }

            set
            {
                _countItems = Inventory.Distinct().Count();
                _countItems = value;
            }
        }

        //List object House from reference library (add reference)
        List<House> Inventory = new List<House>();
        public MainWindow()
        {
            InitializeComponent();

            ReadData();// read stream reading data method as a list
                       /*
                       Inventory.Add(new House() { Price = "105000", Address = "789 Burn Street", Zip = "83619", Bedrooms = "1", Bathrooms = "1", Sqft = "885", Year = "1954", HOA = "450" });
                       Inventory.Add(new House() { Price = 425000, Address = "123 Easy Street", Zip = "83619", Bedrooms = 2, Bathrooms = 3, Sqft = 3000, Year = 2011, HOA = 1450 });
                       Inventory.Add(new House() { Price = 415000, Address = "2091 N Merlin Hawk", Zip = "84065", Bedrooms = 3, Bathrooms = 4, Sqft = 2750, Year = 1985, HOA = 650 });
                       Inventory.Add(new House() { Price = 505000, Address = "2900 Yale Lane", Zip = "97914", Bedrooms = 4, Bathrooms = 2, Sqft = 1500, Year = 1812, HOA = 40 });
                       Inventory.Add(new House() { Price = 650000, Address = "2530 Boise Ave", Zip = "90210", Bedrooms = 5, Bathrooms = 3, Sqft = 4200, Year = 2005, HOA = 1125 });
                       Inventory.Add(new House() { Price = 700000, Address = "4152 State Street", Zip = "84065", Bedrooms = 5, Bathrooms = 4, Sqft = 3524, Year = 1979, HOA = 2000 });
                       Inventory.Add(new House() { Price = 210000, Address = "872 West Auburn Street", Zip = "87265", Bedrooms = 6, Bathrooms = 2, Sqft = 1885, Year = 1994, HOA = 1050 });
                       Inventory.Add(new House() { Price = 105000, Address = "216 East 6th Lane", Zip = "83619", Bedrooms = 4, Bathrooms = 2, Sqft = 900, Year = 1938, HOA = 750 });
                       Inventory.Add(new House() { Price = 135000, Address = "678 NE 2nd Ave", Zip = "83619", Bedrooms = 2, Bathrooms = 4, Sqft = 1784, Year = 1956, HOA = 250 });
                       Inventory.Add(new House() { Price = 100000, Address = "485 West Part Circle", Zip = "83619", Bedrooms = 5, Bathrooms = 6, Sqft = 2564, Year = 1984, HOA = 350 });

                       //send to UI for Binding
                       // lvInventory.ItemsSource = Inventory;
                       */
           // textOutput.Text = Convert.ToString(textsr);

            BindHousesToUI(); // used this from your examples

        }


        private void BindHousesToUI() //use a common ground method to keep numbers consistent when counting
        {
            lvInventory.ItemsSource = new List<House>(FilterData(txtFilter.Text));  //thanks for the code would have had a hard time figuring this one out
                                                                                    //  Make text box make results
                                                                                    //int countItems = lvInventory.Items.Count; //Once I figured out that I could count the lvInventory and link it to the text box this made it easy http://www.dotnetperls.com/textbox
                                                                                    //textBox.Text =  countItems + " Results"; // couldn't figure out how to make this work without the "" to keep it a string then data

            //Make label make results
            lbResults.Content = lvInventory.Items.Count + " Results";

        }


        private void MarkAsSold(object sender, RoutedEventArgs e)
        {
            House house = ((sender as Button).DataContext as House);
            var res = MessageBox.Show("Do you want to Sell this House?" + house.Address + "  ", "Sell", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                house.MarkAsSold();
                lvInventory.ItemsSource = new List<House>(FilterData(txtFilter.Text));
                BindHousesToUI(); // goes back to the method to keep the numbers consistent
            }
        }
        private void MarkAsLeased(object sender, RoutedEventArgs e)
        {
            House house = ((sender as Button).DataContext as House);
            var res = MessageBox.Show("Do you want to Lease this House?" + house.Address + "  ", "Leased", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                house.MarkAsLeased();
                lvInventory.ItemsSource = new List<House>(FilterData(txtFilter.Text));
                BindHousesToUI(); // goes back to the method to keep the numbers consistent
            }
        }

        public void btnFilter_Click(object sender, RoutedEventArgs e)
        {

            List<House> filteredList = new List<House>();
            filteredList = FilterData(txtFilter.Text);
            lvInventory.ItemsSource = filteredList;
            lvInventory.ItemsSource = new List<House>(FilterData(txtFilter.Text)); // use FilterData method and get the input from our txtFilter.Text
            BindHousesToUI();// goes back to the method to keep the numbers consistent, in order for this to work had to always use the FilterData(txtFilter.Text)

        }

        private List<House> FilterData(string ziptoFilter)//Found out the hard way that I couldn't use any extra code in here for counting the results.
        {
            List<House> filterdResults = new List<House>();
            foreach (House h in Inventory)//for every value field h from Method House we filled in, we will put into Inventory
            {


                if (((ziptoFilter == string.Empty || (h.Zip.ToString() == ziptoFilter)) && h.IsSold == false)) //if empty for filter values display all data each time around or used filter parameters
                {
                    if (h.IsLeased == false)
                    {
                        filterdResults.Add(h);//add each record individually
                    }
                }

            }

            return filterdResults; //input values base upon filter

        }


        public List<House> ReadData() //a method that is called by ReadDate();   using system.io has to be enabled, because there is no void need a return value - which we want to create a list inventory and put it in
        {

            StreamReader reader = new StreamReader("SecretRealtorFile1.txt");  //read file from c:\... /namespace/debug/bin/file.txt  
            string sr = reader.ReadLine(); //read each character from streamreader from Hex then advance to the next character
            string textsr = reader.ReadLine(); //read each character from streamreader from Hex then advance to the next character

            while (sr != null) // If each character is not empty do this below - skip blank spaces
            {
                char[] delimiter = { ';' }; //convert to character from hex reading from stream reader, have to make it an array of characters, for CSV files you would have each filed separated by ; that's why I chose this = closest to a database
                string[] fields = sr.Split(delimiter); // find the ; and split up the string so it does not see it as only one line (one big string)

               
                sr = reader.ReadLine();  //after each character read the next character.  Peek() doesn't go to the next character
                lvInventory.ItemsSource = Inventory; //have to create the list here after bringing in the values 
                if (fields.Count() == 13) //make a array out of the strings 8 fields total.  The whole text file is a string until we split it up into fields which have no definition until we give it to them.
                {
                    Inventory.Add(new House(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], fields[9], fields[10], fields[11], fields[12])); // I couldn't figure out how to make this an int or ushort, etc, only strings worked
                }
                sr = reader.ReadLine();  //after each character read the next character.  Peek() doesn't go to the next character
                lvInventory.ItemsSource = Inventory; //have to create the list here after bringing in the values 

                //


            }


            return Inventory; // will display the results to our Inventory method from Inventory.Add to the  List<House> Inventory = new List<House>(); originally created

        }



        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    btnFilter_Click(this, new RoutedEventArgs());
                }
            }
            catch
            {
            }


        }
        public static string ParseListView(string ListViewText)
        {
            var regex = new System.Text.RegularExpressions.Regex("{.*?}");
            var match = regex.Match(ListViewText);

            return match.ToString().TrimStart('{').TrimEnd('}');
        }


        public void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try {
                using (StreamWriter outfile = new StreamWriter("File.txt"))
                {

                    foreach (ListViewItem listItem in lvInventory.Items)
                        outfile.WriteLine(ParseListView(listItem.ToString()) + ";");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }


    /*
    // This whole section was to try and test writintg ot a file, but I couldn't figure it quite out yet
    using (StreamWriter outfile = new StreamWriter(lvInventory.ToString()))
        outfile.Write(textOutput.Text);
    using (StreamWriter writer = new StreamWriter("file.txt"))
    {

        // Use string interpolation syntax to make code clearer.
        writer.WriteLine(textOutput.Text);
    }
    */




}


