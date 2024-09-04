using ZhilFond.Core.Models;

namespace Tests
{
    public class AccrualTests
    {
        [Fact]
        public void Accrual_CalculationLessThan0_ReturnArgumentException()
        {
            Guid id = Guid.NewGuid();
            int accountId = 1;
            DateTime period = new(2020, 1, 1);
            decimal inBalance = 0;
            decimal calculation = -1;

            Assert.Throws<ArgumentException>(() => Accrual.Create(id, accountId, period, inBalance, calculation));
        }

        [Fact]
        public void Accrual_DateLetterThanCurrent_ReturnArgumentException()
        {
            Guid id = Guid.NewGuid();
            int accountId = 1;
            DateTime period = DateTime.Now.AddYears(1);
            decimal inBalance = 0;
            decimal calculation = 1;

            Assert.Throws<ArgumentException>(() => Accrual.Create(id, accountId, period, inBalance, calculation));
        }

        [Fact]
        public void Accrual_CorrectData_ReturnAccrual()
        {
            Guid id = Guid.NewGuid();
            int accountId = 1;
            DateTime period = new(2020, 1, 1);
            decimal inBalance = 0;
            decimal calculation = 1;

            Assert.IsType<Accrual>(Accrual.Create(id, accountId, period, inBalance, calculation));
        }
    }
}