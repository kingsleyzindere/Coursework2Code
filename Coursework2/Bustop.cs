using System;

namespace Coursework2
{
    class BusStop
    {

        //Create private variables for the bus stop class
        private string name;
        private string streets;
        private double latitude;
        private double longitude;

        //Store the bus stop ID as a public property
        public int Id { get; set; }

        public string Name
        {
            get { return name; } //return the value of the private variable name
            set
            {
                //Check if the name is null or whitespace and throw an exception if it is

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be blank.");

                name = value; // store the value in the private variable
            }
        }

        public string Streets
        {
            get { return streets; } //return the value of the private variable streets
            set
            {

                //Check if the name is null or whitespace and throw an exception if it is

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Streets cannot be blank.");

                streets = value; //store the value in the private variable
            }
        }

        public double Latitude
        {
            get { return latitude; } //return the value of the private variable latitude
            set
            {

                // Check if the latitude is a valid value and throw an exception if it is not

                if ( value < -90 || value > 90)     
                    throw new ArgumentOutOfRangeException(nameof(Latitude));

                latitude = value; //store the value in the private variable
            }
        }

        public double Longitude
        {
            get { return longitude; } //return the value of the private variable longitude

            set
            {

                // Check if the longitude is a valid value and throw an exception if it is not
                if (value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException(nameof(Longitude));

                longitude = value; //store the value in the private variable
            }
        }


        //Constructor for the BusStop class that takes in parameters for the ID, name, streets, latitude, and longitude
        public BusStop(int id, string name, string streets, double latitude, double longitude) 
        {

            // Set the starting values using the property setters.
            Id = id;
            Name = name;
            Streets = streets;
            Latitude = latitude;
            Longitude = longitude;
        }


        // Return the bus stop details as text.
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nStreets: {Streets}\n" +
                   $"Latitude: {Latitude}\nLongitude: {Longitude}";
        }
    }
}