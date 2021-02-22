using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Data.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AloneCoreApp.Application.Implementation
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<SizeViewModel>> GetAll()
        {
            return _mapper.ProjectTo<SizeViewModel>(_sizeRepository.FindAll()).ToListAsync();
        }
    }
}
