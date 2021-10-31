using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
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

        //Задание 4

        public int BillNumber { get => _billNumber; set => _billNumber = value; }

        public double Balance { get => _balance; set => _balance = value; }

        public BillType BillType { get => _billType; set => _billType = value; }
    }
}
