using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using week_5_PD.bl;

namespace week_5_PD
{
    class Program
    {
        string filename = "C:\\Users\\USER\\source\\repos\\week 5 PD\\ships.txt";
        List<ship> ships = new List<ship>();
        static void Main(string[] args)
        {
            menu();
            Console.Write("\nEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddShip();
                    break;
                case 2:
                    ViewShipPosition();
                    break;
                case 3:
                    ViewShipSerialNumber();
                    break;
                case 4:
                    ChangeShipPosition();
                    break;
                case 5:
                    break;
                    return;
                default:
                    Console.WriteLine("\nInvalid choice! Try again.");
                    break;
            }
        }
        public static int menu()
        {
            int choice;
            do
            {
                Console.WriteLine("Press 1 to add ship : ");
                Console.WriteLine("Press 2 to view ship position : ");
                Console.WriteLine("Press 3 to view ship serial number : ");
                Console.WriteLine("Press 4 to change ship position : ");
                Console.WriteLine("Press 5 to exit : ");
                Console.WriteLine("Enter choice : ");
                choice = int.Parse(Console.ReadLine());
            }
            while (choice < 6);
            return choice;
        }
        static void AddShip()
        {
            Console.Write("\nEnter ship's number: ");
            string number = Console.ReadLine();

            Console.Write("\nEnter ship's latitude (in format 12°34.5' N): ");
            angle latitude = Parseangle(Console.ReadLine());

            Console.Write("\nEnter ship's longitude (in format 123°45.6' W): ");
            angle longitude = ParseAngle(Console.ReadLine());

            ship shipe = new ship(number, latitude, longitude);
            ships.Add(shipe);

            Console.WriteLine($"\nShip {number} added successfully.");
        }

        static void ViewShipPosition()
        {
            Console.Write("\nEnter ship's number: ");
            string number = Console.ReadLine();

            ship ships = FindShipByNumber(number);

            if (ships != null)
            {
                Console.WriteLine($"\nShip {number} position is {ship.GetPositionString()}.");
            }
            else
            {
                Console.WriteLine($"\nShip {number} not found!");
            }
        }
        public static void LoadShipsFromFile()
        {
            string filename = "C:\\Users\\USER\\source\\repos\\week 5 PD\\ships.txt";

            // Load ships from file
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        string serial = reader.ReadLine();
                        int latDeg = int.Parse(reader.ReadLine());
                        float latMin = float.Parse(reader.ReadLine());
                        char latDir = char.Parse(reader.ReadLine());
                        int lonDeg = int.Parse(reader.ReadLine());
                        float lonMin = float.Parse(reader.ReadLine());
                        char lonDir = char.Parse(reader.ReadLine());

                        angle lat = new angle(latDeg, latMin, latDir);
                        angle lon = new angle(lonDeg, lonMin, lonDir);
                        ship ships = new ship(serial, lat, lon);

                        ships.Add(ships);
                    }
                }
            }
        }
        static void ViewShipSerialNumber()
        {
            Console.WriteLine("Enter the ship's latitude (e.g. 17°31.5' S):");
            angle latitude = angle.FromString(Console.ReadLine());

            Console.WriteLine("Enter the ship's longitude (e.g. 149°34.8' W):");
            angle longitude = angle.FromString(Console.ReadLine());

            ship ships = FindShipByPosition(latitude, longitude);
            if (ships == null)
            {
                Console.WriteLine("Ship not found.");
            }
            else
            {
                Console.WriteLine($"The ship at {latitude} {longitude} has serial number {ships.Number}");
            }
        }
        public void ChangeShipPosition()
        {
            Console.WriteLine("Enter the new latitude value (in degrees, minutes, direction):");
            float latDeg;
            float latMin;
            char latDir;
            Console.Write("Degrees: ");
            while (!float.TryParse(Console.ReadLine(), out latDeg))
            {
                Console.WriteLine("Invalid input. Please enter a valid float value for degrees:");
                Console.Write("Degrees: ");
            }
            Console.Write("Minutes: ");
            while (!float.TryParse(Console.ReadLine(), out latMin))
            {
                Console.WriteLine("Invalid input. Please enter a valid float value for minutes:");
                Console.Write("Minutes: ");
            }
            Console.Write("Direction (N, S): ");
            while (!char.TryParse(Console.ReadLine().ToUpper(), out latDir) || (latDir != 'N' && latDir != 'S'))
            {
                Console.WriteLine("Invalid input. Please enter a valid direction (N or S):");
                Console.Write("Direction (N, S): ");
            }
            this.latitude.changeangle(latDeg, latMin, latDir);

            Console.WriteLine("Enter the new longitude value (in degrees, minutes, direction):");
            float lonDeg;
            float lonMin;
            char lonDir;
            Console.Write("Degrees: ");
            while (!float.TryParse(Console.ReadLine(), out lonDeg))
            {
                Console.WriteLine("Invalid input. Please enter a valid float value for degrees:");
                Console.Write("Degrees: ");
            }
            Console.Write("Minutes: ");
            while (!float.TryParse(Console.ReadLine(), out lonMin))
            {
                Console.WriteLine("Invalid input. Please enter a valid float value for minutes:");
                Console.Write("Minutes: ");
            }
            Console.Write("Direction (E, W): ");
            while (!char.TryParse(Console.ReadLine().ToUpper(), out lonDir) || (lonDir != 'E' && lonDir != 'W'))
            {
                Console.WriteLine("Invalid input. Please enter a valid direction (E or W):");
                Console.Write("Direction (E, W): ");
            }
            this.longitude.changeAngle(lonDeg, lonMin, lonDir);

            Console.WriteLine("Ship's position has been updated to:");
            Console.WriteLine($"Latitude: {this.latitude}");
            Console.WriteLine($"Longitude: {this.longitude}");
        }

    }
}