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
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository colorRepository,IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<ColorViewModel>> GetAll()
        {
            return _mapper.ProjectTo<ColorViewModel>(_colorRepository.FindAll()).ToListAsync();
        }
    }
}
