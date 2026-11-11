using System;
using System.Collections.Generic;

namespace Coursework2
{

    //Create a class for the postcode
    class PostCode 
    {

        //Create private variables for the postcode class
        private string id = string.Empty;
        private int households;
        private string roads = string.Empty;
        private double latitude;
        private double longitude;


        //Store the postcode ID as a public property
        public string Id 
        {
            get { return id; }  //return the value of the private variable id

            set
            {
                //Check if the postcode ID is null or whitespace and throw an exception if it is

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Id cannot be blank.");

                id = value; //store the value in the private variable
            }
        }

        //Store the number of households as a public property
        public int Households
        {
            get { return households; }   //return the value of the private variable households
            set
            {

                //check if the number of households is less than 0 or greater than 100 and throw an exception if it is
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Households));

                households = value; //store the value in the private variable
            }
        }


        //Store the roads as a public property
        public string Roads 
        {
            get { return roads; } //return the value of the private variable roads

            set
            {
                //Check if the roads is null or whitespace and throw an exception if it is

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Roads cannot be blank.");

                roads = value; //store the value in the private variable
            }
        }

        //Store the latitude as a public property
        public double Latitude
        {
            get { return latitude; } //return the value of the private variable latitude
            set
            {
                if (double.IsNaN(value) || value < -90 || value > 90)  //Check if the latitude is a valid value and throw an exception if it is not
                    throw new ArgumentOutOfRangeException(nameof(Latitude));

                latitude = value; //store the value in the private variable
            }
        }

        //Store the longitude as a public property
        public double Longitude
        {
            get { return longitude; } //return the value of the private variable longitude

            set
            {
                //Check if the longitude is a valid value and throw an exception if it is not

                if (double.IsNaN(value) || value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException(nameof(Longitude));

                longitude = value; //store the value in the private variable
            }
        }

        //Create a list of bus stops for the postcode
        public List<BusStop> BusStops { get; } = new List<BusStop>();

        //Constructor for the PostCode class that takes in parameters for the ID, number of households, roads, latitude, and longitude
        public PostCode(string id, int households, string roads, double latitude, double longitude)
        {
            // Set the starting values using the property setters.
            Id = id;
            Households = households;
            Roads = roads;
            Latitude = latitude;
            Longitude = longitude;
        }


        // Return the postcode details as text. 
        public override string ToString()
        {
            return $"Id: {Id}\nHouseholds: {Households}\nRoads: {Roads}\n" +
                   $"Latitude: {Latitude}\nLongitude: {Longitude}";
        }
    }
}