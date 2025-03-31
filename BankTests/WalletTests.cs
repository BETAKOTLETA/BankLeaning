using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace BankTests
{
    public class WalletTests
    {
        [Fact]
        public void Account_Can_be_Created()
        {
            var account = new BankAccount();
            account.Should().BeOfType<BankAccount>();
        }
        [Fact]
        public void MultipleAccounts_Can_be_Created()
        {
            var account = new BankAccount();
            account.Should().BeOfType<BankAccount>();
            var account2 = new BankAccount();
            account2.Should().BeOfType<BankAccount>();
        }

        //DepositTests

        [Fact]
        public void DepositFunds_ShouldIncreaseBalance()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(10, "123");

            account.GetBalance().Should().Be(10);
        }
        [Fact]
        public void DepositFunds_ShouldThrowException_WhenAmountIsNegative()
        {
            var account = new BankAccount();
            account.SetPassword("123");

            Action act = () => account.Deposit(-10, "123");

            account.GetBalance().Should().Be(0);
            //act.Should().Throw<InvalidOperationException>().WithMessage("Amount must be positive."); //not working
            act.Should().Throw<InvalidOperationException>().Where(ex => ex.Message.Contains("Amount must be positive."));
        }
        [Fact]
        public void DepositFunds_ShouldThrowException_WhenPasswordIsIncorrect()
        {
            var account = new BankAccount();
            account.SetPassword("123");

            Action act = () => account.Deposit(10, "456");

            act.Should().Throw<InvalidOperationException>().Where(ex => ex.Message.Contains("Password verification failed."));
            //act.Should().Throw<InvalidOperationException>().WithMessage("Incorrect password."); //I dont know why it's not returned, maybe there only the last error can be contained
            account.GetBalance().Should().Be(0);
        }
        [Fact]
        public void DepositFunds_ShouldWorkProperly_WithMultipleAccounts()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(10, "123");

            var account2 = new BankAccount();
            account2.SetPassword("456");
            account2.Deposit(20, "456");

            account.GetBalance().Should().Be(10);
            account2.GetBalance().Should().Be(20);
        }
        [Fact]
        public void DepositFunds_ShouldThrowException_WhenAccountIsLocked()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.LockTheAccount("123");
            Action act = () => account.Deposit(10, "123");
            act.Should().Throw<InvalidOperationException>().Where(ex => ex.Message.Contains("Account is locked."));
            account.GetBalance().Should().Be(0);
        }


        //WithdrawTests

        [Theory]
        [InlineData(0.5, 99.5)]
        [InlineData(50, 50)]
        [InlineData(100, 0)]

        public void WithdrawFunds_ShouldDecreaseBalance(double amount, double expected)
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(100, "123");
            account.Withdraw(amount, "123");
            account.GetBalance().Should().Be(expected);
        }

        [Fact]
        public void WithdrawFunds_ShouldThrowException_WhenAmountIsNegative()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(100, "123");
            Action act = () => account.Withdraw(-100, "123");
            act.Should().Throw<InvalidOperationException>().Where(ex => ex.Message.Contains("Amount must be positive."));
        }
        [Fact]
        public void WithdrawFunds_ShouldThrowException_WhenPasswordIsIncorrect()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(100, "123");
            Action act = () => account.Withdraw(-100, "456");
            act.Should().Throw<InvalidOperationException>().Where(ex => ex.Message.Contains("Password verification failed."));
        }
        [Fact]
        public void WithdrawFunds_ShouldThrowException_WhenAmountIsBiggerThanBalance()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(100, "123");
            Action act = () => account.Withdraw(150, "456");
            act.Should().Throw<InvalidOperationException>().Where(ex => ex.Message.Contains("Not enough money."));
        }
        [Fact]
        public void WithdrawFunds_ShouldWorkProperly_WithMultipleAccounts()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(10, "123");
            account.Withdraw(10, "123");

            var account2 = new BankAccount();
            account2.SetPassword("456");
            account2.Deposit(20, "456");
            account2.Withdraw(10, "456");

            account.GetBalance().Should().Be(0);
            account2.GetBalance().Should().Be(10);
        }
        [Fact]
        public void WithdrawFunds_ShouldThrowException_WhenAccountIsLocked()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.Deposit(10, "123");
            account.LockTheAccount("123");
            Action act = () => account.Withdraw(10, "123");
            act.Should().Throw<InvalidOperationException>().Where(ex => ex.Message.Contains("Account is locked."));
            account.GetBalance().Should().Be(10);
        }






        [Fact]
        public void Account_Can_Be_Locked()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.LockTheAccount("123");
            account.IsLocked().Should().BeTrue();
        }
        [Fact]
        public void Account_NotBeLocked_WhenIncorrectPassword()
        {
            var account = new BankAccount();
            account.SetPassword("123");
            account.LockTheAccount("456");
            account.IsLocked().Should().BeFalse();
        }


    }
}