﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VueJS.Data.Abstract;
using VueJS.Entities.ComplexTypes;
using VueJS.Entities.Concrete;

namespace VueJS.Services.Extensions
{
    public class IUrlExtensions
    {
        private readonly Mapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpContext _httpContext;
        public IUrlExtensions(Mapper mapper, IUnitOfWork unitOfWork, HttpContext httpContext)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
        }
        //@Url.link @Url.FriendlyUrlHelper()
        public string FriendlyUrlHelper(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";
            url = url.ToLower();
            url = url.Trim();
            if (url.Length > 100)
            {
                url = url.Substring(0, 100);
            }
            url = url.Replace("İ", "I");
            url = url.Replace("ı", "i");
            url = url.Replace("ğ", "g");
            url = url.Replace("Ğ", "G");
            url = url.Replace("ç", "c");
            url = url.Replace("Ç", "C");
            url = url.Replace("ö", "o");
            url = url.Replace("Ö", "O");
            url = url.Replace("ş", "s");
            url = url.Replace("Ş", "S");
            url = url.Replace("ü", "u");
            url = url.Replace("Ü", "U");
            url = url.Replace("'", "");
            url = url.Replace("\"", "");
            char[] replacerList = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (url.Contains(strChr))
                {
                    url = url.Replace(strChr, string.Empty);
                }
            }
            Regex regex = new Regex("[^a-zA-Z0-9_-]");
            url = regex.Replace(url, "-");
            while (url.IndexOf("--", StringComparison.Ordinal) > -1)
                url = url.Replace("--", "-");
            return url;
        }

        public async Task<object> GetParentsAsync(ObjectType objectType, object dto)
        {
            if (objectType == ObjectType.basepage || objectType == ObjectType.page || objectType == ObjectType.article)
            {
                var post = _mapper.Map<Post>(dto);
                Post parent = post.Parent;
                post.Parents = new List<Post>();
                while (parent != null)
                {
                    post.Parents.Add(parent);
                    parent = await _unitOfWork.Posts.GetAsync(p => p.Id == parent.ParentId, p => p.Parent, p => p.Children);
                }
                return post;
            }
            else
            {
                var term = _mapper.Map<Term>(dto);
                Term parent = term.Parent;
                term.Parents = new List<Term>();
                while (parent != null)
                {
                    term.Parents.Add(parent);
                    parent = await _unitOfWork.Terms.GetAsync(p => p.Id == parent.ParentId, p => p.Parent, p => p.Children);
                }
                return term;
            }
        }

        public async Task<string> FriendlySEOUrlAsync(ObjectType objectType, object dto)
        {
            string url = _httpContext.Request.Host.Value;

            if (objectType == ObjectType.basepage || objectType == ObjectType.page || objectType == ObjectType.article)
            {
                Post post = (Post)await GetParentsAsync(objectType, dto);

                for (int i = post.Parents.Count ; i > 0; --i)
                {
                    url += "/" + post.Parents[i].PostName;
                }
            }
            else
            {
                Term term = (Term)await GetParentsAsync(objectType, dto);

                for (int i = term.Parents.Count; i > 0; --i)
                {
                    url += "/" + term.Parents[i].Slug;
                }
            }

            if (url == _httpContext.Request.Host.Value) return "";
            url = url.ToLower();
            url = url.Trim();
            if (url.Length > 100)
            {
                url = url.Substring(0, 100);
            }
            url = url.Replace("İ", "I");
            url = url.Replace("ı", "i");
            url = url.Replace("ğ", "g");
            url = url.Replace("Ğ", "G");
            url = url.Replace("ç", "c");
            url = url.Replace("Ç", "C");
            url = url.Replace("ö", "o");
            url = url.Replace("Ö", "O");
            url = url.Replace("ş", "s");
            url = url.Replace("Ş", "S");
            url = url.Replace("ü", "u");
            url = url.Replace("Ü", "U");
            url = url.Replace("'", "");
            url = url.Replace("\"", "");
            char[] replacerList = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (url.Contains(strChr))
                {
                    url = url.Replace(strChr, string.Empty);
                }
            }
            Regex regex = new Regex("[^a-zA-Z0-9_-]");
            url = regex.Replace(url, "-");
            while (url.IndexOf("--", StringComparison.Ordinal) > -1)
                url = url.Replace("--", "-");
            return url;
        }
    }

}