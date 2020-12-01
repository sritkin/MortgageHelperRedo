using MortgageHelperData;
using MortgageHelperModels;
using MortgageHelperModels.MortgageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHelperServices
{
    public class MortgageService
    {
        public bool CreateMortgage(MortgageCreate model)
        {
            var entity = new Mortgage()
            {
                PropertyID = model.PropertyID,
                Zero = model.Zero,
                Five = model.Five,
                Ten = model.Ten,
                Fifteen = model.Fifteen,
                Twenty = model.Twenty,
                TwentyFive =model.TwentyFive,
                Thirty = model.Thirty,
                ThirtyFive = model.ThirtyFive,
                Forty = model.Forty,
                FortyFive = model.FortyFive,
                Fifty = model.Fifty,
                FiftyFive = model.FiftyFive,
                Sixty = model.Sixty,
                SixtyFive = model.SixtyFive,
                Seventy = model.Seventy,
                SeventyFive = model.SeventyFive,
                Eighty = model.Eighty,
                EightyFive = model.EightyFive,
                Ninety = model.Ninety,
                NinetyFive = model.NinetyFive

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Mortgages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MortgageListItem> GetMortgages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Mortgages.Select(e => new MortgageListItem
                {
                    MortgageID = e.MortgageID,
                    PropertyID = e.PropertyID,
                    Zero = e.Zero,
                    Five = e.Five,
                    Ten = e.Ten,
                    Fifteen = e.Fifteen,
                    Twenty = e.Twenty,
                    TwentyFive = e.TwentyFive,
                    Thirty = e.Thirty,
                    ThirtyFive = e.ThirtyFive,
                    Forty = e.Forty,
                    FortyFive = e.FortyFive,
                    Fifty = e.Fifty,
                    FiftyFive = e.FiftyFive,
                    Sixty = e.Sixty,
                    SixtyFive = e.SixtyFive,
                    Seventy = e.Seventy,
                    SeventyFive = e.SeventyFive,
                    Eighty = e.Eighty,
                    EightyFive = e.EightyFive,
                    Ninety = e.Ninety,
                    NinetyFive = e.NinetyFive
                });
                return query.ToArray();
            }
        }
    }
}
