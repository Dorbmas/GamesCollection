//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamesCollection.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            this.GamesDevelopers = new HashSet<GamesDevelopers>();
            this.GamesGenres = new HashSet<GamesGenres>();
            this.GamesPlatforms = new HashSet<GamesPlatforms>();
            this.GamesPublishers = new HashSet<GamesPublishers>();
            this.UsersGames = new HashSet<UsersGames>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int YearOfIssue { get; set; }
        public string YearOfIssueString
        {
            get
            {
                var yearOfIssueString = $"Год выхода: {YearOfIssue}";
                return yearOfIssueString;
            }
        }
        public double Rating { get; set; }
        public string RatingString
        {
            get
            {
                var ratingString = $"Рейтинг: {Rating}";
                return ratingString;
            }
        }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string PlatformBriefly
        {
            get
            {
                string platromsList = "";
                var gamesPlatforms = GamesCollectionEntities.GetContext().GamesPlatforms.ToList().Where(p => p.GameID == ID).ToList();
                var platforms = GamesCollectionEntities.GetContext().Platforms.ToList();
                int counter = 0;
                foreach (var platform in gamesPlatforms)
                {
                    var currentPlatform = platforms.Where(m => m.ID == platform.PlatformID).First();
                    if (counter == 2)
                    {
                        platromsList += ", ...";
                        return platromsList;
                    }
                    if (platromsList != "")
                    {
                        platromsList += ", ";
                    }
                    platromsList += currentPlatform.Platform;
                    counter++;
                }
                return platromsList;
            }
        }

        public string PlatformBrieflyString
        {
            get
            {
                var platformString = $"Платформы: {PlatformBriefly}";
                return platformString;
            }
        }

        public string Platform
        {
            get
            {
                string platromsList = "";
                var gamesPlatforms = GamesCollectionEntities.GetContext().GamesPlatforms.ToList().Where(p => p.GameID == ID).ToList();
                var platforms = GamesCollectionEntities.GetContext().Platforms.ToList();
                foreach (var platform in gamesPlatforms)
                {
                    var currentPlatform = platforms.Where(m => m.ID == platform.PlatformID).First();

                    if (platromsList != "")
                    {
                        platromsList += ", ";
                    }
                    platromsList += currentPlatform.Platform;
                }
                return platromsList;
            }
        }

        public string PlatformString
        {
            get
            {
                var platformString = $"Платформы: {Platform}";
                return platformString;
            }
        }

        public string Developers
        {
            get
            {
                string developersList = "";
                var gamesDevelopers = GamesCollectionEntities.GetContext().GamesDevelopers.ToList().Where(p => p.GameID == ID).ToList();
                var developers = GamesCollectionEntities.GetContext().Developers.ToList();
                foreach (var developer in gamesDevelopers)
                {
                    var currentDeveloper = developers.Where(m => m.ID == developer.DeveloperID).First();
                    if (developersList != "")
                    {
                        developersList += ", ";
                    }
                    developersList += currentDeveloper.Developer;
                }
                return developersList;
            }
        }

        public string DeveloperString
        {
            get
            {
                var developerString = $"Разработчики: {Developers}";
                return developerString;
            }
        }

        public string Genre
        {
            get
            {
                string genreList = "";
                var gamesGenres = GamesCollectionEntities.GetContext().GamesGenres.ToList().Where(p => p.GameID == ID).ToList();
                var genres = GamesCollectionEntities.GetContext().Genres.ToList();
                foreach (var genre in gamesGenres)
                {
                    var currentGenre = genres.Where(m => m.ID == genre.GenreID).First();
                    if (genreList != "")
                    {
                        genreList += ", ";
                    }
                    genreList += currentGenre.Genre;
                }
                return genreList;
            }
        }

        public string GenreString
        {
            get
            {
                var genreString = $"Жанры: {Genre}";
                return genreString;
            }
        }

        public string Publisher
        {
            get
            {
                string publisherList = "";
                var gamesPublishers = GamesCollectionEntities.GetContext().GamesPublishers.ToList().Where(p => p.GameID == ID).ToList();
                var publishers = GamesCollectionEntities.GetContext().Publishers.ToList();
                foreach (var publisher in gamesPublishers)
                {
                    var currentPublisher = publishers.Where(m => m.ID == publisher.PublisherID).First();
                    if (publisherList != "")
                    {
                        publisherList += ", ";
                    }
                    publisherList += currentPublisher.Publisher;
                }
                return publisherList;
            }
        }

        public string PublisherString
        {
            get
            {
                var publisherString = $"Издатели: {Publisher}";
                return publisherString;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GamesDevelopers> GamesDevelopers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GamesGenres> GamesGenres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GamesPlatforms> GamesPlatforms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GamesPublishers> GamesPublishers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersGames> UsersGames { get; set; }
    }
}
