using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Data.Entities;
using AloneCoreApp.Data.Enums;
using AloneCoreApp.Data.IRepositories;
using AloneCoreApp.Infrastructure.Interfaces;
using AloneCoreApp.Utilities.Constants;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloneCoreApp.Application.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductTagRepository _productTagRepository;


        public ProductService(IProductRepository productRepository,
            IMapper mapper,
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork,
            IProductTagRepository productTagRepository)
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _mapper = mapper;
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public ProductViewModel Add(ProductViewModel productVm)
        {
            List<ProductTag> productTags = new List<ProductTag>();
            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }
                var product = _mapper.Map<Product>(productVm);
                foreach (var productTag in productTags)
                {
                    product.ProductTags.Add(productTag);
                }
                _productRepository.Add(product);

            }
            return productVm;
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            return _mapper.ProjectTo<ProductViewModel>(_productRepository.FindAll(x => x.ProductCategory)).ToListAsync();
        }

        /// <summary>
        /// Lấy danh sách Product phân trang
        /// </summary>
        /// <param name="categoryId">Lọc theo categoryId</param>
        /// <param name="keyword">Lọc theo keyword</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword) || x.ProductCategory.Name.Contains(keyword));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            var totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = _mapper.ProjectTo<ProductViewModel>(query).ToList();

            var paging = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paging;
        }

        public ProductViewModel GetById(int id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductViewModel productVm)
        {
            List<ProductTag> productTags = new List<ProductTag>();

            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag();
                        tag.Id = tagId;
                        tag.Name = t;
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.Id == productVm.Id).ToList());
                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }
            }

            var product = _mapper.Map<Product>(productVm);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            _productRepository.Update(product);
        }
    }
}
