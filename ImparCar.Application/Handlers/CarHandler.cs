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

            var mapPhoto = new Photo
            {
                Base64 = System.Convert.FromBase64String(request.Base64)
            };
            var resultPhoto = await _domainPhoto.CreateAsync(mapPhoto);


            var mapCar = _mapper.Map<Car>(request);
            mapCar.PhotoId = resultPhoto.Id;
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

            if (request.Name != null)
                car.Name = request.Name;
            if (request.Status != null)
                car.Status = request.Status;
            if (request.Base64 != null)
            {
                var updateFoto = await _domainPhoto.GetByIdAsync(car.PhotoId);
                if(updateFoto != null)
                {
                    updateFoto.Base64 = System.Convert.FromBase64String(request.Base64);
                    await _domainPhoto.UpdateAsync(updateFoto);
                }
                else
                {
                    var foto = new Photo { 
                        Base64 = System.Convert.FromBase64String(request.Base64)
                    };
                    var fotoResult = await _domainPhoto.CreateAsync(foto);
                    car.PhotoId = fotoResult.Id;
                    car.Photo = fotoResult;
                }
            };
   
            var carResult = await _domain.UpdateAsync(car);

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

            if(car.PhotoId != null)
            {
                await _domainPhoto.DeleteAsync(car.PhotoId);
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

