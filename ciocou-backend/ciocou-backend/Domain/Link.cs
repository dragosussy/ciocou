using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; private set; }
        public string User1Name { get; private set; }
        public string User2Name { get; private set; }
        public string Winner { get; private set; }
        public DateTime ExpirationDateTime { get; private set; }
        public bool IsDone { get; private set; }

        public static Link GenerateLink(string user1Name, DateTime expirationDate)
        {
            return new Link
            {
                Guid = System.Guid.NewGuid().ToString(),
                ExpirationDateTime = expirationDate, 
                User1Name = user1Name,
                User2Name = "",
                Winner = ""
            };
        }

        public Link UpdateLink(string user2Name, string winner)
        {
            this.User2Name = user2Name;
            this.Winner = winner;
            this.IsDone = true;
            return this;
        }

        public string ToUrlFormat(string baseUrl)
        {
            return $"{baseUrl}?id={this.Guid}";
        }
    }
}