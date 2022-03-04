using System;

namespace HW._03.Image
{
    using System; //Contains types that allow reading and writing to files and data streams.
    using System.IO;
    class Program
    {
        static void Main()
        {
            StreamReader textReader = new StreamReader(@"D:\image.txt", true); //Opens a stream for file reading from the path, detects encoding.
            string textReaderResult = textReader.ReadToEnd(); // Assigns all characters from the file stream till the end of file.
            string[] arrayOfTextResult = textReaderResult.Split(' ');//Splits a string into substrings with spaces and assigns substrings to the array.
            textReader.Dispose(); //Realeses all resources used by TextReader.
            byte[] imageBytes = new byte[arrayOfTextResult.Length - 1]; //Creates a new byte array. Total number of elements of the array is equal to those of arrayOfTextResult.
            for (int i = 0; i < arrayOfTextResult.Length - 1; i++) //The cycle runs until counter "i" is less than total number of elements of the array.
            {
               
                byte binary = Convert.ToByte(arrayOfTextResult[i], 2); //Converts string elements of the arrayOfTextResult to binary integer numbers. 
                imageBytes[i] = binary; //Assigns binary elements to imageBytes array elements.   
            }
            File.WriteAllBytes(@"D:\image.png", imageBytes);//Creates a file, writes ImageBytes array to the file, and then cloess it.
            Console.WriteLine("The file is converted. Open the image.");
            Console.ReadKey();
        }
    }
}
