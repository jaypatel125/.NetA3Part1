/*
Author: Jay Patel, 000881881
Date: 26/10/2023
Purpose: Lab 3 Part A
I, Jay Patel, 000881881 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/

using System;
using System.IO;

namespace Lab3A
{
	public class Book : Media, IEncryptable, ISearchable
	{
        private string Author;
        private string Summary;

        public Book(string title, int year, string author, string summary) : base(title, year)
		{
            Author = author;
            Summary = summary;
		}

        /// <summary>
        /// Decrypts the summary of the book using ROT13 algorithm.
        /// </summary>
        /// <returns>Decrypted summary of the book.</returns>
        public string Decrypt()
        {
            char[] inputArray = Summary.ToCharArray();

            // Apply ROT13 algorithm for decryption
            for (int i = 0; i < inputArray.Length; i++)
            {
                // For uppercase letters
                if (char.IsUpper(inputArray[i]))
                {
                    inputArray[i] = (char)(((inputArray[i] - 'A' + 13) % 26) + 'A');
                }
                // For lowercase letters
                else if (char.IsLower(inputArray[i]))
                {
                    inputArray[i] = (char)(((inputArray[i] - 'a' + 13) % 26) + 'a');
                }
            }

            return new string(inputArray);
        }

        public string Encrypt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of Book details.
        /// </summary>
        /// <returns>A formatted string with Book details.</returns>
        public override string ToString()
        {
            // Return a formatted string with Book details
            return ($"{GetType().Name} Title: {Title} ({Year}) \nAuthor: {Author}");
        }
    }
}

