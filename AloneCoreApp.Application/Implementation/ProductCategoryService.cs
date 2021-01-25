using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Data.Entities;
using AloneCoreApp.Data.Enums;
using AloneCoreApp.Data.IRepositories;
using AloneCoreApp.Infrastructure.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloneCoreApp.Application.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            // var productCategory2 = Mapper.Map<ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
            return productCategoryVm;
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public async Task<List<ProductCategoryViewModel>> GetAll()
        {
            return await _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository
                    .FindAll()
                    .OrderBy(x => x.SortOrder))
                    .ToListAsync();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository
                    .FindAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId)).ToList();
            }
            else
            {
                return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository
                    .FindAll().OrderBy(x => x.ParentId)).ToList();
            }
        }

        public async Task<ProductCategoryViewModel> GetById(int id)
        {
            return _mapper.Map<ProductCategory, ProductCategoryViewModel>(await _productCategoryRepository.FindByIdAsync(id));
        }

        public List<ProductCategoryViewModel> GetByParentId(int parentId)
        {
            return _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository
                .FindAll(x => x.Status == Status.Active && x.ParentId == parentId)).ToList();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _mapper.ProjectTo<ProductCategoryViewModel>(_productCategoryRepository
                .FindAll(x => x.HomeFlag == true, c => c.Products)
                .OrderBy(x => x.HomeOrder)
                .Take(top));

            var categories = query.ToList();
            foreach (var category in categories)
            {
               // category. Products = _productCategoryRepositor
            }

            return categories;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            throw new NotImplementedException();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}
