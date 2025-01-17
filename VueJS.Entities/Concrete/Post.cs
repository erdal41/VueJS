﻿using System;
using System.Collections.Generic;
using VueJS.Entities.ComplexTypes;
using VueJS.Shared.Entities.Abstract;

namespace VueJS.Entities.Concrete
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string Content { get; set; }
        public string Title { get; set; }
        public PostStatus PostStatus { get; set; }
        public bool CommentStatus { get; set; }
        public string PostName { get; set; }
        public int? ParentId { get; set; }
        public ObjectType PostType { get; set; }
        public int CommentCount { get; set; }
        public string Description { get; set; }
        public int? FeaturedImageId { get; set; }
        public string BottomContent { get; set; }
        public bool IsShowPage { get; set; }
        public bool IsShowFeaturedImage { get; set; }
        public bool IsShowSubPosts { get; set; }

        public User User { get; set; }
        public Upload FeaturedImage { get; set; }
        public Post Parent { get; set; }
        public List<Post> Parents { get; set; }
        public ICollection<Post> Children { get; set; }
        public ICollection<Gallery> Galleries { get; set; }
        public ICollection<PostTerm> PostTerms { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}