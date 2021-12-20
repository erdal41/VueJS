﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VueJS.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public int? ProfileImageId { get; set; }
        public string About { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string GitHubLink { get; set; }
        public string WebsiteLink { get; set; }

        [InverseProperty("Users")]
        public Upload ProfileImage { get; set; }
        public GeneralSetting GeneralSetting { get; set; }
        public SeoGeneralSetting SeoGeneralSetting { get; set; }
        public ICollection<Upload> Uploads { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<SeoObjectSetting> SeoObjectSettings { get; set; }
        public ICollection<UrlRedirect> UrlRedirects { get; set; }
    }
}