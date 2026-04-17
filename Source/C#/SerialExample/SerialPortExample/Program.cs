using System;
using System.IO.Ports;

namespace SerialPortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // List all the available serial ports
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length == 0)
            {
                Console.WriteLine("No serial ports are available.");
                return;
            }
            Console.WriteLine("Available serial ports:");
            for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, ports[i]);
            }

            if (ports.Length == 0)
            {
                Console.WriteLine("No serial ports are available.");
                return;
            }

            // Prompt the user to select a serial port
            int portIndex;
            using (SerialPort serialPort = new(portName, 9600))
            {
                serialPort.Open();

                // Initialize the angle value
                int angle = 0;

                // Loop until the user presses the Esc key
                while (true)
                {
                    // Check if the user has pressed an arrow key
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                angle -= 1;
                                break;
                            case ConsoleKey.RightArrow:
                                angle += 1;
                                break;
                        }

                        // Print the current angle value
                        Console.WriteLine("Angle: " + angle);

                        // Convert the angle value to a two-digit hexadecimal string
                        string angleHex = angle.ToString("X2");

                        // Send the angle value as a hexadecimal string to the serial port
                        serialPort.Write(angleHex);
                    }

                    // Check if the user has pressed the Esc key
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
            }
            // Loop until the user presses the Esc key
            while (true)
            {
                // Check if the user has pressed an arrow key
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            angle -= 1;
                            break;
                        case ConsoleKey.RightArrow:
                            angle += 1;
                            break;
                    }

                    // Print the current angle value
                    Console.WriteLine("Angle: " + angle);

                    // Convert the angle value to a two-digit hexadecimal string
                    string angleHex = angle.ToString("X2");

                    // Send the angle value as a hexadecimal string to the serial port
                    serialPort.Write(angleHex);
                }

                // Check if the user has pressed the Esc key
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            // Close the serial port
            serialPort.Close();
        }
    }
}
