﻿using VueJS.Entities.ComplexTypes;
using VueJS.Entities.Dtos;
using VueJS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VueJS.Services.Abstract
{
    public interface IPostService
    {
        Task<IDataResult<PostDto>> GetAsync(int postId, ObjectType postType);
        Task<IDataResult<PostDto>> GetAsync(string postName);
        Task<IDataResult<PostDto>> GetByIdAsync(int postId, bool includeCategories, bool includeTags, bool includeComments, bool includeGalleries, bool includeUser);
        Task<IDataResult<PostUpdateDto>> GetBasePageUpdateDtoAsync(string pageName);
        Task<IDataResult<PostListDto>> GetAllAsync(int? userId, string category, string tag, ObjectType postType, PostStatus? postStatus);
        Task<IDataResult<PostListDto>> GetAllPostStatusAsync(ObjectType postType, PostStatus postStatus);
        Task<IDataResult<PostListDto>> GetAllTopPostsAsync(int? postId);
        Task<IDataResult<PostListDto>> GetAllSubPostsAsync(int? postId);
        Task<IDataResult<PostListDto>> GetSubPostUpdateDtoAsync(int parentId);
        Task<IDataResult<PostListDto>> GetAllSubPostDetailsAsync(int postId);
        Task<IDataResult<PostUpdateDto>> GetPostUpdateDtoAsync(int postId);
        Task<IDataResult<PostDto>> AddAsync(PostAddDto postAddDto, int userId);
        Task<IDataResult<PostDto>> UpdateAsync(PostUpdateDto postUpdateDto, int userId);
        Task<IDataResult<PostDto>> TopPostUpdateAsync(int postId, int parentId);
        Task<IResult> SubPostUpdateAsync(int subPostId, int? subPostParentId);
        Task<IDataResult<PostDto>> SubPostDetailUpdateAsync(int postId, string description, int? featuredImageId);
        Task<IDataResult<PostDto>> GalleryImageAddAsync(int postId, List<int> galleryIds);
        Task<IDataResult<PostDto>> PostStatusChangeAsync(int postId, PostStatus postStatus, int userId);
        Task<IDataResult<PostDto>> DeleteAsync(int postId);
        Task<IDataResult<int>> CountByNonDeletedAsync();
        Task<IDataResult<PostListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize);
        Task<IDataResult<PostListDto>> GetAllByPagingAsync(string categoryGuid, string tagGuid, int currentPage = 1, int pageSize = 5,
            bool isAscending = false);
        Task<IDataResult<PostListDto>> GetAllByTermArticlesAsync(int termId, int currentPage = 1);
        Task<IDataResult<PostListDto>> GetAllByTagArticlesAsync(int tagId, int currentPage = 1);
        Task<IDataResult<PostListDto>> GetAllByUserIdOnFilter(int userId, FilterBy filterBy, OrderBy orderBy,
            bool isAscending, int takeSize, int categoryId, int tagId, DateTime startAt, DateTime endAt, int minViewCount,
            int maxViewCount, int minCommentCount, int maxCommentCount);
        Task<IDataResult<PostListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5,
            bool isAscending = false);
        Task<IResult> IncreaseViewCountAsync(int postId);
    }
}