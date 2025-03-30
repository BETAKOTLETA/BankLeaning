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
        public void DepositFunds_ShouldIncreaseBalance_WhenAmountIsPositive()
        {
            var account = new BankAccount();
            account.SetPassword("123");

            account.DepositFunds(10, "123");

            account.GetBalance().Should().Be(10);
        }
        [Fact]
        public void DepositFunds_ShouldThrowException_WhenAmountIsNegative()
        {
            var account = new BankAccount();
            account.SetPassword("123");

            Action act = () => account.DepositFunds(-10, "123");

            account.GetBalance().Should().Be(0);

            act.Should().Throw<InvalidOperationException>().WithMessage("Amount must be positive.");
        }

    }
}