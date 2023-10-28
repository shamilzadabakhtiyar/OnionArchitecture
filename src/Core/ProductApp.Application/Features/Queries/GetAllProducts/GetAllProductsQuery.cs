using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Mapping;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapping;

            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapping)
            {
                this.productRepository = productRepository;
                this.mapping = mapping;
            }

            async Task<ServiceResponse<List<ProductViewDto>>> IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>.Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetAllAsync();
                var dto = mapping.Map<List<ProductViewDto>>(products);
                return new ServiceResponse<List<ProductViewDto>>(dto);
            }
        }
    }
}
