using System;
using System.Collections.Generic;
using System.IO;

public class CSVReader
{

    //Create a private variable to store the file path
    private string filePath;


    //Constructor for the CSVReader class that takes in a file path as a parameter
    public CSVReader(string filePath)
    {
        this.filePath = filePath;
    }

    // Method to read the CSV file and return a list of string arrays
    public List<string[]> ReadFile()


    {   //  The first line of the CSV file is assumed to be a header and will be skipped
        // Create a list to store the data from the CSV file
        var header = true;
        List<string[]> data = new List<string[]>();

        try
        {
            // Open the file 
            using (StreamReader reader = new StreamReader(filePath))
            {

                // Keep reading until the end of the file.

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    //skip the header line and split the line into an array of 5  values, then add it to the list
                    if (!header)
                    {
                        string[] values = line.Split(',', 5);
                        // Remove quotes around the last field.
                        values[4] = values[4].Trim('"');
                        //add row to the list of data
                        data.Add(values);
                    }
                    header = false;
                }
            }
        }
        catch (Exception ex)
        {
            // Write an error message if reading fails.

            Console.WriteLine("Error reading CSV file: " + ex.Message);
        }

        // Return the rows that were loaded.
        return data;
    }
}
