using ImparCar.Domain.Entities;
using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Application.Interfaces.Validators;
using ImparCar.Application.Requests.Car;
using ImparCar.Application.Response.Car;
using ImparCar.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation;


namespace ImparCar.Application.Handlers
{
    public class CarHandler : ICarHandler
    {
        private readonly ICarDomainService _domain;
        private readonly IPhotoDomainService _domainPhoto;
        private readonly IMapper _mapper;
        private readonly ICarValidator _validator;

        public CarHandler(ICarDomainService domain, ICarValidator validator, IPhotoDomainService domainPhoto, IMapper mapper)
        {
            _domain = domain;
            _validator = validator;
            _domainPhoto = domainPhoto;
            _mapper = mapper;
        }

        public async Task<CreateCarResponse> CreateAsync(CreateCarRequest request)
        {
            var validatorResult = _validator.Validate(request);
            if (!validatorResult.IsValid)
            {
                return new CreateCarResponse
                {
                    Errors = validatorResult.Errors
                };
            }

            var mapPhoto = _mapper.Map<Photo>(request);
            var mapCar   = _mapper.Map<Car>(request);

            var resultPhoto = await _domainPhoto.CreateAsync(mapPhoto);
            var resultCar = await _domain.CreateAsync(mapCar);

            var mapResult = _mapper.Map<CreateCarResponse>(resultCar);

            return mapResult;
        }

        public async Task<UpdateCarResponse> UpdateAsync(UpdateCarRequest request)
        {
            var car = await _domain.GetByIdAsync(request.Id);
            if (car == null)
            {
                throw new Exception("Card não encontrado.");
            }

            var mapCar = _mapper.Map<Car>(request);
            var carResult = await _domain.UpdateAsync(mapCar);

            var mapCarResult = _mapper.Map<UpdateCarResponse>(carResult);
            return mapCarResult;
        }

        public async Task DeleteAsync(Guid id)
        {
            var car = await _domain.GetByIdAsync(id);
            if (car == null)
            {
                throw new Exception("Card não encontrado.");
            }
            await _domain.DeleteAsync(id);
        }

        public async Task<List<CarResponse>> GetAllListAsync()
        {
            var all = await _domain.GetAllAsync();
            var mapAll = _mapper.Map<List<CarResponse>>(all);
            return mapAll;
        }

        public async Task<CarResponse> GetByIdAsync(Guid id)
        {
            var car = await _domain.GetByIdAsync(id);
            if (car == null)
            {
                throw new Exception("Card não encontrado.");
            }
            var map = _mapper.Map<CarResponse>(car);
            return map;
        }
    }
}

