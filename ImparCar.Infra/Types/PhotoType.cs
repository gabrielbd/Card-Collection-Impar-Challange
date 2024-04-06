using ImparCar.Domain.Entities;

namespace ImparCar.Infra.Types
{
    public class PhotoType : ObjectType<Photo>
    {
        protected override void Configure(IObjectTypeDescriptor<Photo> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Base64);
        }
    }
}