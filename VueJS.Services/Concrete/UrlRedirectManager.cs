﻿using AutoMapper;
using VueJS.Data.Abstract;
using VueJS.Entities.Concrete;
using VueJS.Entities.Dtos;
using VueJS.Services.Abstract;
using VueJS.Services.Utilities;
using VueJS.Shared.Utilities.Results.Concrete;
using VueJS.Shared.Utilities.Results.Abstract;
using VueJS.Shared.Utilities.Results.ComplexTypes;
using System.Threading.Tasks;

namespace VueJS.Services.Concrete
{
    public class UrlRedirectManager : ManagerBase, IUrlRedirectService
    {
        public UrlRedirectManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<UrlRedirectDto>> GetAsync(int urlRedirectId)
        {
            var urlRedirect = await UnitOfWork.UrlRedirects.GetAsync(u => u.Id == urlRedirectId);
            if (urlRedirect != null)
            {
                return new DataResult<UrlRedirectDto>(ResultStatus.Success, new UrlRedirectDto
                {
                    UrlRedirect = urlRedirect,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<UrlRedirectDto>(ResultStatus.Error, Messages.UrlRedirect.NotFound(isPlural: false), new UrlRedirectDto
            {
                UrlRedirect = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.UrlRedirect.NotFound(isPlural: false)
            });
        }

        public async Task<IDataResult<UrlRedirectDto>> GetAsync(string oldUrl)
        {
            var urlRedirect = await UnitOfWork.UrlRedirects.GetAsync(ur => ur.OldUrl == oldUrl, ur => ur.User);
            if (urlRedirect != null)
            {
                return new DataResult<UrlRedirectDto>(ResultStatus.Success, new UrlRedirectDto
                {
                    UrlRedirect = urlRedirect,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<UrlRedirectDto>(ResultStatus.Error, Messages.UrlRedirect.NotFound(isPlural: true), new UrlRedirectDto
            {
                UrlRedirect = urlRedirect,
                ResultStatus = ResultStatus.Error,
                Message = Messages.UrlRedirect.NotFound(isPlural: true)
            });
        }

        public async Task<IDataResult<UrlRedirectUpdateDto>> GetUrlRedirectUpdateDtoAsync(int urlRedirectId)
        {
            var result = await UnitOfWork.UrlRedirects.AnyAsync(u => u.Id == urlRedirectId);
            if (result)
            {
                var urlRedirect = await UnitOfWork.UrlRedirects.GetAsync(u => u.Id == urlRedirectId);
                var urlRedirectUpdateDto = Mapper.Map<UrlRedirectUpdateDto>(urlRedirect);
                return new DataResult<UrlRedirectUpdateDto>(ResultStatus.Success, urlRedirectUpdateDto);
            }
            else
            {
                return new DataResult<UrlRedirectUpdateDto>(ResultStatus.Error, Messages.UrlRedirect.NotFound(isPlural: false), null);
            }
        }

        public async Task<IDataResult<UrlRedirectListDto>> GetAllAsync()
        {
            var urlRedirects = await UnitOfWork.UrlRedirects.GetAllAsync(null, ur => ur.User);
            if (urlRedirects.Count > -1)
            {
                return new DataResult<UrlRedirectListDto>(ResultStatus.Success, new UrlRedirectListDto
                {
                    UrlRedirects = urlRedirects,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<UrlRedirectListDto>(ResultStatus.Error, Messages.UrlRedirect.NotFound(isPlural: true), new UrlRedirectListDto
            {
                UrlRedirects = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.UrlRedirect.NotFound(isPlural: true)
            });
        }
        
        public async Task<IDataResult<UrlRedirectDto>> AddAsync(UrlRedirectAddDto urlRedirectAddDto, int userId)
        {
            var urlRedirect = Mapper.Map<UrlRedirect>(urlRedirectAddDto);
            urlRedirect.UserId = userId;
            var addedUrlRedirect = await UnitOfWork.UrlRedirects.AddAsync(urlRedirect);
            await UnitOfWork.SaveAsync();
            return new DataResult<UrlRedirectDto>(ResultStatus.Success, Messages.UrlRedirect.Add(addedUrlRedirect.NewUrl), new UrlRedirectDto
            {
                UrlRedirect = addedUrlRedirect,
                ResultStatus = ResultStatus.Success,
                Message = Messages.UrlRedirect.Add(addedUrlRedirect.NewUrl)
            });
        }

        public async Task<IDataResult<UrlRedirectDto>> UpdateAsync(UrlRedirectUpdateDto urlRedirectUpdateDto, int userId)
        {
            var oldUrlRedirect = await UnitOfWork.UrlRedirects.GetAsync(u => u.Id == urlRedirectUpdateDto.Id, ur => ur.User);
            var urlRedirect = Mapper.Map<UrlRedirectUpdateDto, UrlRedirect>(urlRedirectUpdateDto, oldUrlRedirect);
            urlRedirect.UserId = userId;
            var updatedUrlRedirect = await UnitOfWork.UrlRedirects.UpdateAsync(urlRedirect);
            await UnitOfWork.SaveAsync();
            return new DataResult<UrlRedirectDto>(ResultStatus.Success, Messages.UrlRedirect.Update(updatedUrlRedirect.OldUrl), new UrlRedirectDto
            {
                UrlRedirect = updatedUrlRedirect,
                ResultStatus = ResultStatus.Success,
                Message = Messages.UrlRedirect.Update(updatedUrlRedirect.NewUrl)
            });
        }

        public async Task<IResult> DeleteAsync(int urlRedirectId)
        {
            var urlRedirect = await UnitOfWork.UrlRedirects.GetAsync(u => u.Id == urlRedirectId);
            if (urlRedirect != null)
            {
                await UnitOfWork.UrlRedirects.DeleteAsync(urlRedirect);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.UrlRedirect.HardDelete(urlRedirect.NewUrl));
            }
            return new Result(ResultStatus.Error, Messages.UrlRedirect.NotFound(isPlural: false));
        }
    }
}