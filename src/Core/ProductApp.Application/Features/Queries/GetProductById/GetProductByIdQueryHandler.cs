using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapping;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapping)
        {
            this.productRepository = productRepository;
            this.mapping = mapping;
        }

        async Task<ServiceResponse<ProductViewDto>> IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            var dto = mapping.Map<ProductViewDto>(product);
            return new ServiceResponse<ProductViewDto>(dto);
        }
    }
}
