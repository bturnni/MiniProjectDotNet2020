﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalTest
{
    using DAL;
    class Program
    {
        private static DAL.IDal _dal = DAL.FactoryDAL.Instance;

        private static void PrintDS()
        {
            PrintRequests();
            PrintHostingUnits();
            PrintBranches();
            PrintOrder();
        }

        private static void PrintRequests()
        {
            foreach (BE.GuestRequest item in _dal.GetAllRequests())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }
        private static void PrintHostingUnits()
        {
            foreach (BE.HostingUnit item in _dal.GetAllHostingUnits())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }
        private static void PrintBranches()
        {
            foreach (BE.BankBranch item in _dal.GetAllBranches())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }
        private static void PrintOrder()
        {
            foreach (BE.Order item in _dal.GetAllOrders())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }


        /// <summary>
        /// test Idal's GuestRequest functions
        /// </summary>
        private static void GuestRequest()
        {
            //add
            BE.GuestRequest gR = new BE.GuestRequest();
            gR.GuestRequestKey = ++BE.Configuration.GuestRequestKey;
            gR.PrivateName = "shachar";
            gR.FamilyName = "markovich";
            gR.Email = "21com.bat21@gmail.com";
            gR.Stat = BE.Enums.Status.NotYetApproved;
            gR.RegistrationDate = DateTime.Now;
            gR.EntryDate = new DateTime(2020, 8, 9);
            gR.ReleaseDate = new DateTime(2020, 8, 12);
            gR.Area = BE.Enums.Area.Center;
            gR.type = BE.Enums.UnitType.Hotel;
            gR.Adults = 2;
            gR.Children = 3;
            gR.Pool = true;
            gR.Jecuzzi = true;
            gR.Garden = true;
            gR.ChildrenAttractions = true;
            _dal.AddGuestRequest(gR.Clone());
            PrintRequests();

            //update
            Console.WriteLine("after update:");
            _dal.UpdateGuestRequest(gR.Clone(), BE.Enums.Status.CloseByClient);
            PrintRequests();
        }

        /// <summary>
        /// test Idal's HostingUnit functions
        /// </summary>
        private static void HostingUnit()
        {

            List<BE.HostingUnit> unitsList = _dal.GetAllHostingUnits();

            //add
            BE.HostingUnit unit = new BE.HostingUnit()
            {
                HostingUnitKey = ++BE.Configuration.HostingUnitKey,
                HostingUnitName = "hotel california",
                Owner = unitsList[0].Owner,
                type = BE.Enums.UnitType.Hotel,
                Area = BE.Enums.Area.Center,
                Diary = new bool[BE.Configuration._month, BE.Configuration._days],
            };
            _dal.AddHostingUnit(unit.Clone());
            PrintHostingUnits();

            // update
            unit.Owner = unitsList[2].Owner;
            _dal.UpdateHostingUnit(unit.Clone());
            Console.WriteLine("after update:");
            PrintHostingUnits();

            //delete
            _dal.DeleteHostingUnit(unit.Clone());
            Console.WriteLine("after delete:");
            PrintHostingUnits();
        }

        /// <summary>
        /// test Idal's Order functions
        /// </summary>
        private static void Order()
        {
            List<BE.GuestRequest> rList = _dal.GetAllRequests();
            BE.Order newOrder = new BE.Order()
            {
                HostingUnitKey = _dal.GetAllHostingUnits()[1].HostingUnitKey,
                OrderKey = ++BE.Configuration.OrderKey,
                GuestRequestKey = rList[0].GuestRequestKey,
                Status = rList[0].Stat,
                CreateDate = new DateTime(),
                OrderDate = new DateTime()
            };
            
            // add
            _dal.AddOrder(newOrder.Clone());
            PrintOrder();

            //update
            Console.WriteLine("after update:");
            _dal.UpdateOrder(newOrder.Clone(), BE.Enums.Status.Approved);
            PrintOrder();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("before all changes:");
            PrintDS();
            Console.ReadKey();
            Console.Clear();

            GuestRequest();
            Console.ReadKey();
            Console.Clear();

            HostingUnit();
            Console.ReadKey();
            Console.Clear();

            Order();
            Console.ReadKey();
        }

    }
}
