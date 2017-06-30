using System;
using System.Collections.Generic;
using OnlineRadioDatabase.Exceptions;

namespace OnlineRadioDatabase
{
    class OnlineRadioDatabaseExecution
    {
        static void Main()
        {
            var numberOfSongsForAdding = int.Parse(Console.ReadLine());
            var songs = new List<Song>();
            AddSongs(songs, numberOfSongsForAdding);

            PrintAnswer(songs);
        }

        private static void PrintAnswer(List<Song> songs)
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            int counterOfSeconds = CalculateTotalSecondsInPlaylist(songs);

            int seconds = counterOfSeconds % 60;
            int minutes = (counterOfSeconds / 60) % 60;
            int hours = counterOfSeconds / 3600;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }

        private static int CalculateTotalSecondsInPlaylist(List<Song> songs)
        {
            int counterOfSeconds = 0;
            foreach (var song in songs)
            {
                counterOfSeconds += song.Minutes * 60 + song.Seconds;
            }

            return counterOfSeconds;
        }

        private static void AddSongs(List<Song> songs, int numberOfSongsForAdding)
        {
            for (int i = 0; i < numberOfSongsForAdding; i++)
            {
                var inputSongInfo = Console.ReadLine().Split(';');
                var artistName = inputSongInfo[0];
                var songName = inputSongInfo[1];
                var time = inputSongInfo[2].Split(':');
                var minutes = int.Parse(time[0]);
                var seconds = int.Parse(time[1]);
                try
                {
                    var song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);

                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
