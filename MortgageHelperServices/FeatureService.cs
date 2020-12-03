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
                PropertyID = new ApplicationDbContext().Properties.Max(id=> id.PropertyID),
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

        public FeatureListItem GetFeaturesByFeatureID (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Features.Single(e => e.FeatureID == id);
                return new FeatureListItem
                {
                    FeatureID = entity.FeatureID,
                    PropertyID = entity.PropertyID,
                    DistanceFromPopulace = entity.DistanceFromPopulace,
                    RoadAccess = entity.RoadAccess,
                    CityWater = entity.CityWater,
                    CityElectric = entity.CityElectric,
                    CitySewer = entity.CitySewer,
                    Internet = entity.CitySewer,
                    AlternateWater = entity.AlternateWater,
                    AlternateElectric = entity.AlternateElectric,
                    AlternateSewage = entity.AlternateSewage,
                    BodyOfWater = entity.BodyOfWater,
                    NearbyBodyOfWater = entity.NearbyBodyOfWater
                };
            }
        } 
        public bool UpdateFeature(FeatureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Features.Single(e => e.FeatureID == model.FeatureID && e.UserID == _userId);

                entity.DistanceFromPopulace = model.DistanceFromPopulace;
                entity.RoadAccess = model.RoadAccess;
                entity.CityWater = model.CityWater;
                entity.CityElectric = model.CityElectric;
                entity.CitySewer = model.CitySewer;
                entity.Internet = model.Internet;
                entity.AlternateWater = model.AlternateWater;
                entity.AlternateElectric = model.AlternateElectric;
                entity.AlternateSewage = model.AlternateSewage;
                entity.BodyOfWater = model.BodyOfWater;
                entity.NearbyBodyOfWater = model.NearbyBodyOfWater;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAllFeaturesGivenPropertyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Features.Where(e => e.PropertyID == id && e.UserID == _userId).ToList();

                foreach (MortgageHelperData.Feature item in entity)
                {
                    ctx.Features.Remove(item);

                }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFeatureGivenFeatureID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Features.Single(e => e.FeatureID == id && e.UserID == _userId);

                ctx.Features.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
