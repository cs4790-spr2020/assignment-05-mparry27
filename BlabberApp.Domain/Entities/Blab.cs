using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class Blab : IEntity
    {
        public Blab()
        {
            this.Id = Guid.NewGuid();
            this.User = new User();
            this.Message = "";
            this.DTTM = DateTime.Now;
        }
        public Blab(string Message)
        {
            this.Id = Guid.NewGuid();
            this.User = new User();
            this.Message = Message;
            this.DTTM = DateTime.Now;
        }
        public Blab(User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;
            this.Message = "";
            this.DTTM = DateTime.Now;
        }
        public Blab(string Message, User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;
            this.Message = Message;
            this.DTTM = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime DTTM { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
        public bool IsValid()
        {
            if (this.Id == null) throw new ArgumentNullException();
            if (this.Message == null) throw new ArgumentNullException();
            if (this.Message.ToString() == "") throw new FormatException();
            if (this.User == null) throw new ArgumentNullException();
            return true;
        }
    }
}