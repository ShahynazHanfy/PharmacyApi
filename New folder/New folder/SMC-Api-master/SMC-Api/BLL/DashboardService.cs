using AutoMapper;
using SMC_Api.DAL.UnitOfWork;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.BLL
{
    public class DashboardService
    {
        UnitOfWork unitofwork = new UnitOfWork(new SMC_DBEntities());

        public IEnumerable<MonthBalanceDTO> GetYearBalance()
        {
            List<MonthBalanceDTO> yearBalance = new List<MonthBalanceDTO>();
            for (int i = 1; i <= 4; i++)
            {
                List<MonthBalanceDTO> quarterBalance = new List<MonthBalanceDTO>();
                quarterBalance = this.GetQuarterBalancePerMonth(i);
                yearBalance.AddRange(quarterBalance);
            }

            return yearBalance;
        }
        public List<MonthBalanceDTO> GetQuarterBalancePerMonth(int QuarterNum)
        {
            List<MonthBalanceDTO> quarterBalance = new List<MonthBalanceDTO>();
            List<int> QuarterMonthes = this.GetQuarterMonthes(QuarterNum);
            foreach(var m in QuarterMonthes)
            {
                MonthBalanceDTO monthBalance = new MonthBalanceDTO();
                monthBalance = this.GetMonthBalance(m);
                quarterBalance.Add(monthBalance);
            }
            return quarterBalance;
        }

        public MonthBalanceDTO GetMonthBalance(int month)
        {
            int MonthIncome = 0;
            int MonthOutcome = 0;
            //Get All addition Orders
            var InOrders = unitofwork.Order.GetAll().Where(x => x.TypeId == 1 && x.OrderDate.Year == DateTime.Now.Year
             && x.OrderDate.Month == month);

            foreach (var order in InOrders)
            {
                MonthIncome = MonthIncome + order.TotalAmount;
            }
            //Get All Out Orders
            var OutOrders = unitofwork.Order.GetAll().Where(x => x.TypeId == 2 && x.OrderDate.Year == DateTime.Now.Year
             && x.OrderDate.Month == month);

            foreach (var order in OutOrders)
            {
                MonthOutcome = MonthOutcome + order.TotalAmount;
            }
            MonthBalanceDTO monthBalance = new MonthBalanceDTO();
            monthBalance.Income = MonthIncome;
            monthBalance.Outcome = MonthOutcome;
            return monthBalance;
        }

        public IEnumerable<QuarterBalanceDTO> GetYearBalancePerQuarter()
        {
            List<QuarterBalanceDTO> yearBalance = new List<QuarterBalanceDTO>();
            for (int i = 1; i <= 4; i++)
            {
                QuarterBalanceDTO quarterBalance = new QuarterBalanceDTO();
                quarterBalance.Income = this.GetIncomeForQuarter(i);
                quarterBalance.Outcome = this.GetOutcomeForQuarter(i);
                yearBalance.Add(quarterBalance);
            }

            return yearBalance;
        }

        public QuarterBalanceDTO CalculateQuarterBalance(int QuarterNum)
        {
            int income = this.GetIncomeForQuarter(QuarterNum);
            int outcome = this.GetOutcomeForQuarter(QuarterNum);
            QuarterBalanceDTO result = new QuarterBalanceDTO();
            result.Income = income;
            result.Outcome = outcome;
            return result;
        }
      
        public int GetIncomeForQuarter(int QuarterNum)
        {
            int Income = 0;
            var InOrders = unitofwork.Order.GetAll().Where(x => x.TypeId == 1 && x.OrderDate.Year == DateTime.Now.Year
             && GetQuarterMonthes(QuarterNum).Contains(x.OrderDate.Month));

            foreach (var order in InOrders)
            {
                Income = Income + order.TotalAmount;
            }
            return Income;
        }

        public int GetOutcomeForQuarter(int QuarterNum)
        {
            int Outcome = 0;
            var OutOrders = unitofwork.Order.GetAll().Where(x => x.TypeId == 2 && x.OrderDate.Year == DateTime.Now.Year
             && GetQuarterMonthes(QuarterNum).Contains(x.OrderDate.Month));

            foreach (var order in OutOrders)
            {
                Outcome = Outcome + order.TotalAmount;
            }
            return Outcome;
        }

        public List<int> GetQuarterMonthes(int QuarterNum)
        {

            switch (QuarterNum)
            {
                case 1:
                    return new List<int>() { 1, 2, 3 };

                case 2:
                    return new List<int>() { 4, 5, 6 };

                case 3:
                    return new List<int>() { 7, 8, 9 };

                default:
                    return new List<int>() { 10, 11, 12 };
            }

        }

        public OrderDTO GetLastInOrder()
        {
           var entity=  unitofwork.Order.Find(x => x.TypeId == 1).LastOrDefault();
           return  Mapper.Map<Order, OrderDTO>(entity);
        }

        public OrderDTO GetLastOutOrder()
        {
            var entity = unitofwork.Order.Find(x => x.TypeId == 2).LastOrDefault();
            return Mapper.Map<Order, OrderDTO>(entity);
        }

    }
}