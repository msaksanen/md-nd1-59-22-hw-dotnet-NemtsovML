using System;

namespace HW10.Task3
{
    public class File
    {
        public string Name { get; set; }

        public string Code { get; set; } = Guid.NewGuid().ToString();


        public string Category { get; set; }

        public float Size { get; set; }
    }

    public class MediaFile : File
    {
        public TimeSpan Duration { get; set; } = new TimeSpan();

        public static void Play(MediaFile[] Files)
        {
            Console.WriteLine($"Playing all media files of {Files.GetType().Name} type.");

            foreach (var file in Files)
            {
                Console.WriteLine($"File name: {file.Name}. File category: {file.Category}. Duration: {file.Duration:T}.");
            }
        }

        public virtual void RetrieveInformation()
        {
            Console.WriteLine($"File info. File name: {Name}. File category: {Category}. File size: {Size} MB. File code: {Code}.");
        }
    }

    public class MusicFile : MediaFile
    {
        public string Singer { get; set; }

        public MusicFile()
        {
            Name = "music.mp3";
            Category = "music";
            Size = 0;
        }

        public override void RetrieveInformation()
        {
            base.RetrieveInformation();
            Console.WriteLine($"Mediafile type: {this.GetType().Name}. Singer : {Singer}. Duration: {Duration.TotalSeconds} sec.");
        }

        public void Play()
        {
            Console.WriteLine($"Playing single audio file: {Name}. Duration is {Duration.TotalSeconds} sec.");
        }

        public static void Play(params  MusicFile[] files)
        {
            foreach (MusicFile file in files)
            {
                Console.WriteLine($"Playing audio files: {file.Name}. Duration is {file.Duration.TotalSeconds} sec.");
            }
            
        }
    }

    public class FilmFile : MediaFile
    {
        public string Director { get; set; }

        public string Main_actor { get; set; }

        public string Main_actress { get; set; }

        public FilmFile()
        {
            Name = "film.avi";
            Category = "film";
            Size = 0;
        }

        public override void RetrieveInformation()
        {
            base.RetrieveInformation();
            Console.WriteLine($"Mediafile type: {this.GetType().Name}. Main actor: {Main_actor}. Main actress: {Main_actress}. Duration: {Duration.TotalMinutes} min. ");
        }

        public void Play()
        {
            Console.WriteLine($"Playing single video file: {Name}. Duration is {Duration:T}.");
        }
        public static void Play(params FilmFile[] files)
        {
            foreach (FilmFile file in files)
            {
                Console.WriteLine($"Playing video files: {file.Name}. Duration is {file.Duration:T}.");
            }

        }
    }

    public class CompProgs : File
    {
        public CompProgs()
        {
            Name = "program.exe";
            Category = "program";
            Size = 0;
        }
    }

    public class Utility
    {
        public static void PrintInfo(params File[] Files)
        {
            Console.WriteLine("Summary about files.");

            foreach (var file in Files)
            {
                Console.WriteLine($"{file.GetType().Name}: { file.Name}. File category: {file.Category}. File code: {file.Code}. File size: {file.Size} MB.");
            }
        }
    }
}