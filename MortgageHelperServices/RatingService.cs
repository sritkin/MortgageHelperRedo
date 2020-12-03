using MortgageHelperData;
using MortgageHelperModels;
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

            var entity = new Rating()
            {

                UserID = _userId,
                PropertyID = new ApplicationDbContext().Properties.Max(id=> id.PropertyID),
                FeatureID = new ApplicationDbContext().Features.Max(id=> id.FeatureID),
                RatingTally = model.RatingTally,
                RatingActual = model.RatingActual
            };

            using (var ctx = new ApplicationDbContext())
            {
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
                    RatingTally = e.RatingTally,
                    RatingActual = e.RatingActual
                    
                });
                return query.ToArray();
            }
        }
        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                decimal placeholder = 0;
                if (model.DistanceFromPopulace >= 25) { placeholder = placeholder + 1; }
                if (model.RoadAccess is true) { placeholder = placeholder + 1; }
                if (model.CityWater is true) { placeholder = placeholder + 1; }
                if (model.CityElectric is true) { placeholder = placeholder + 1; }
                if (model.CitySewer is true) { placeholder = placeholder + 1; }
                if (model.Internet is true) { placeholder = placeholder + 1; }
                if (model.AlternateWater is true) { placeholder = placeholder + 1; }
                if (model.AlternateElectric is true) { placeholder = placeholder + 1; }
                if (model.AlternateSewage is true) { placeholder = placeholder + 1; }
                if (model.BodyOfWater is true) { placeholder = placeholder + 1; }
                if (model.NearbyBodyOfWater is true) { placeholder = placeholder + 1; }

                var entity = ctx.Ratings.Single(e => e.RatingID == model.RatingID && e.UserID == _userId);
                entity.RatingID = model.RatingID;
                entity.PropertyID = model.PropertyID;
                entity.FeatureID = model.FeatureID;
                entity.RatingTally = placeholder;
                entity.RatingActual = placeholder / 11;
                
                  
                return ctx.SaveChanges() == 1;
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
