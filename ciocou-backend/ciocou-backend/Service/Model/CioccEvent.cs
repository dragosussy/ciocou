using Service.Model.Builder;
using System.ComponentModel.DataAnnotations;

namespace Service
{
    public class CioccEvent
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; private set; }
        public string UserName1 { get; private set; }
        public string? UserName2 { get; private set; }
        public string? Winner { get; private set; }
        public DateTime ExpirationDateTime { get; private set; }
        public bool IsDone { get; private set; }

        public CioccEvent()
        {
            Guid = System.Guid.NewGuid().ToString();
            ExpirationDateTime = DateTime.Now.AddDays(10);
            IsDone = false;
        }

        public CioccEvent MarkComplete(string user2Name, string winner)
        {
            this.UserName2 = user2Name;
            this.Winner = winner;
            this.IsDone = true;
            return this;
        }

        public string ToUrlParameter()
        {
            return $"id={this.Guid}";
        }

        public class CioccEventBuilder : IBuilder<CioccEvent>
        {
            private CioccEvent _event = new CioccEvent();

            public IBuilder<CioccEvent> UserName1(string username1)
            {
                _event.UserName1 = username1;
                return this;
            }

            public IBuilder<CioccEvent> UserName2(string username2)
            {
                _event.UserName2 = username2;
                return this;
            }

            public IBuilder<CioccEvent> Winner(string winner)
            {
                _event.Winner = winner;
                return this;
            }

            public IBuilder<CioccEvent> IsDone(bool isDone)
            {
                _event.IsDone = isDone;
                return this;
            }

            public IBuilder<CioccEvent> Reset()
            {
                _event = new CioccEvent();
                return this;
            }

            public CioccEvent Build()
            {
                var result = this._event;
                this.Reset();
                return result;
            }
        }

        public static CioccEventBuilder builder()
        {
            return new CioccEventBuilder();
        }
    }
}