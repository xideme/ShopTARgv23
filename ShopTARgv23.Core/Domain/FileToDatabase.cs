﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Domain
{
    public class FileToDatabase
    {

        //db
        public Guid? Id { get; set; }
        public string? ImageTitle { get; set; }
        public byte[]? ImageData { get; set; }
        public Guid? RealEstateId { get; set; }

        public Guid? KindergartenId { get; set; }
    }
}
