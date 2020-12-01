using MortgageHelperData;
using MortgageHelperModels;
using MortgageHelperModels.FeatureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperServices
{
    public class FeatureService
    {
        private readonly Guid _userId;

        public FeatureService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFeature(FeatureCreate model)
        {
            var entity = new Feature()
            {
                UserID = _userId,
                PropertyID = model.PropertyID,
                DistanceFromPopulace = model.DistanceFromPopulace,
                RoadAccess = model.RoadAccess,
                CityWater = model.CityWater,
                CityElectric = model.CityElectric,
                CitySewer = model.CitySewer,
                Internet = model.Internet,
                AlternateWater = model.AlternateWater,
                AlternateElectric = model.AlternateElectric,
                AlternateSewage = model.AlternateSewage,
                BodyOfWater = model.BodyOfWater,
                NearbyBodyOfWater = model.NearbyBodyOfWater

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Features.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FeatureListItem> GetFeatures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Features.Where(e=> e.UserID ==_userId).Select(e => new FeatureListItem
                {
                    FeatureID = e.FeatureID,
                    PropertyID = e.PropertyID,
                    DistanceFromPopulace = e.DistanceFromPopulace,
                    RoadAccess = e.RoadAccess,
                    CityWater = e.CityWater,
                    CityElectric = e.CityElectric,
                    CitySewer = e.CitySewer,
                    AlternateWater = e.AlternateWater,
                    AlternateElectric = e.AlternateElectric,
                    AlternateSewage = e.AlternateSewage,
                    BodyOfWater = e.BodyOfWater,
                    NearbyBodyOfWater = e.NearbyBodyOfWater
                });
                return query.ToArray();
            }
        }
    }
}
