using MortgageHelperData;
using MortgageHelperModels;
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
        public bool CreateProperty(PropertyCreate model)
        {
            var entity = new Property()
            {
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
                var query = ctx.Properties.Select(e => new PropertyListItem
                {
                    PropertyID = e.PropertyID,
                    Name = e.Name,
                    Address = e.Address,
                    Size = e.Size,
                    Price = e.Price,
                    Seller = e.Seller,
                    TimeOnMarket = e.TimeOnMarket,
                    PropertyType = e.PropertyType
                });
                return query.ToArray();
            }
        }

    }
}
