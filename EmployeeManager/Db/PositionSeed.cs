using System.Collections.Generic;
using System.Linq;
using EmployeeManager.Models;

namespace EmployeeManager.Db
{
    public static class PositionSeed
    {
        public static void Seed(EmployeeManagerDbContext dbContext)
        {
            if (!dbContext.Positions.Any())
            {
                dbContext.Positions.AddRange(GetPreconfiguredPosition());
                dbContext.SaveChanges();
            }
        }

        static List<Position> GetPreconfiguredPosition()
        {
            return new List<Position>()
            {
                new Position("Директор"),
                new Position("Тестировщик"),
                new Position("Программист")
            };
        }
    }
}