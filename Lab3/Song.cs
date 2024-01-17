/*
Author: Jay Patel, 000881881
Date: 26/10/2023
Purpose: Lab 3 Part A
I, Jay Patel, 000881881 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/

using System;
namespace Lab3A
{
	public class Song : Media, IEncryptable, ISearchable
	{
        private string Album;
        private string Artist;

        public Song(string title, int year, string album, string artist) : base(title, year)
        {
            Album = album;
            Artist = artist;
        }

        public string Decrypt()
        {
            throw new NotImplementedException();
        }

        public string Encrypt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of Song details.
        /// </summary>
        /// <returns>A formatted string with Song details.</returns>
        public override string ToString()
        {
            // Return a formatted string with Song details
            return ($"{GetType().Name} Title: {Title} ({Year}) \nAlbum: {Album}    Artist: {Artist}");
        }

    }
}

