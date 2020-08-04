using System.Collections.Generic;
using System.Linq;

using Chainblock.Contracts;

using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Chainblock chainblock;
        private Transaction transaction;

        [SetUp]
        public void Set()
        {
            this.transaction = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", 1505.50);
            this.chainblock = new Chainblock();
            this.chainblock.Add(this.transaction);
        }

        [Test]
        public void CountShouldReturnNumberOfTransactionsInTheChainblock()
        {
            int expectedCount = 1;

            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount, "Count is not correct");
        }

        [Test]
        public void AddShouldAddTransactionToTheChainblock()
        {
            int expectedCount = 1;

            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowArgumentExceptionWhenTransactionWithSameIdAlreadyExists()
        {
            Assert.That(
                () => this.chainblock.Add(this.transaction),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Transaction with this Id is already in the chainblock"));
        }

        [Test]
        public void ContainsShouldReturnTrueIfGivenTransactionIsInTheChainblock()
        {
            Assert.IsTrue(this.chainblock.Contains(this.transaction));
        }

        [Test]
        public void ContainsShouldReturnTrueIfIdBelongsToTransactionInTheChainblock()
        {
            int existingId = this.transaction.Id;

            Assert.IsTrue(this.chainblock.Contains(existingId));
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTheStatusOfTransactionWithGivenId()
        {
            int existingId = this.transaction.Id;
            TransactionStatus expectedStatus = TransactionStatus.Aborted;

            this.chainblock.ChangeTransactionStatus(existingId, expectedStatus);
            TransactionStatus actualStatus = this.transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowArgumentExceptionWhenNoTransactionWithThisIdExists()
        {
            int unexistingId = 5;
            TransactionStatus newStatus = TransactionStatus.Unauthorized;

            Assert.That(
                () => this.chainblock.ChangeTransactionStatus(unexistingId, newStatus),
                Throws
                 .ArgumentException
                 .With
                 .Message
                 .EqualTo("Transaction with this ID does not exist!"));
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowInvalidOperationExceptionWhenTransactionWithThatIdIsNotFound()
        {
            int unexistingId = 5;

            Assert.That(
                () => this.chainblock.RemoveTransactionById(unexistingId),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Transaction with this ID was not found!"));
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTheTransactionWithSpecifiedId()
        {
            int idToRemove = this.transaction.Id;

            this.chainblock.RemoveTransactionById(idToRemove);

            Assert.False(this.chainblock.Contains(idToRemove));
        }

        [Test]
        public void GetByIdShouldThrowInvalidOperationExceptionWhenTransactionWithGivenIdIsnotFound()
        {
            int unexistingId = 5;

            Assert.That(
                () => this.chainblock.GetById(unexistingId),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Transaction with this ID was not found!"));
        }

        [Test]
        public void GetByIdShouldReturnTheTransactionWithTheGivenId()
        {
            int existingId = this.transaction.Id;
            var expectedTransaction = this.transaction;

            var actualTransaction = this.chainblock.GetById(existingId);

            Assert.AreEqual(expectedTransaction, actualTransaction);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowInvalidOperationExceptionWhenNoTransactionsWithThatStatusFound()
        {
            TransactionStatus unexistingStatus = TransactionStatus.Aborted;

            Assert.That(
                () => this.chainblock.GetByTransactionStatus(unexistingStatus),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("There are no transactions with that status!"));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnAllTransactionsWithTheSpecifiedStatus()
        {
            Transaction failedTransaction = new Transaction(2, TransactionStatus.Failed, "Stefan", "Hristo", 38.50);
            Transaction successfulTransaction = new Transaction(3, TransactionStatus.Successfull, "Todor", "Gosho", 150.0);
            this.chainblock.Add(failedTransaction);
            this.chainblock.Add(successfulTransaction);
            IEnumerable<ITransaction> expectedTransactions = new Transaction[2]
            {
                this.transaction,
                successfulTransaction
            }.OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowInvalidOperationExceptionWhenNoTransactionsWithThatStatusExist()
        {
            TransactionStatus unexistingStatus = TransactionStatus.Aborted;

            Assert.That(
                () => this.chainblock.GetAllSendersWithTransactionStatus(unexistingStatus),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("No transactions with that status found"));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnAllSendersWhichHaveTransactionsWithTheGivenStatus()
        {
            Transaction successfulTransaction = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(successfulTransaction);
            Transaction successfulTransaction1 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(successfulTransaction1);
            Transaction abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Ivan", 76.6);
            this.chainblock.Add(abortedTransaction);
            Transaction successfulTransaction2 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 2.0);
            this.chainblock.Add(successfulTransaction2);
            IEnumerable<string> expectedSenders = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>( this.transaction.From, this.transaction.Amount),
                new KeyValuePair<string, double>( successfulTransaction.From, successfulTransaction.Amount),
                new KeyValuePair<string, double>(successfulTransaction1.From, successfulTransaction1.Amount),
                new KeyValuePair<string, double>(successfulTransaction2.From, successfulTransaction2.Amount)
            }.OrderByDescending(s => s.Value)
             .Select(x => x.Key)
             .ToArray();

            IEnumerable<string> actualSenders = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedSenders, actualSenders);
        }


        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowInvalidOperationExceptionWhenNoTransactionsWithThatStatusExist()
        {
            TransactionStatus unexistingStatus = TransactionStatus.Aborted;

            Assert.That(
                () => this.chainblock.GetAllReceiversWithTransactionStatus(unexistingStatus),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("No transactions with that status found"));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnAllReceiversWhichHaveTransactionsWithTheGivenStatus()
        {
            Transaction successfulTransaction = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(successfulTransaction);
            Transaction successfulTransaction1 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(successfulTransaction1);
            Transaction abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Ivan", 76.6);
            this.chainblock.Add(abortedTransaction);
            Transaction successfulTransaction2 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 2.0);
            this.chainblock.Add(successfulTransaction2);
            IEnumerable<string> expectedReceivers = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>( this.transaction.To, this.transaction.Amount),
                new KeyValuePair<string, double>( successfulTransaction.To, successfulTransaction.Amount),
                new KeyValuePair<string, double>(successfulTransaction1.To, successfulTransaction1.Amount),
                new KeyValuePair<string, double>(successfulTransaction2.To, successfulTransaction2.Amount)
            }.OrderByDescending(s => s.Value)
             .Select(x => x.Key)
             .ToArray();

            IEnumerable<string> actualReceivers = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedReceivers, actualReceivers);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnAllTransactionsOrderedCorrectly()
        {
            Transaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(transaction1);
            Transaction transaction2 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(transaction2);
            Transaction transaction3 = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Ivan", 76.6);
            this.chainblock.Add(transaction3);
            Transaction transaction4 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 6.0);
            this.chainblock.Add(transaction4);
            IEnumerable<ITransaction> expectedTransactions = new ITransaction[]
            {
                this.transaction,
                transaction1,
                transaction2,
                transaction3,
                transaction4
            }.OrderByDescending(tr => tr.Amount)
             .ThenBy(tr => tr.Id);

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowInvalidOperationExceptionWhenSpecifiedSenderHasNoTransactions()
        {
            string unexistingSender = "Mario";

            Assert.That(
                () => this.chainblock.GetBySenderOrderedByAmountDescending(unexistingSender),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("Sender does not exist!"));
        }


        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnAllTransactionsFromGivenSender()
        {
            Transaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(transaction1);
            Transaction transaction2 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(transaction2);
            Transaction transaction3 = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Ivan", 76.6);
            this.chainblock.Add(transaction3);
            Transaction transaction4 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 6.0);
            this.chainblock.Add(transaction4);
            IEnumerable<ITransaction> expectedTransactions = new ITransaction[]
            {
                transaction1,
                transaction2,
                transaction3
            }.OrderByDescending(tr => tr.Amount);

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetBySenderOrderedByAmountDescending("Svetlio");

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowInvalidOperationExceptionWhenNoSuchReceiverFound()
        {
            string unexistingReceiver = "Mario";

            Assert.That(
                () => this.chainblock.GetByReceiverOrderedByAmountThenById(unexistingReceiver),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("No such receiver found!"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnAllTransactionsWithTheGivenReceiver()
        {
            Transaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(transaction1);
            Transaction transaction2 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(transaction2);
            Transaction transaction3 = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Ivan", 76.6);
            this.chainblock.Add(transaction3);
            Transaction transaction4 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 6.0);
            this.chainblock.Add(transaction4);
            IEnumerable<ITransaction> expectedTransactions = new ITransaction[]
            {
                this.transaction,
                transaction2,
            }.OrderBy(tr => tr.Amount)
            .ThenBy(tr => tr.Id);

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById("Pesho");

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionWhenNoSuchTransactionsFound()
        {
            var result = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 150);
            
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnAllTransactionsWithGivenStatusAndAmountLessOrEqualToMaximumAllowed()
        {
            Transaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(transaction1);
            Transaction transaction2 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(transaction2);
            Transaction transaction3 = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Ivan", 76.6);
            this.chainblock.Add(transaction3);
            Transaction transaction4 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 6.0);
            this.chainblock.Add(transaction4);
            IEnumerable<ITransaction> expectedTransactions = new ITransaction[]
            {
                transaction1,
                transaction2,
                transaction4,
            };

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 80);

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowInvalidOperationExceptionWhenNoSuchTransactions()
        {
            string unexistingSender = "Mario";
            double minimumAmount = 5.0;

            Assert.That(
                () => this.chainblock.GetBySenderAndMinimumAmountDescending(unexistingSender, minimumAmount),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("No transactions with specified status and minimum amount found"));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnAllTransactionsWithGivenSenderAndAmountBiggerThanGivenAmount()
        {
            Transaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(transaction1);
            Transaction transaction2 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(transaction2);
            Transaction transaction3 = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Ivan", 76.6);
            this.chainblock.Add(transaction3);
            Transaction transaction4 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 6.0);
            this.chainblock.Add(transaction4);
            IEnumerable<ITransaction> expectedTransactions = new ITransaction[]
            {
                transaction2,
                transaction3,
            }.OrderByDescending(tr => tr.Amount);

            IEnumerable<ITransaction> actualTransaction = this.chainblock.GetBySenderAndMinimumAmountDescending("Svetlio", 6.0);

            CollectionAssert.AreEqual(expectedTransactions, actualTransaction);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowInvalidOperationExceptionWhenNoSuchTransactions()
        {
            string unexistingReceiver = "Mario";
            double min = 5.0;
            double max = 500.0;

            Assert.That(
                () => this.chainblock.GetByReceiverAndAmountRange(unexistingReceiver, min, max),
                Throws
                 .InvalidOperationException
                 .With
                 .Message
                 .EqualTo("No transactions with given receiver and in range found"));
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnAllTransactionsWithGivenReceiverAndAmountInTheSpecifiedRange()
        {
            Transaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(transaction1);
            Transaction transaction2 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(transaction2);
            Transaction transaction3 = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Pesho", 76.6);
            this.chainblock.Add(transaction3);
            Transaction transaction4 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 6.0);
            this.chainblock.Add(transaction4);
            IEnumerable<ITransaction> expectedTransactions = new ITransaction[]
            {
                transaction2,
                transaction3,
            };

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetByReceiverAndAmountRange("Pesho", 5, 500);

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollectionWhenNoSuchTransactions()
        {
            double min = 0;
            double max = 10;

            var result = this.chainblock.GetAllInAmountRange(min, max);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnAllTransactionsInTheGivenRange()
        {
            Transaction transaction1 = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Kiro", 5.0);
            this.chainblock.Add(transaction1);
            Transaction transaction2 = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Pesho", 6.0);
            this.chainblock.Add(transaction2);
            Transaction transaction3 = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Pesho", 76.6);
            this.chainblock.Add(transaction3);
            Transaction transaction4 = new Transaction(5, TransactionStatus.Successfull, "Mihail", "Gosho", 6.0);
            this.chainblock.Add(transaction4);
            IEnumerable<ITransaction> expectedTransactions = new ITransaction[]
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4
            };

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetAllInAmountRange(5,500);

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }
    }
}