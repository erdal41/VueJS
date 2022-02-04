﻿using VueJS.Entities.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace VueJS.Entities.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string UserName { get; set; }

        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(10, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim")]
        public int? ProfileImageId { get; set; }

        [DisplayName("Adı")]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        public string LastName { get; set; }

        [DisplayName("Hakkında")]
        public string About { get; set; }

        [DisplayName("Twitter")]
        public string TwitterLink { get; set; }

        [DisplayName("Facebook")]
        public string FacebookLink { get; set; }

        [DisplayName("Instagram")]
        public string InstagramLink { get; set; }

        [DisplayName("LinkedIn")]
        public string LinkedInLink { get; set; }

        [DisplayName("Youtube")]
        public string YoutubeLink { get; set; }

        [DisplayName("GitHub")]
        public string GitHubLink { get; set; }

        [DisplayName("Website")]
        public string WebsiteLink { get; set; }

        public Upload ProfileImage { get; set; }
        public IList<string> Roles { get; set; }
    }
}