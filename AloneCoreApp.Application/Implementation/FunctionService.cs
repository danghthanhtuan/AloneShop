using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Application.ViewModels.System;
using AloneCoreApp.Data.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AloneCoreApp.Application.Implementation
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;
        private readonly IMapper _mapper;

        public FunctionService(IFunctionRepository functionRepository, IMapper mapper)
        {
            _functionRepository = functionRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<FunctionViewModel>> GetAll()
        {
            return _mapper.ProjectTo<FunctionViewModel>(_functionRepository.FindAll()).ToListAsync();
        }

        public List<FunctionViewModel> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}