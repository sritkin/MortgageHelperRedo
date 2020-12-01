using MortgageHelperData;
using MortgageHelperModels;
using MortgageHelperModels.MortgageModels;
using MortgageHelperModels.PropertyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperServices
{
    public class PropertyService
    {
        private readonly Guid _userId;

        public PropertyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProperty(PropertyCreate model)
        {
            var entity = new Property()
            {
                UserID = _userId,
                Name = model.Name,
                Address = model.Address,
                Size = model.Size,
                Price = model.Price,
                Seller = model.Seller,
                TimeOnMarket = model.TimeOnMarket,
                PropertyType = model.PropertyType

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Properties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PropertyListItem> GetProperties()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Properties.Where(e => e.UserID == _userId).Select(e => new PropertyListItem
                {
                    PropertyID = e.PropertyID,
                    Name = e.Name,
                    Price = e.Price,
                    PropertyType = e.PropertyType
                });
                return query.ToArray();
            }
        }

        public PropertyDetail GetPropertyByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Properties.Single(e => e.PropertyID == id && e.UserID == _userId);
                return
                    new PropertyDetail
                    {
                        PropertyID = entity.PropertyID,
                        Name = entity.Name,
                        Address = entity.Address,
                        Size = entity.Size,
                        Price = entity.Price,
                        Seller = entity.Seller,
                        TimeOnMarket = entity.TimeOnMarket,
                        PropertyType = entity.PropertyType
                    };
            }
        }
        public bool UpdateProperty(PropertyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =ctx.Properties.Single(e => e.PropertyID == model.PropertyID && e.UserID == _userId);

                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.Size = model.Size;
                entity.Price = model.Price;
                entity.Seller = model.Seller;
                entity.TimeOnMarket = model.TimeOnMarket;
                entity.PropertyType = model.PropertyType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProperty(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Properties.Single(e => e.PropertyID == id && e.UserID == _userId);

                ctx.Properties.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
