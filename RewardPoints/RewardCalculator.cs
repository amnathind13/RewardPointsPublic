using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RewardPointCalculation.RewardModel;

namespace RewardPoints
{
    internal class RewardCalculator
    {
        internal static List<MonthPoints> CalculateMonthlyPoints(List<Transaction> transactions)
        {
            var monthlyPoints = new List<MonthPoints>();
            foreach (var transaction in transactions)
            {
                var points = CalculateRewardPoints(transaction.Amount);
                var month = transaction.Date.Month;

                var existingMonth = monthlyPoints.FirstOrDefault(m => m.Month == month);
                if (existingMonth != null)
                {
                    existingMonth.Points += points;
                }
                else
                {
                    monthlyPoints.Add(new MonthPoints { Month = month, Points = points });
                }
            }
            return monthlyPoints;
        }

        internal static int CalculateTotalPoints(List<Transaction> transactions)
        {
            return transactions.Sum(t => CalculateRewardPoints(t.Amount));
        }

        internal static int CalculateRewardPoints(double amount)
        {

            var points = 0;
            if (amount > 100) //For Amount greater than 100
            {
                points += (int)(amount - 100) * 2;
            }
            if (amount > 50) //for Amount greater 50
            {
                points += (int)(amount - 50) * 1;
            }
            return points;
        }
    }
}
