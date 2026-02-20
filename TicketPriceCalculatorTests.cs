namespace CinemaTicketSystemTests  
{
    using Xunit;
    using CinemaTicketSystem;
    public class TicketPriceCalculatorTests
    {
        private readonly ITicketPriceCalculator calculator = new TicketPriceCalculator();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void CalculatePrice_ForChildUnder6(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(0, price);
        }


        [Theory]
        [InlineData(26)]
        [InlineData(46)]
        [InlineData(64)]
        public void CalculatePrice_BasicPrice(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(300, price);
        }
        [Theory]
        [InlineData(6)]
        [InlineData(17)]
        public void CalculatePrice_SaleForTeenager(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(180, price);
        }
        [Theory]
        [InlineData(65)]
        [InlineData(95)]
        public void CalculatePrice_SaleForPensioner(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(150, price);
        }
        [Theory]
        [InlineData(18)]
        [InlineData(20)]
        [InlineData(25)]
        public void CalculatePrice_SaleForStudents(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(240, price);
        }
        [Fact]
        public void CalculatePrice_SaleFor18Age_NotStudent()
        {
            var request = new TicketRequest
            {
                Age = 18,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(300, price);
        }
        [Theory]
        [InlineData(26)]
        public void CalculatePrice_SaleForStudents_BorderSale_26Age(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(300, price);
        }
        [Theory]
        [InlineData(17)]
        public void CalculatePrice_SaleForStudents_BorderSale_17Age(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(210, price);
        }

        [Fact]
        public void CalculatePrice_MorningSale()
        {
            var request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(11, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(255, price);
        }
        [Fact]
        public void CalculatePrice_SaleInWednesday()
        {
            var request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(14, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(210, price);
        }
        [Fact]
        public void CalculatePrice_VIPSale()
        {
            var request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                IsVip = true,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(14, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(600, price);
        }
        [Fact]
        public void CalculatePrice_VIPSale_With_Student()
        {
            var request = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                IsVip = true,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(14, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(480, price);
        }
        [Fact]
        public void CalculatePrice_VIPSale_With_Student_Wednesday()
        {
            var request = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                IsVip = true,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(14, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(420, price);
        }
        [Fact]
        public void CalculatePrice_MaxSale()
        {
            var request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(10, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(210, price);
        }
        [Theory]
        [InlineData(18)]
        [InlineData(20)]
        [InlineData(25)]
        public void CalculatePrice_MoreSale(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = true,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(10, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(210, price);
        }
        [Theory]
        [InlineData(0)]
        public void CalculatePrice_BorderPrice_ZeroAge(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(0, price);
        }
      
       
        [Fact]
        public void CalculatePrice_BorderSale_At18Age()
        {
            var request = new TicketRequest
            {
                Age = 18,
                IsVip = false,
                Day = DayOfWeek.Wednesday,
                SessionTime = new TimeSpan(10, 0, 0)
            };
            var price = calculator.CalculatePrice(request);
            Assert.Equal(210, price);
        }

        [Theory]
        [InlineData(121)]
        [InlineData(150)]
        [InlineData(200)]
        public void CalculatePrice_ArgumentOutOfRangeException_Over_120(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculatePrice(request));
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-15)]
        [InlineData(-200)]
        public void CalculatePrice_ArgumentOutOfRangeException_Over_0(int age)
        {
            var request = new TicketRequest
            {
                Age = age,
                IsStudent = false,
                IsVip = false,
                Day = DayOfWeek.Monday,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculatePrice(request));
        }
        [Fact]
        public void CalculatePrice_ArgumentNullException()
        {
            TicketRequest request = null;

            Assert.Throws<ArgumentNullException>(() => calculator.CalculatePrice(request));
        }
    }
}