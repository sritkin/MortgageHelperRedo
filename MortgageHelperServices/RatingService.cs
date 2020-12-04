using MortgageHelperData;
using MortgageHelperModels;
using MortgageHelperModels.FeatureModels;
using MortgageHelperModels.RatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperServices
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.Features.Where(e => e.UserID == _userId && e.FeatureID == model.FeatureID && e.PropertyID == model.PropertyID).Select(e => new AllDetailsListItem
                {
                    PropertyID = e.PropertyID,
                    FeatureID = e.FeatureID,
                    DistanceFromPopulace = e.DistanceFromPopulace,
                    RoadAccess = e.RoadAccess,
                    CityWater = e.CityWater,
                    CityElectric = e.CityElectric,
                    CitySewer = e.CitySewer,
                    Internet = e.Internet,
                    AlternateWater = e.AlternateWater,
                    AlternateElectric = e.AlternateElectric,
                    AlternateSewage = e.AlternateSewage,
                    BodyOfWater = e.BodyOfWater,
                    NearbyBodyOfWater = e.NearbyBodyOfWater,
                    Price = e.Property.Price
                }).Single();

                decimal placeholder = 0;
                if (item.DistanceFromPopulace >= 25) { placeholder += 10; }
                if (item.DistanceFromPopulace < 25) { placeholder -= 4; }
                if (item.RoadAccess is true) { placeholder += 10; }
                if (item.CityWater is true) { placeholder += 8; }
                if (item.CityElectric is true) { placeholder += 8; }
                if (item.CitySewer is true) { placeholder += 8; }
                if (item.Internet is true) { placeholder += 8; }
                if (item.AlternateWater is true) { placeholder += 4; }
                if (item.AlternateElectric is true) { placeholder += 4; }
                if (item.AlternateSewage is true) { placeholder += 4; }
                if (item.BodyOfWater is true) { placeholder += 4; }
                if (item.NearbyBodyOfWater is true) { placeholder += 2; }

                if (item.Price <= 100000)  { placeholder += 30; }
                else if (item.Price >100000 && item.Price <=150000) { placeholder += 15; }
                else if (item.Price > 150000 && item.Price <= 200000) { placeholder += 5; }
                else if (item.Price >= 2500000) { placeholder -= 30; }

                var entity = new Rating()
                {
                    
                    UserID = _userId,
                    PropertyID = model.PropertyID,
                    FeatureID = model.FeatureID,
                    RatingActual = placeholder/10
                };

                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Where(e => e.UserID == _userId).Select(e => new RatingListItem
                {
                    RatingID = e.RatingID,
                    PropertyID = e.PropertyID,
                    FeatureID = e.FeatureID,
                    RatingActual = e.RatingActual,
                    Address = e.Property.Address
                    
                });
                return query.ToArray();
            }
        }

        public bool DeleteAllRatingsGivenPropertyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Where(e => e.PropertyID == id && e.UserID == _userId).ToList();

                foreach (MortgageHelperData.Rating item in entity)
                {
                    ctx.Ratings.Remove(item);

                }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSingleRatingGivenRatingID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingID == id && e.UserID == _userId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
