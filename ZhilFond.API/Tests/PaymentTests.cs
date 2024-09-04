using ZhilFond.Core.Models;

namespace Tests
{
    public class PaymentTests
    {
        [Fact]
        public void Payment_SumLessThan0_ReturnArgumentException()
        {
            Guid id = Guid.NewGuid();
            int accountId = 1;
            DateTime date = new(2020, 1, 1);
            decimal sum = -1;

            Assert.Throws<ArgumentException>(() => Payment.Create(id, accountId, date, sum));
        }

        [Fact]
        public void Accrual_DateLetterThanCurrent_ReturnArgumentException()
        {
            Guid id = Guid.NewGuid();
            int accountId = 1;
            DateTime date = DateTime.Now.AddYears(1);
            decimal sum = 1;

            Assert.Throws<ArgumentException>(() => Payment.Create(id, accountId, date, sum));
        }

        [Fact]
        public void Accrual_CorrectData_ReturnPayment()
        {
            Guid id = Guid.NewGuid();
            int accountId = 1;
            DateTime date = new(2020, 1, 1);
            decimal sum = 1;

            Assert.IsType<Payment>(Payment.Create(id, accountId, date, sum));
        }
    }
}
