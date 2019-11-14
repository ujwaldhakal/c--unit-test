using System;
using Xunit;
using FakeItEasy;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodingProject
{
    public class AccountInfoTest
    {

        [Fact]
        public async Task TestIfGetAccountAmountActuallyGetsCalledWhileRefreshingAmount()
        {
            var service = A.Fake<IAccountService>();
            var account = new AccountInfo(1, service);
            await account.RefreshAmount();

            A.CallTo(() => service.GetAccountAmount(1)).MustHaveHappened(1, Times.Exactly);
        }


        public class TestDoubleAccountService : IAccountService
        {
            public int amount = 20;
            public async Task<double> GetAccountAmount(int accountId)
            {
                await Task.Delay(100);
                return amount;
            }
        }


        [Fact]
        public async Task TestIfRefreshAmountChangesAmount()
        {
            var service = new TestDoubleAccountService();
            var account = new AccountInfo(1, service);
            Assert.Equal(0, account.Amount);
            await account.RefreshAmount();
            Assert.Equal(20, account.Amount);
        }

        [Fact]
        public async Task testRefreshAmountWhenCalledManyTimes()
        {
           List<Task> TaskList = new List<Task>();
            var service = new TestDoubleAccountService();
            service.amount = 100;
            var account = new AccountInfo(1, service);
            await account.RefreshAmount();
            Assert.Equal(100, account.Amount);

            for (int i = 0; i < 3; i++)
            {
                Task task = Task.Run(() => {
                service.amount = i;
                account = new AccountInfo(1, service);
                account.RefreshAmount().Wait();
                });
                
                TaskList.Add(task);
            }
             Task.WaitAll(TaskList.ToArray());
            Assert.Equal(3, account.Amount);
        }

    }
}
