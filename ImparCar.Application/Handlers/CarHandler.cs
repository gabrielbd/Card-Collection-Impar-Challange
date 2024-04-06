using ImparCar.Domain.Entities;
using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Application.Interfaces.Validators;
using ImparCar.Application.Requests.Car;
using ImparCar.Application.Response.Car;
using ImparCar.Domain.Interfaces.Services;


namespace ImparCar.Application.Handlers
{
    public class CarHandler : ICarHandler
    {
        private readonly ICarDomainService _domain;
        private readonly IPhotoDomainService _domainPhoto;
        private readonly ICarValidator _validator;

        public CarHandler(ICarDomainService domain, ICarValidator validator, IPhotoDomainService domainPhoto)
        {
            _domain = domain;
            _validator = validator;
            _domainPhoto = domainPhoto;
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
            var photo = new Photo
            {
                Base64 = request.Base64,
            };
            var resultPhoto = await _domainPhoto.CreateAsync(photo);

            var car = new Car
            {
                Name = request.Name,
                PhotoId = resultPhoto.Id,
                Photo = resultPhoto
            };
            var resultCar = await _domain.CreateAsync(car);


            var response = new CreateCarResponse
            {
                IdCar = resultCar.Id,
                IdPhoto = resultCar.PhotoId
            };
            return response;
        }

        public Task<UpdateCarResponse> UpdateAsync(UpdateCarRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CarResponse>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CarResponse> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

