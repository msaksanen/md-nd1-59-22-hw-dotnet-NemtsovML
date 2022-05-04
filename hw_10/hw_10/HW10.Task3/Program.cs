using System;


namespace HW10.Task3
{
    class Program
    {
        static void Main()
        {
            FilmFile[] films = new FilmFile[3];
            films[0] = new FilmFile()
            { Name = "Treasuries", Category = "Adventure", Director = "Johnson", Main_actor = "Smith", Main_actress = "White", Size = 623f };
            films[0].Duration = new TimeSpan(1, 22, 22);

            films[1] = new FilmFile()
            { Name = "Magic Island", Category = "Adventure", Director = "Jackson", Main_actor = "Jones", Main_actress = "Carlyle", Size = 723f };
            films[1].Duration = new TimeSpan(2, 24, 22);

            films[2] = new FilmFile()
            { Name = "Magic box", Category = "Fantasy", Director = "Willis", Main_actor = "Robson", Main_actress = "Willy", Size = 923f };
            films[2].Duration = new TimeSpan(2, 76, 58);

            films[1].Play();
            FilmFile.Play(films[0], films[1]);
            films[2].RetrieveInformation();

            MediaFile.Play(films);

            MusicFile[] songs = new MusicFile[3];

            songs[0] = new MusicFile() { Category = "Rock", Name = "Running", Singer = "Sting", Size = 7.8f };
            songs[0].Duration = new TimeSpan(0, 3, 44);
            songs[0].RetrieveInformation();

            songs[1] = new MusicFile() { Category = "Jazz", Name = "Raining", Singer = "Dales", Size = 8.9f };
            songs[1].Duration = new TimeSpan(0, 2, 40);
            songs[1].RetrieveInformation();

            songs[2] = new MusicFile() { Category = "Pop", Name = "Leaving", Singer = "Jason", Size = 7.3f };
            songs[2].Duration = new TimeSpan(0, 3, 47);
            songs[2].RetrieveInformation();
            MusicFile.Play(songs[0], songs[1]);
            songs[2].Play();
            MediaFile.Play(songs);

            CompProgs[] progs = new CompProgs[3];
            progs[0] = new CompProgs() { Category = "Office", Name = "Acrobat Reader", Size = 12.2f };
            progs[1] = new CompProgs() { Category = "Office", Name = "FOXIT PDF Reader", Size = 7.2f };
            progs[2] = new CompProgs() { Category = "Office", Name = "Sumatra PDF Reader", Size = 2.2f };


            Utility.PrintInfo(songs);
            Utility.PrintInfo(films);
            Utility.PrintInfo(progs);
        }
    }
}