using System;
using System.Collections.Generic;
using System.Windows;

namespace Coursework2
{
    public partial class MainWindow : Window


    {
        //create a list of postcodes and bus stops
        List<PostCode> postcodes = new List<PostCode>();
         List<BusStop> busStops = new List<BusStop>();


        public MainWindow()
        {

            InitializeComponent();
        }

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {

            //declare our variables for two sets of coordinates for the distance calculation
            double lat1 = 55.952468;
            double lon1 = -3.200373;
            double lat2 = 55.952997;
            double lon2 = -3.188722;

            //calculate and display the distance between the two sets of coordinates

            double distance = Distance.DistanceKM(lat1, lon1, lat2, lon2);
            txtOut.Text = "Distance " + distance + "\n\n";

            //read the CSV file 
            CSVReader reader = new CSVReader("EH1postcodes.csv");
            List<string[]> rows = reader.ReadFile();


            //display each row of the CSV file in the output text box
            foreach (string[] row in rows)
            {
                txtOut.Text += $"{row[0]} | {row[1]} | {row[2]} | {row[3]} | {row[4]}\n";
            }
        }




        private void btnFindPostcode_Click(object sender, RoutedEventArgs e)

        {
            //the text entered into the postcode text box is stored in a variable
            string storedPostcode = txtPostCode.Text;

            //searches through the list of postcodes to find a match for the postcode entered in the text box
            foreach (PostCode postcode in postcodes)
            {
                if (postcode.Id == storedPostcode)
                {
                    txtOut.Text = postcode.ToString(); 
                    txtOut.Text += "\n\nLinked stops: " + postcode.BusStops.Count;


                    //Displays the linked bus stops for the postcode found in the output text box
                    foreach (BusStop stop in postcode.BusStops)
                    {
                        txtOut.Text += "\n" + stop.ToString();
                    }
                    //found the postcode, so we can exit the method 
                    return;
                }
            }
            //if the postcode is not found, display a message in the output text box
            txtOut.Text = "Postcode not found";
        }




        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {

            //Read the CSV files  for postcodes
            CSVReader postcodeReader = new CSVReader("EH1postcodes.csv");
            List<string[]> postcodeRows = postcodeReader.ReadFile();

            //Read the CSV files  for bus stops

            CSVReader stopReader = new CSVReader("Stops.csv");
            List<string[]> stopRows = stopReader.ReadFile();

            //Clears the list of postcodes before loading new data
            postcodes.Clear();

            //Creates a new PostCode object for each row in the postcode CSV file 
            foreach (string[] row in postcodeRows)
            {
                PostCode postcode = new PostCode(row[0], int.Parse(row[3]), row[4], double.Parse(row[1]),double.Parse(row[2]));


                //Adds the PostCode object to the list of postcodes
                postcodes.Add(postcode);
            }

            //Removes any existing bus stops from the list before loading new data
            busStops.Clear();

            // Creates a new BusStop object for each row in the bus stop CSV file
            foreach (string[] row in stopRows)
            {
                BusStop stop = new BusStop(int.Parse(row[0]), row[1], row[2],double.Parse(row[4]),double.Parse(row[3])
                );

                // Adds the bus stop to the list.
                busStops.Add(stop);
            }

            // Use an if statement and random number generator to link bus stops to postcodes. Each postcode will be linked to a random bus stop from the list of bus stops.
            if (busStops.Count > 0)
            {
                Random random = new Random();

                // Give each postcode one randomly selected bus stop.

                foreach (PostCode postcode in postcodes) //Goes through every postcode in my list
                {
                    int stopIndex = random.Next(busStops.Count);  //Generates a random position in the bus stop list. and whereever it stops is whats added to the postcode 
                    postcode.BusStops.Add(busStops[stopIndex]);
                }
            }

            // Display the number of postcodes and bus stops loaded in the output text box
            txtOut.Text = "Postcodes loaded: " + postcodes.Count;
            txtOut.Text += "\nBus stops loaded: " + busStops.Count;
        }
    }
}