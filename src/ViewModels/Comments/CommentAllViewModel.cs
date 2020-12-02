﻿using System;
using System.Globalization;

namespace ViewModels.Comments
{
    public  class CommentAllViewModel
    {
        public string FirstName { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn{ get; set; }

        public string CreatedOnToString => this.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}