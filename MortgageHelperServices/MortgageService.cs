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
        private readonly Guid _userId;

        public MortgageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMortgage(MortgageCreate model)
        {
            var entity = new Mortgage()
            {
                UserID = _userId,
                PropertyID = model.PropertyID,
                Interest = model.Interest,
                Period= model.Period,
                Payment= model.Payment,
                TotalLoanAmount = model.TotalLoanAmount,
                MonthlyPayment = model.MonthlyPayment,
                /*Zero = model.Zero,
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
                NinetyFive = model.NinetyFive*/

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
                var query = ctx.Mortgages.Where(e => e.UserID == _userId).Select(e => new MortgageListItem
                {
                    MortgageID = e.MortgageID,
                    PropertyID = e.PropertyID,
                    TotalLoanAmount = e.TotalLoanAmount,
                    MonthlyPayment = e.MonthlyPayment
                });
                return query.ToArray();
            }
        }
        public MortgageDetail GetMortgageByPropertyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Mortgages.Single(e => e.PropertyID == id && e.UserID == _userId);
                return
                    new MortgageDetail
                    {
                        PropertyID = entity.PropertyID,
                        Interest = entity.Interest,
                        Period = entity.Period,
                        Payment = entity.Payment,
                        TotalLoanAmount = entity.TotalLoanAmount,
                        MonthlyPayment = entity.MonthlyPayment
                    };
            }
        }
        public bool DeleteAllMortgagesGivenPropertyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Mortgages.Where(e => e.PropertyID == id && e.UserID == _userId).ToList();

                foreach (MortgageHelperData.Mortgage item in entity )
                {
                    ctx.Mortgages.Remove(item);

                }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSingleMortgageGivenMortgageID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Mortgages.Single(e => e.MortgageID == id && e.UserID == _userId);

                ctx.Mortgages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
