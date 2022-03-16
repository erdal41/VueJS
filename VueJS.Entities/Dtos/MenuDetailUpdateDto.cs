﻿using VueJS.Entities.ComplexTypes;
using VueJS.Entities.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VueJS.Entities.Dtos
{
    public class MenuDetailUpdateDto
    {
        [Required]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int MenuId { get; set; }
        public int? ObjectId { get; set; }
        public SubObjectType? SubObjectType { get; set; }
        public int MenuOrder { get; set; }
        public MenuDetail Parent { get; set; }
        public List<MenuDetail> Parents { get; set; }
    }
}