using System;
using System.Globalization;

namespace ViewModels.Comments
{
    public  class CommentAllViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn{ get; set; }

        public string CreatedOnToString => this.CreatedOn.AddHours(2).ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
    }
}
