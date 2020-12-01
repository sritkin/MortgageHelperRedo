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
                PropertyID = model.PropertyID,
                FeatureID = model.FeatureID,
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
                    RatingTally = e.RatingTally,
                    RatingActual = e.RatingActual
                    
                });
                return query.ToArray();
            }
        }


    }
}
