using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private HashSet<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new HashSet<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.transactions.Any(t => t.Id == tx.Id))
            {
                throw new ArgumentException("Transaction with this Id is already in the chainblock");
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new ArgumentException("Transaction with this ID does not exist!");
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this.transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            var transactions = this.transactions
                                .Where(tr => tr.Amount >= lo && tr.Amount <= hi);
            return transactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                        .OrderByDescending(tr => tr.Amount)
                        .ThenBy(tr => tr.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var receivers = this
                            .transactions
                            .Where(tr => tr.Status == status)
                            .OrderByDescending(tr => tr.Amount)
                            .Select(tr => tr.To)
                            .ToArray();

            if (receivers.Count() == 0)
            {
                throw new InvalidOperationException("No transactions with that status found");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var senders = this
                            .transactions
                            .Where(tr => tr.Status == status)
                            .OrderByDescending(tr => tr.Amount)
                            .Select(tr => tr.From)
                            .ToArray();

            if (senders.Count() == 0)
            {
                throw new InvalidOperationException("No transactions with that status found");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            var transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException("Transaction with this ID was not found!");
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var transactions = this.transactions
                                .Where(tr => tr.To == receiver && tr.Amount > lo && tr.Amount < hi);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("No transactions with given receiver and in range found");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var transactions = this.transactions
                                .Where(tr => tr.To == receiver)
                                .OrderBy(tr => tr.Amount)
                                .ThenBy(tr => tr.Id);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("No such receiver found!");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var transactions = this.transactions
                                    .Where(tr => tr.From == sender && tr.Amount >= amount)
                                    .OrderByDescending(tr => tr.Amount);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("No transactions with specified status and minimum amount found");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var transactions = this.transactions
                .Where(tr => tr.From == sender)
                .OrderByDescending(tr => tr.Amount);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("Sender does not exist!");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var transactions = this.transactions.Where(t => t.Status == status);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with that status!");
            }

            return transactions.OrderByDescending(tr => tr.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var transactions = this.transactions.Where(tr => tr.Status == status && tr.Amount <= amount);
            return transactions;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            var transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException("Transaction with this ID was not found!");
            }

            this.transactions.RemoveWhere(t => t.Id == id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}