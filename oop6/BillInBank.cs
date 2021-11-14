using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop6
{
    public class BillInBank
    {
        //Добавлен конструктор (Задание 3)
        public BillInBank(double balance, BillType billType)
        {
            _billNumber = RandomBillNumber();
            _balance = balance;
            _billType = billType;
        }

        //Генерация номера счета
        private static int _rndNumber = 0;

        public int RandomBillNumber()
        {
            return _rndNumber++;
        }

        private int  _billNumber;
        private double _balance;
        private BillType _billType;

        public void SetBillNumber (int billNumber)
        {
            _billNumber = billNumber = RandomBillNumber();
        }

        public int GetBillNumber()
        {
            return _billNumber;
        }

        public void SetBalance(double balance)
        {
            _balance = balance;
        }

        public double GetBalance()
        {
            return _balance;
        }

        public void SetBillType(BillType billType)
        {
            _billType = billType;
        }

        public BillType GetBillType()
        {
            return _billType;
        }

        public int BillNumber { get => _billNumber; set => _billNumber = value; }

        public double Balance { get => _balance; set => _balance = value; }

        public BillType BillType { get => _billType; set => _billType = value; }

        public void MoneyTransfer (BillInBank billInBank, double money)
        {
            if(billInBank.Balance >= money)
            {
                billInBank.Balance = billInBank.Balance - money;
                this.Balance = this.Balance + money;
            }
            else
            {
                Console.WriteLine("На счету недостаточно средств!");
            }
        }


        public static bool operator ==(BillInBank a, BillInBank b) => a.Equals(b);

        public static bool operator !=(BillInBank a, BillInBank b) => !a.Equals(b);

        public override string ToString() => $"Ваш счет: номер {_billNumber}, тип счета: {_billType}, баланс {_balance}";

        public bool Equals (BillInBank other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return _balance == other._balance 
                && _billNumber == other._billNumber 
                && _billType == other._billType;
        }

        public override bool Equals(object obj) => Equals(obj as BillInBank);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = _balance.GetHashCode();

                hash = (hash * 397) ^ _billNumber.GetHashCode();
                hash = (hash * 397) ^ _billType.GetHashCode();

                return hash;

            }
        }

    }
}
